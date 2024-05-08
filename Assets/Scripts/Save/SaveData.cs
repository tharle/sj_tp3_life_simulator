using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class SaveData
{
    public long DateTimeInBinary;
    public List<string> NameItens;

    public DateTime Date { get { return DateTime.FromBinary(DateTimeInBinary);} }

    public SaveData()
    {
        DateTimeInBinary = DateTime.Now.ToBinary();
        NameItens = new List<string>();
    }

    public void FromItens(List<Item> items)
    {
        NameItens = new List<string>();
        foreach (var item in items)
        {
            NameItens.Add(item.Name);
        }
    }

    public List<Item> ToItens()
    {
        ItemLoader.Instance.LoadAll();

        List<Item> items = new List<Item>();

        foreach (string nameItem in NameItens)
        {
            items.Add(ItemLoader.Instance.Get(nameItem));
        }

        return items;
    }
}
