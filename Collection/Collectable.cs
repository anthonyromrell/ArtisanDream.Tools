using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Collectable : ScriptableObject
{
    public Sprite art;
    public int price = 10;
    public bool collected;
}