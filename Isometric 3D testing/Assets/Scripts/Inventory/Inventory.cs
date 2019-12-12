using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    int space = 20;

    public List<Item> items = new List<Item>();

    public delegate void OnItemPickedCallback();
    public OnItemPickedCallback onItemPickedCallback;

    #region Singleton
    public static Inventory instance;
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one inventory instance!");
            return;
        }
        instance = this;
    } 
    #endregion

    public void AddItem(Item item)
    {
        if (items.Count < space)
        {
            items.Add(item);
            item.OnPickUp();
        }
        else
        {
            Debug.Log("Not enough space");
            return;
        }
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
