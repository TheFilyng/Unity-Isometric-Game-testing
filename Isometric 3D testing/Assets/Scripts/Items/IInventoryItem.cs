using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem
{

    string Name { get; }
    Sprite icon { get;}

    float pickUpRadius { get;}
    float playerDistance { get; }

    void OnPickUp();

}
