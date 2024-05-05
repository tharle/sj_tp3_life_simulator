using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Item
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public float Price;
    public bool IsRefrigerator;
}

[CreateAssetMenu]
public class ItemScriptableObject : ScriptableObject
{
    public Item Value;
}
