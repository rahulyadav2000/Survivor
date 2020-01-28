using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    Food,
    Equipment,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public ItemType type;
    public string Name;
    [TextArea (15,20)]
    public string Description;
    public float Weight; // in kgs
    public Sprite Sprite;
    public List<string> Actions;
}
