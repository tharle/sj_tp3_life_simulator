using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ItemLoader : MonoBehaviour
{
    #region Singleton
    private static ItemLoader m_Instance;

    public static ItemLoader Instance { 
        get { 
            if (m_Instance == null) 
            {
                GameObject go = new GameObject("ItemLoader");
                m_Instance = go.AddComponent<ItemLoader>();
            } 

            return m_Instance;
        }
    }
    #endregion

    private Dictionary<string, ItemScriptableObject> m_Items = new Dictionary<string, ItemScriptableObject>(); // Name/ItemScriptableObject
    private bool IsLoading;


    IEnumerator Start() {
        IsLoading = true;
        yield return LoadAll();
    }

    public ItemLoader()
    {
        
    }

    /*private string[] GetAssetsNames()
    {
        string[] assetNames = {
            nameof(EItem.Bread),
            nameof(EItem.Eggs),
            nameof(EItem.Meat)
        };

        return assetNames;
    }*/

    public IEnumerator LoadAll(bool forceLoad = false)
    {
        if (m_Items.Count <= 0 && forceLoad) 
        {
            //string[] assetNames = GetAssetsNames();
            yield return BundleLoader.Instance.LoadAll<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, true, OnLoadAllItems);
        }
        
    }

    private void OnLoadAllItems(List<ItemScriptableObject> items)
    {
        foreach (ItemScriptableObject itemData in items)
        {
            //EItem itemId = itemData.Value.ItemId;

            if (!m_Items.ContainsKey(itemData.name)) m_Items.Add(itemData.name, itemData);
            else m_Items[itemData.name] = itemData;
        }
    }


    public Item Get(string itemName)
    {

        if (!m_Items.ContainsKey(itemName.Trim()))
        {
            ItemScriptableObject itemData = BundleLoader.Instance.Load<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, itemName);
            m_Items.Add(itemName, itemData);
        }

        return m_Items[itemName.Trim()].Value;
    }

    public IEnumerator GetAll(bool IsRefrigerator, Action<List<Item>> OnReturn)
    {
        while(IsLoading) yield return null; // wait for next frame until the itens are loading
        
        //if(m_Items.Count <= 0) yield return LoadAll();

        List<Item> result = new List<Item>();

        foreach (ItemScriptableObject itemData in m_Items.Values)
        {
            Item item = itemData.Value;
            if (item.IsRefrigerator == IsRefrigerator) result.Add(item);
        }

        OnReturn?.Invoke(result);
    }
}
