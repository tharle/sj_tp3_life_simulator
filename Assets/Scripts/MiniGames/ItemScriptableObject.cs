using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItem
{
    Bread,
    Meat,
    Eggs
}

[Serializable]
public struct Item
{
    public string Name;
    public string Description;
    public Sprite Sprite;
    public EItem ItemId;
}

[CreateAssetMenu]
public class ItemScriptableObject : ScriptableObject
{
    public Item Value;
}
