using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    new public string name;
    public Sprite icon;
    public float pickUpRadius = 1f;
    public float playerDistance;

    public bool wasClicked = false;

    Material material;

    public virtual void OnPickUp()
    {
        if (playerDistance <= pickUpRadius && wasClicked)
        {
            Debug.Log("You picked up " + name);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        material = GetComponentInChildren<MeshRenderer>().material;
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
        OnPickUp();
    }

    private void OnMouseOver()
    {
        material.SetFloat("_OutlineWidth", 0.051f);
    }

    private void OnMouseExit()
    {
        material.SetFloat("_OutlineWidth", 0f);
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, pickUpRadius);
    }
}
