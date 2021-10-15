using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Player;

    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if(Player.transform.position.x - gameObject.transform.position.x <= 25f || 
            Player.transform.position.y - gameObject.transform.position.y <= 25f ||
            Player.transform.position.z - gameObject.transform.position.z <= 25f)
        {
            Seek(Player.transform.position);
        }

        if(agent.speed >= 0.5)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }
    }
    void Seek(Vector3 player)
    {
        agent.SetDestination(player);
    }
}