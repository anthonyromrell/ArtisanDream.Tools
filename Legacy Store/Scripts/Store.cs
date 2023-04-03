using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Object = UnityEngine.Object;

[CreateAssetMenu(fileName = "Store", menuName = "Store/StoreFront")]
public class Store : ScriptableObject
{
    [FormerlySerializedAs("Available")] public PurchaseableObjects available;
    [FormerlySerializedAs("Purchased")] public PurchaseableObjects purchased;
    [FormerlySerializedAs("Canvas")] public GameObject canvas;
    [FormerlySerializedAs("Button")] public GameObject button;
    [FormerlySerializedAs("Cash")] public IntData cash;
    [FormerlySerializedAs("TotalValue")] public int totalValue = 3000;
    [FormerlySerializedAs("HoldTime")] public float holdTime = 0.25f;
    [FormerlySerializedAs("SendThisCoroutine")] public GameAction sendThisCoroutine;
    [FormerlySerializedAs("RunBuildButtonsCoroutine")] public GameAction runBuildButtonsCoroutine;
    [FormerlySerializedAs("EnableEvent")] public UnityEvent enableEvent;
    public WaitForSeconds Wait { get; set; }
    public Object WaitObject { get; set; }
    //public IWait WaitObj { get; set; }

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
        sendThisCoroutine.raise(this);
        runBuildButtonsCoroutine.raiseNoArgs();
    }

    public IEnumerator RunCoroutine()
    {
        var newCanvas = Instantiate(canvas);

        foreach (var obj in available.purchasableList)
        {
            yield return Wait;
            var newButton = Instantiate(button, newCanvas.GetComponentInChildren<LayoutGroup>().transform);
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
        for (var i = 0; i < available.objectList.Count; i++)
        {
            var availableObject = available.purchasableList[i];

            if (availableObject != obj || cash.value < availableObject.Value) continue;
            cash.value -= availableObject.Value;

            if (!purchased.purchasableList.Contains(obj))
            {
                purchased.purchasableList.Add(obj);
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
        if (cash.value >= totalValue)
        {
            cash.value -= totalValue;
            for (var i = 0; i < available.purchasableList.Count; i++)
            {
                var item = available.purchasableList[i];
                purchased.purchasableList.Add(item);
            }

            available.objectList.Clear();
        }
    }

    public void CalculateAllValues()
    {
        totalValue = 0;
        foreach (var item in available.purchasableList)
        {
            var newItem = item;
            totalValue += newItem.Value;
        }

        totalValue %= 75;
    }
}