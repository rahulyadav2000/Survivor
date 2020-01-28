using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public float MaxWeight = 2.0f;

    private float currentWeight = 0;
    private Dictionary<string, int> mapNameToCount = new Dictionary<string, int>();
    private Dictionary<string, GameObject> mapNameToObject = new Dictionary<string, GameObject>();

    public bool AddItem(GameObject go)
    {
        var item = go.GetComponent<Item>();
        if (!item)
        {
            // TODO @set reason for rejection
            // GO is not a pickable item
            return false;
        }

        if ((item.item.Weight + currentWeight) <= MaxWeight)
        {
            if (!mapNameToCount.ContainsKey(item.item.Name))
            {
                mapNameToCount.Add(item.item.Name, 0);
            }

            mapNameToCount[item.item.Name]++;
            currentWeight += item.item.Weight;

            if (!mapNameToObject.ContainsKey(item.item.Name))
            {
                var tempGO = Instantiate(go) as GameObject;
                tempGO.SetActive(false);
                mapNameToObject.Add(item.item.name, tempGO);
            }

            return true;
        }
        else
        {
            // TODO @set reason for rejection
            // Backpack is full
            return false;
        }
    }

    public Sprite GetSprite(string name)
    {
        if (mapNameToObject.ContainsKey(name))
            return mapNameToObject[name].GetComponent<Item>().item.Sprite;

        return null;
    }
    public ItemObject GetItemData(string name)
    {
        if (mapNameToObject.ContainsKey(name))
            return mapNameToObject[name].GetComponent<Item>().item;

        return null;
    }
    public void ReduceCount(Item k)
    {
        mapNameToCount[k.item.Name]--;
    }
    public void ReduceWeight(Item k)
    {
        currentWeight -= k.item.Weight;
    }
    public Dictionary<string, int> GetItems()
    {
        return mapNameToCount;
    }
}
