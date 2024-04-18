using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EItem
{
    None, 
    Bread
}

[SerializeField]
public struct ItemData
{
    public EItem ItemId;
    public string Name;
    public string Description;
}

public class ItemScriptableObject : ScriptableObject
{
    public ItemData Item;
}
