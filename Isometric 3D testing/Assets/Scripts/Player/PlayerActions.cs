﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerActions : MonoBehaviour
{
    Camera cam;
    NavMeshAgent agent;

    void Start()
    {
        cam = Camera.main;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        PickUpItem();

    }

    void MovePlayer()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                agent.SetDestination(hit.point);
            }
        }
    }

    void PickUpItem()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Item clickedItem = hit.collider.GetComponent<Item>();
                if (clickedItem != null)
                {
                    agent.SetDestination(hit.point);
                    Inventory.instance.AddItem(clickedItem);
                    clickedItem.wasClicked = true;
                }
            }
        }
    }
}
