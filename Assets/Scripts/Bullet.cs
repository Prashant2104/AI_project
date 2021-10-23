using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletSpeed;
    public float DamageAmount;
    public int ReloadAllowed;

    private int ReloadDone;
    //private Crosshair pool;

    void Start()
    {
        //pool = FindObjectOfType<Crosshair>();
        ReloadDone = 0;
        StartCoroutine(ColliderDisable());
    }

    void Update()
    {
        gameObject.transform.Translate(Vector3.forward * BulletSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadDone++;
            if (ReloadDone <= ReloadAllowed)
            {
                StartCoroutine(Reload());
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.SetActive(false);
        //Debug.Log("Bullet Col: " + collision.gameObject.transform.name);
        TargetController target = collision.gameObject.transform.GetComponent<TargetController>();
        if (target != null)
        {
            //pool.BulletsLeft++;
            target.TakeDamage(DamageAmount);
            //Debug.Log("Bullet: " + target.transform.name);
        }
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator ColliderDisable()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<SphereCollider>().enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}