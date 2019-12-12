using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractablePuzzleObject : MonoBehaviour
{

    public bool requirementsDone;
    public float playerDistance;
    public float interactionRadius = 2f;

    private void Start()
    {
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    private void Update()
    {
        playerDistance = Vector3.Distance(GameObject.Find("Player").transform.position, transform.position);
    }

    public abstract void Interacted();
    public abstract bool checkRequirements();

}
