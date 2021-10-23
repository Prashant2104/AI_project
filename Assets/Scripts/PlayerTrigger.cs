using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public GameObject Zombies;
    
    void Start()
    {
        Zombies.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Door"))
            {
                Zombies.SetActive(true);
            }
        }
    }
}
