using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Store", menuName = "Store/StoreFront")]
public class Store : ScriptableObject
{
    public GameObject canvas;
    public GameObject button;
    public IntData cash;
    public int totalValue = 3000;
    public float holdTime = 0.25f;
    public GameActionAdvanced sendThisCoroutine;
    public GameActionAdvanced runBuildButtonsCoroutine;
    public UnityEvent enableEvent;
    private WaitForSeconds Wait { get; set; }
    public Object WaitObject { get; set; }
    public InventoryData available;

    public enum LayoutTypes
    {
        Grid,
        Horizontal,
        Vertical
    }

    [FormerlySerializedAs("CurrentLayout")] public LayoutTypes currentLayout;

    public void OnEnable()
    {
        Wait = new WaitForSeconds(holdTime);
        enableEvent.Invoke();
    }

    public void BuildUi()
    {
        sendThisCoroutine.Raise(this);
        runBuildButtonsCoroutine.RaiseNoArgs();
    }

    public IEnumerator RunCoroutine()
    {
        var newCanvas = Instantiate(canvas);

        foreach (IStoreItem obj in available.storeDataObjList)
        {
            yield return Wait;
            var newButton = Instantiate(button, newCanvas.GetComponentInChildren<LayoutGroup>().transform);
            var buttonComponent = newButton.GetComponent<Button>();
            var imageComponent = newButton.GetComponent<Image>();
            imageComponent.sprite = obj.PreviewArt;
        
            buttonComponent.onClick.AddListener(() => { MakePurchase(obj); });
            buttonComponent.onClick.AddListener(() => { DisableButton(obj, buttonComponent); });
        
            var label = newButton.GetComponentInChildren<Text>();
            label.text = obj.ThisName;
        }
    }

    private void DisableButton(IStoreItem obj, Button btn)
    {
        if (obj.ItemPurchaseType == PurchaseType.Type.NonConsumable)
        {
            btn.interactable = false;
            btn.onClick.RemoveAllListeners();
        }
    }


    public void MakePurchase(IStoreItem obj)
    {
         for (var i = 0; i < available.storeDataObjList.Count; i++)
         {
             var availableObject = available.storeDataObjList[i];
        
             if (cash.Value < availableObject.Price) continue;
             cash.Value -= availableObject.Price;
        
             if (!available.storeDataObjList.Contains(obj))
             {
                 available.storeDataObjList.Add(obj);
             }
        
             switch (obj.ItemPurchaseType)
             {
                 case PurchaseType.Type.Consumable:
                     break;
                 case PurchaseType.Type.NonConsumable:
                     break;
                 case PurchaseType.Type.AutoRenewAbleSubscription:
                     break;
                 case PurchaseType.Type.NonRenewingSubscription:
                     break;
                 default:
                     throw new ArgumentOutOfRangeException();
             }

			// else if(obj == typeof(PurchasableObject))
			// {
			// 	var newObj = obj as PurchasableObject;
			// 	newObj.UsageCount += newObj.UsagePurchase;
			// }
			
			if (obj.ItemPurchaseType == PurchaseType.Type.NonConsumable)
			{
		        //	Available.ObjectList.Remove(availableObject);
			} 
         }
    }

    public void PurchaseAll()
    {
        if (cash.Value >= totalValue)
        {
            cash.Value -= totalValue;
            for (var i = 0; i < available.storeDataObjList.Count; i++)
            {
                var item = available.storeDataObjList[i];
                available.storeDataObjList.Add(item);
            }
    
            available.inventoryDataObjList.Clear();
        }
    }
    
    public void CalculateAllValues()
    {
        totalValue = 0;
        foreach (var item in available.storeDataObjList)
        {
            var newItem = item;
            totalValue += newItem.Price;
        }
    
        totalValue %= 75;
    }
}