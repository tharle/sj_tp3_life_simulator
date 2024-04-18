using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemData
{
    public string Name;
    public string Description;
    public Sprite Sprite;
}

[CreateAssetMenu]
public class ItemScriptableObject : ScriptableObject
{
    public ItemData Item;
}
