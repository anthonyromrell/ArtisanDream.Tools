using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Button))]
public class AvaliableButtonBehaviour : MonoBehaviour
{
    private const float V = 0.01f;
    private Image buttonImage;
    private Button buttonObj;
    public GameAction endGame, sendavaliable;
    private Coroutine waitToUse;
    public Image avaliableBar;
    public int avaliableNum;
    public IntData avaliableNumData;
    [HideInInspector] public AvailableData avaliableDataObject;

    private WaitForFixedUpdate wffObj;
    private WaitForSeconds wfsObj;

    private void Start()
    {
        buttonObj = GetComponent<Button>();
        buttonObj.interactable = false;
        sendavaliable.raise += GetavaliableHandler;
        buttonImage = GetComponent<Image>();
        endGame.raiseNoArgs += EndGameHandler;
    }

    private void EndGameHandler()
    {
        buttonObj.interactable = false;
    }

    private void GetavaliableHandler(object obj)
    {
        buttonObj.interactable = true;
        if (avaliableNumData.value != avaliableNum) return;
        avaliableDataObject = obj as AvailableData;
        buttonImage.color = avaliableDataObject.activeColor;
        avaliableBar.color = avaliableDataObject.activeColor;
        avaliableBar.fillAmount = avaliableDataObject.totalAvailable;
        wffObj = new WaitForFixedUpdate();
        wfsObj = new WaitForSeconds(avaliableDataObject.useRate);
    }

    public void Click()
    {
        if (waitToUse != null) return;
        waitToUse = StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        if (Math.Abs(avaliableBar.fillAmount) <= 0) yield break;
        avaliableDataObject.useAvailable?.Invoke();
        var tempAmount = avaliableBar.fillAmount - avaliableDataObject.powerLevel;
        if (tempAmount < 0) tempAmount = 0;

        while (avaliableBar.fillAmount > tempAmount)
        {
            avaliableBar.fillAmount -= V;
            yield return wffObj;
        }

        yield return wfsObj;
        avaliableDataObject.totalAvailable = avaliableBar.fillAmount;
        waitToUse = null;
    }
}