using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoader
{
    #region Singleton
    private static ItemLoader m_Instance;
    public static ItemLoader Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = new ItemLoader();
            }

            return m_Instance;
        }
    }
    #endregion

    Dictionary<EItem, ItemScriptableObject> m_Items;

    public ItemLoader()
    {
        m_Items = new Dictionary<EItem, ItemScriptableObject>();
        LoadAll();
    }

    private string[] GetAssetsNames()
    {
        string[] assetNames = {
            nameof(EItem.Bread),
            nameof(EItem.Eggs),
            nameof(EItem.Meat)
        };

        return assetNames;
    }

    public void LoadAll()
    {
        string[] assetNames = GetAssetsNames();
        List<ItemScriptableObject> items = BundleLoader.Instance.LoadAll<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, true, assetNames);
        foreach (ItemScriptableObject itemData in items)
        {
            EItem itemId = itemData.Value.ItemId;

            if (!m_Items.ContainsKey(itemId)) m_Items.Add(itemId, itemData);
            else m_Items[itemId] = itemData;
        }
    }

    public Item Get(EItem itemId)
    {
        if (!m_Items.ContainsKey(itemId))
        {
            string assetName = Enum.GetName(typeof(EItem), itemId);
            ItemScriptableObject itemData = BundleLoader.Instance.Load<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, assetName);
            m_Items.Add(itemId, itemData);
        }

        return m_Items[itemId].Value;
    }
}
