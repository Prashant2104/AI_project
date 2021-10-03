using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableReticle : MonoBehaviour
{
    public Image Reticle;
    public Transform Gun;

    private Interactable currentObject;
    private float startTime;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Gun.position, Gun.forward);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Interactable i = hit.collider.GetComponent<Interactable>();

            if(i != currentObject)
            {
                startTime = Time.time;
                currentObject = i;
            }
            if(currentObject != null)
            {
                if(Time.time - startTime > 1)
                {
                    currentObject.Interact(Gun.gameObject);
                    startTime = 0;
                    currentObject = null;
                }
                Reticle.enabled = true;
                Reticle.fillAmount = Time.time - startTime;
            }
            else
            {
                Reticle.enabled = false;
            }
        }
        else
        {
            Reticle.enabled = false;
        }
    }
}