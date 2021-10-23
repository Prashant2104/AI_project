using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFlashlight : MonoBehaviour
{
    public GameObject FlashLight;
    public bool IsLightOn;
    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        IsLightOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLightOn)
        {
            FlashLight.SetActive(true);
        }
        else
        {
            FlashLight.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            IsLightOn = !IsLightOn;
            audioManager.Interacted();
        }
    }
}
