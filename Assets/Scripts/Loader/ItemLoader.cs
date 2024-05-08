using System.Collections.Generic;
using System.Linq;
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

    private Dictionary<string, ItemScriptableObject> m_Items; // Name/ItemScriptableObject

    public ItemLoader()
    {
        m_Items = new Dictionary<string, ItemScriptableObject>();
        LoadAll();
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

    public void LoadAll(bool forceLoad = false)
    {
        if (m_Items.Count > 0 && !forceLoad) return;

        //string[] assetNames = GetAssetsNames();
        List<ItemScriptableObject> items = BundleLoader.Instance.LoadAll<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, true);
        foreach (ItemScriptableObject itemData in items)
        {
            //EItem itemId = itemData.Value.ItemId;

            if (!m_Items.ContainsKey(itemData.name)) m_Items.Add(itemData.name, itemData);
            else m_Items[itemData.name] = itemData;
        }
    }

    public Item Get(string itemName)
    {
        if (!m_Items.ContainsKey(itemName))
        {
            ItemScriptableObject itemData = BundleLoader.Instance.Load<ItemScriptableObject>(GameParameters.BundleNames.SCRIT_OBJETS, itemName);
            m_Items.Add(itemName, itemData);
        }

        return m_Items[itemName].Value;
    }

    public List<Item> GetAll(bool IsRefrigerator)
    {
        if(m_Items.Count <= 0) LoadAll();

        List<Item> result = new List<Item>();

        foreach (ItemScriptableObject itemData in m_Items.Values)
        {
            Item item = itemData.Value;
            if (item.IsRefrigerator == IsRefrigerator) result.Add(item);
        }

        return result;
    }
}
