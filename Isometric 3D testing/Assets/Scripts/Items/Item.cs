using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IInventoryItem
{
    public string _name;
    public string Name
    {
        get
        {
            return _name;
        }
    }
    public Sprite _icon;
    public Sprite icon
    {
        get
        {
            return _icon;
        }
    }
    public float _pickUpRadius = 1f;
    public float pickUpRadius
    {
        get
        {
            return _pickUpRadius;
        }
    }

    

    public float _playerDistance;
    public float playerDistance
    {
        get
        {
            return _playerDistance;
        }
    }

    public void OnPickUp()
    {
        Debug.Log("You picked up " + Name);
        Destroy(gameObject);
    }

    void Start()
    {
        _playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        _playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}
