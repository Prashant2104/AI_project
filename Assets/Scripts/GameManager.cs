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

    public GameObject BookPanel;

    public GameObject Flashlight;
    public bool IsFlashOn;

    public Text ReloadText;

    public bool IsPaused;
    public bool instruction;
    public bool IsSoundOn;
    public GameObject PausePanel;
    public GameObject InstructionsPanel;
    public GameObject AudioCam;
    public CharacterController PlayerCtrl;

    void Start()
    {
        Flashlight.SetActive(true);
        PlayerGun_1.SetActive(false);
        PlayerGun_2.SetActive(false);
        PoolAim.SetActive(false);
        BookPanel.SetActive(false);
        PausePanel.SetActive(false);
        ReloadText.enabled = false;

        IsFlashOn = true;
        IsPaused = false;
        instruction = false;
        IsSoundOn = true;
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

        if (Input.GetKeyDown(KeyCode.Escape) && BookPanel.activeInHierarchy == false)
        {
            InstructionsPanel.SetActive(false);
            IsPaused = !IsPaused;
            PausePanel.SetActive(IsPaused);
        }
        if (IsPaused)
        {
            PlayerCtrl.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            PlayerCtrl.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false; ;
        }

        if (IsPaused == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) && BookPanel.activeInHierarchy == true)
            {
                BookPanel.SetActive(false);
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
    public void OnResetButtonClick()
    {
        SceneManager.LoadScene(0);
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void ToggleSFXButton()
    {
        IsSoundOn = !IsSoundOn;
        AudioCam.GetComponent<AudioListener>().enabled = IsSoundOn;
    }
    public void PauseButton()
    {
        instruction = false;
        IsPaused = false;
        PausePanel.SetActive(false);
    }
    public void InstructionsButton()
    {
        instruction = !instruction;
        InstructionsPanel.SetActive(instruction);
    }
}