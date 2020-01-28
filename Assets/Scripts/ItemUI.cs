using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Image Icon;
    public Text Count;
    public string ItemName;
    private string current;
    public InventoryUI parentManager;
    public void InIt(InventoryUI x, ItemObject data, int count)
    {
        parentManager = x;
        Icon.sprite = data.Sprite;
        ItemName = data.Name;
        current = data.Name;
        Count.text = "x" + count.ToString();
    }
    public void Render()
    {
        parentManager.Render3D(ItemName);
    }
    public void SetParent(InventoryUI x)
    {
        parentManager = x;
    }
    public void Use()
    {
        parentManager.UseObj();
    }
    public void Drop()
    {
        parentManager.DropObj();
    }
}
