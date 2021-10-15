using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject PoolAim;

    public bool GunCollected_1;
    public bool GunCollected_2;

    public GameObject Gun_1;
    public GameObject Gun_2;

    public GameObject PlayerGun_1;
    public GameObject PlayerGun_2;

    public GameObject Flashlight;
    public bool IsFlashOn;

    public bool Puzzle1, Puzzle2, Puzzle3;

    void Start()
    {
        Flashlight.SetActive(true);
        PlayerGun_1.SetActive(false);
        PlayerGun_2.SetActive(false);
        PoolAim.SetActive(false);

        IsFlashOn = true;
        Puzzle1 = false;
        Puzzle2 = false;
        Puzzle3 = false;

    }

    void Update()
    {
        if (GunCollected_1 == false && GunCollected_2 == false)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                IsFlashOn = !IsFlashOn;
                Flashlight.transform.GetChild(0).gameObject.SetActive(IsFlashOn);
            }
        }

        if (GunCollected_1)
        {
            Gun_1.SetActive(false);
            Gun_2.SetActive(true);
            GunCollected_2 = false;
            Flashlight.SetActive(false);
            PlayerGun_1.SetActive(true);
            PlayerGun_2.SetActive(false);
            PoolAim.SetActive(true);
        }
        else if(GunCollected_2)
        {
            Gun_2.SetActive(false);
            Gun_1.SetActive(true);
            GunCollected_1 = false;
            Flashlight.SetActive(false);
            PlayerGun_2.SetActive(true);
            PlayerGun_1.SetActive(false);
            PoolAim.SetActive(false);
        }
    }
}