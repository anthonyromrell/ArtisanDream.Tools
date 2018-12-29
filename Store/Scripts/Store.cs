using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Store", menuName = "Store/StoreFront")]
public class Store : ScriptableObject, IRunCoroutine
{
    public PurchaseableObjects Available;
    public PurchaseableObjects Purchased;
    public GameObject Canvas;
    public GameObject Button;
    public IntData Cash;
    public int TotalValue = 3000;
    public float HoldTime = 0.25f;
    public GameAction SendThisCoroutine;
    public GameAction RunBuildButtonsCoroutine;
    public UnityEvent EnableEvent;
    public WaitForSeconds Wait { get; set; }
    public Object WaitObject { get; set; }
    public IWait WaitObj { get; set; }

    public enum LayoutTypes
    {
        Grid,
        Horizontal,
        Vertical
    }

    public LayoutTypes CurrentLayout;

    public void OnEnable()
    {
        Wait = new WaitForSeconds(HoldTime);
        EnableEvent.Invoke();
    }

    public void BuildUi()
    {
        SendThisCoroutine.Raise(this);
        RunBuildButtonsCoroutine.RaiseNoArgs();
    }

    public IEnumerator RunCoroutine()
    {
        var newCanvas = Instantiate(Canvas);

        foreach (var obj in Available.PurchasableList)
        {
            yield return Wait;
            var newButton = Instantiate(Button, newCanvas.GetComponentInChildren<LayoutGroup>().transform);
            var buttonComponent = newButton.GetComponent<Button>();
            var imageComponent = newButton.GetComponent<Image>();
            imageComponent.sprite = obj.PreviewArt;

            buttonComponent.onClick.AddListener(() => { MakePurchase(obj); });
            buttonComponent.onClick.AddListener(() => { DisableButton(obj, buttonComponent); });

            var label = newButton.GetComponentInChildren<Text>();
            label.text = obj.Name;
        }
    }

    private void DisableButton(ICanBePurchased obj, Button btn)
    {
        if (obj.ItemPurchaseType == PurchaseType.Type.NonConsumable)
        {
            btn.interactable = false;
            btn.onClick.RemoveAllListeners();
        }
    }


    public void MakePurchase(ICanBePurchased obj)
    {
        for (var i = 0; i < Available.ObjectList.Count; i++)
        {
            var availableObject = Available.PurchasableList[i];

            if (availableObject != obj || Cash.Value < availableObject.Value) continue;
            Cash.Value -= availableObject.Value;

            if (!Purchased.PurchasableList.Contains(obj))
            {
                Purchased.PurchasableList.Add(obj);
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

//			else if(obj == typeof(PurchasableObject))
//			{
//				var newObj = obj as PurchasableObject;
//				newObj.UsageCount += newObj.UsagePurchase;
//			}
//			
//			if (obj.ItemPurchaseType == PurchaseType.Type.NonConsumable)
//			{
//		//		Available.ObjectList.Remove(availableObject);
//			}
        }
    }

    public void PurchaseAll()
    {
        if (Cash.Value >= TotalValue)
        {
            Cash.Value -= TotalValue;
            for (var i = 0; i < Available.PurchasableList.Count; i++)
            {
                var item = Available.PurchasableList[i];
                Purchased.PurchasableList.Add(item);
            }

            Available.ObjectList.Clear();
        }
    }

    public void CalculateAllValues()
    {
        TotalValue = 0;
        foreach (var item in Available.PurchasableList)
        {
            var newItem = item;
            TotalValue += newItem.Value;
        }

        TotalValue %= 75;
    }
}