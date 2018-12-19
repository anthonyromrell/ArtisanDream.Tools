using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

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
	public WaitForSeconds Wait { get;  set; }
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
		
		foreach (var obj in Available.ObjectList)
		{
			yield return Wait;
			var newButton = Instantiate(Button, newCanvas.GetComponentInChildren<LayoutGroup>().transform);
			var buttonComponent = newButton.GetComponent<Button>();
			var imageComponent = newButton.GetComponent<Image>();
			imageComponent.sprite = obj.PreviewArt;
		
			buttonComponent.onClick.AddListener(() => { MakePurchase(obj);});
			buttonComponent.onClick.AddListener(() => { DisableButton(obj, buttonComponent);});
			
			var label = newButton.GetComponentInChildren<Text>();
			label.text = obj.name;
		}
	}

	private void DisableButton(PurchasableObject obj, Button btn)
	{
		if (obj.Perpetual)
		{
			btn.interactable = false;
			btn.onClick.RemoveAllListeners();
		}
	}
	
	
	public void MakePurchase(PurchasableObject obj)
	{
		for (var i = 0; i < Available.ObjectList.Count; i++)
		{
			var availableObject = Available.ObjectList[i];
			
			if (availableObject != obj || Cash.Value < availableObject.Value) continue;
			Cash.Value -= availableObject.Value;
			
			if (!Purchased.ObjectList.Contains(obj))
			{
				Purchased.ObjectList.Add(obj);
			}
			else
			{
				obj.UsageCount += obj.UsagePurchase;
			}
			
			if (availableObject.Perpetual)
			{
				Available.ObjectList.Remove(availableObject);
			}
		}
	}

	public void PurchaseAll()
	{
		if (Cash.Value >= TotalValue)
		{
			Cash.Value -= TotalValue;
			for (var i = 0; i < Available.ObjectList.Count; i++)
			{
				var item = Available.ObjectList[i];
				Available.ObjectList[i].Perpetual = true;
				Purchased.ObjectList.Add(item);
			}

			Available.ObjectList.Clear();
		}
	}

	public void CalculateAllValues()
	{
		TotalValue = 0;
		foreach (var item in Available.ObjectList)
		{
			var newItem = item;
			TotalValue += newItem.Value;
		}
		TotalValue %= 75;
	}
}