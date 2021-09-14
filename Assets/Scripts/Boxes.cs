using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : Interactable
{
    public override void Interact(GameObject Actor)
    {
        base.Interact(Actor);
        ChangeColor();
    }

    void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 255);
        gameObject.SetActive(false);
    }
}