using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    //public Vector3 InitialPos, CurrentPos;
    //public float speed;

    public float Health;
    private GameManager GM;

    void Start()
    {
        GM = FindObjectOfType<GameManager>();

        if (gameObject.CompareTag("Zombie"))
        {
            Health = Random.Range(2, 9);
        }
    }
    /*void FixedUpdate()
    {
        transform.Translate(speed, 0, 0);
        CurrentPos.x += speed;

        if(CurrentPos.x >= InitialPos.x + 10f)
        {
            speed = -speed;
        }
        else if (CurrentPos.x <= InitialPos.x - 10f)
        {
            speed = -speed;
        }
    }*/

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            /*if(gameObject.CompareTag("Zombie"))
            {
                GM.ZombiesKilled++;
            }
            if(gameObject.CompareTag("Civilian"))
            {
                GM.GameOverPanel.SetActive(true);
            }*/
            gameObject.SetActive(false);
        }
    }
}