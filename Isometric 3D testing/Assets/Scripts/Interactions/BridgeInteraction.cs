using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BridgeInteraction : InteractablePuzzleObject
{

    GameObject bridgeBroken;
    GameObject bridge;

    void Start()
    {
        requirementsDone = false;
        bridgeBroken = gameObject.transform.GetChild(0).gameObject;
        bridge = gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkRequirements())
        {
            Interacted();
        }
        Debug.Log(checkRequirements());
    }

    public override void Interacted()
    {
        bridgeBroken.SetActive(false);
        bridge.SetActive(true);
    }

    public override bool checkRequirements()
    {
        if(Inventory.instance.items.Any(item => item.name == "Platform") && playerDistance <= interactionRadius && Input.GetKeyDown(KeyCode.E))
        {
            requirementsDone = true;
            return requirementsDone;
        }
        return false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
