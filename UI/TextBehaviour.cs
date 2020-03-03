using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextBehaviour : MonoBehaviour
{
    private Text textObj;
    public StringListData stringListDataObj;
    void Awake()
    {
        textObj = GetComponent<Text>();
    }

    void Update()
    {
        textObj.text = stringListDataObj.ReturnCurrentLine();
    }
}