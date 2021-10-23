using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxes : Interactable
{
    GameManager GM;
    public AudioManager audioManager;

    private void Start()
    {
        GM = FindObjectOfType<GameManager>();
    }
    public override void Interact(GameObject Actor)
    {
        base.Interact(Actor);
        Interacted();
    }

    void Interacted()
    {
        if (GM.IsPaused == false)
        {
            if (gameObject.CompareTag("Gun1"))
            {
                GM.GunCollected_1 = true;
                GM.GunCollected_2 = false;
            }
            if (gameObject.CompareTag("Gun2"))
            {
                GM.GunCollected_1 = false;
                GM.GunCollected_2 = true;
            }
            if (gameObject.CompareTag("Book"))
            {
                GM.BookPanel.SetActive(true);
            }
            //gameObject.SetActive(false);
            audioManager.Interacted();
        }
    }
}