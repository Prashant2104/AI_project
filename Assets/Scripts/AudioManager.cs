using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Bulb;
    public GameObject Shoot_gun1;
    public GameObject Shoot_gun2;
    public GameObject Reload;
    public GameObject Interact;
    public void BulbShatter()
    {
        Bulb.GetComponent<AudioSource>().Play();
    }
    public void Shooting_Gun1()
    {
        Shoot_gun1.GetComponent<AudioSource>().Play();
    }
    public void Shooting_Gun2()
    {
        Shoot_gun2.GetComponent<AudioSource>().Play();
    }
    public void Reloading()
    {
        Reload.GetComponent<AudioSource>().Play();
    }
    public void Interacted()
    {
        Interact.GetComponent<AudioSource>().Play();
    }
}
