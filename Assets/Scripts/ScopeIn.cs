using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScopeIn : MonoBehaviour
{
    public Image Cross;
    public Image Reticle;

    public GameObject Cam;
    public GameObject GunCam;

    public bool Scope;

    void Start()
    {
        Scope = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1))
        {
            Scope = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Scope = false;
        }

        if (Scope == true)
        {
            GunCam.GetComponent<Camera>().targetDisplay = 0;
            Cam.GetComponent<Camera>().targetDisplay = 1;
            Cross.enabled = false;
            //Reticle.enabled = false;
        }
        if (Scope == false)
        {
            GunCam.GetComponent<Camera>().targetDisplay = 1;
            Cam.GetComponent<Camera>().targetDisplay = 0;
            Cross.enabled = true;
            //Reticle.enabled = true;
        }
    }
}