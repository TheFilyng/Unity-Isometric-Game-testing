using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }
        instance = this;
    }

    #endregion

    public int space = 20;
    public List<Item> items = new List<Item>();

    public delegate void OnItemPicked();
    public OnItemPicked onItemPickedCallback; //To update the Inventory UI when an item is picked or removed

    // Start is called before the first frame update
    public void Add(Item item)
    {
        if (items.Count < 20)
        {
            items.Add(item);
            if (onItemPickedCallback != null)
            {
                onItemPickedCallback.Invoke();
            }
        }
    }

    public void Remove(Item item)
    {

        items.Remove(item);
        if (onItemPickedCallback != null)
        {
            onItemPickedCallback.Invoke();
        }

    }
}
