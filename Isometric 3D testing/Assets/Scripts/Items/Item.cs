using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : ScriptableObject
{

    public Transform player;
    Transform itemTransform;

    public Sprite icon;
    new public string name;

    bool isPickedUp;
    public bool isConsumable;
    public bool isStackable;

    public float pickUpRadius;
    public bool hasBeenClicked;

    float distance;
    
    // Start is called before the first frame update
    void Start()
    {
        pickUpRadius = 1f;
        player = GameObject.Find("Player").transform;
        hasBeenClicked = false;
    }

    public virtual void Use()
    {

        //Something happens
        Debug.Log("You have used " + name);

    }


    private void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(itemTransform.position, pickUpRadius);
    }
}
