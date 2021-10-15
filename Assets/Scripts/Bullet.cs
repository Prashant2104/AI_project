using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;

    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

        /*if(Input.GetKeyDown(KeyCode.R))
        {
            gameObject.SetActive(false);
        }*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
    }
}