using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour
{
    public RectTransform Content;
    public GameObject Item;
    public InventoryObject inventory;
    public GameObject rawMeat;
    public GameObject pineapple;
    public ItemUI j;
    public ItemUI k;
    private GameObject rendered;
    public Text modelName;
    public Text desc;
    public Player player;


    void Start()
    {
    }

    public void Refresh()
    {
        while (Content.childCount > 0)
        {
            var child = Content.GetChild(0);
            child.SetParent(null);
            Destroy(child.gameObject);
        }

        var items = inventory.GetItems();
        foreach (var item in items)
        {
            var go = Instantiate(Item) as GameObject;
            go.transform.SetParent(Content);
            var itemUI = go.GetComponent<ItemUI>();
            itemUI.InIt(this, inventory.GetItemData(item.Key), (item.Value));
            // itemUI.Icon.sprite = inventory.GetSprite(item.Key);
            //itemUI.Count.text = "x " + item.Value.ToString();
        }
    }

    public void Render3D(string name)
    {
        j.SetParent(this);
        k.SetParent(this);
        if (name == "Pineapple")
        {
            if (rendered)
                Destroy(rendered);
            rendered = Instantiate(pineapple) as GameObject;
            rendered.transform.position = new Vector3(1000f, 1200f, 1035f);
            var item = rendered.GetComponent<Item>();
            modelName.text = item.item.Name;
            desc.text = item.item.Description;
        }
        if (name == "Meat")
        {
            if (rendered)
                Destroy(rendered);
            rendered = Instantiate(rawMeat) as GameObject;
            rendered.transform.position = new Vector3(1000f, 1200f, 1035f);
            rendered.transform.Rotate(90f, 90f, 90f);
            var item = rendered.GetComponent<Item>();
            modelName.text = item.item.Name;
            desc.text = item.item.Description;
        }
    }
    public void UseObj()
    {
        if (modelName.text == "NA")
            Debug.Log("No object selected to be used");
        else
        {
            var items = inventory.GetItems();
            foreach (var item in items)
            {
                if (item.Key == modelName.text && item.Value > 0)
                {
                    player.Consume(rendered.GetComponent<Item>());
                    inventory.ReduceWeight(rendered.GetComponent<Item>());
                    inventory.ReduceCount(rendered.GetComponent<Item>());
                    Refresh();
                }
            }
        }
    }
    public void DropObj()
    {
        if (modelName.text == "NA")
            Debug.Log("No object selected to be dropped");
        if (modelName.text == "Pineapple")
        {
            var items = inventory.GetItems();
            foreach (var item in items)
            {
                if (item.Key == modelName.text && item.Value > 0)
                {
                    player.Drop(pineapple);
                    inventory.ReduceWeight(rendered.GetComponent<Item>());
                    inventory.ReduceCount(rendered.GetComponent<Item>());
                    Refresh();
                }
            }
        }
        if (modelName.text == "Meat")
        {
            var items = inventory.GetItems();
            foreach (var item in items)
            {
                if (item.Key == modelName.text && item.Value > 0)
                {
                    player.Drop(rawMeat);
                    inventory.ReduceWeight(rendered.GetComponent<Item>());
                    inventory.ReduceCount(rendered.GetComponent<Item>());
                    Refresh();
                }
            }
        }
    }
    private void Update()
    {
        if(rendered)
        rendered.transform.Rotate(0, 4 * 10f * Time.deltaTime, 0);
    }
}
