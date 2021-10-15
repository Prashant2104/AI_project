using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image Cross;
    public Image Reticle;
    public GameObject CrossHair;
    public Transform ShootPoint;

    public float Range;

    public Transform Gun;
    public Transform cam;

    float BulletsLeft;

    private BulletPool pool;

    void Start()
    {
        pool = FindObjectOfType<BulletPool>();

        Reticle.color = new Color(255, 255, 255, 255);
        Cross.color = new Color(0, 0, 255, 200);
        BulletsLeft = pool.AmountToPool;
    }

    void Update()
    {
        RotateGun();

        RayCasting();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        /*if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }*/

        Cross.fillAmount = (float)(BulletsLeft / pool.AmountToPool);
    }

    void RotateGun()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, Range))
        {
            if (hitInfo.transform.CompareTag("Zombie"))
            {
                Vector3 direction = hitInfo.point - Gun.position;
                Gun.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    void Shoot()
    {
        GameObject Bullet = BulletPool.SharedInstance.GetPooledObjects();
        if (Bullet != null)
        {
            BulletsLeft--;
        }
    }
    /*IEnumerator Reload()
    {
        //audioManager.Reloading();
        yield return new WaitForSeconds(0.65f);
        BulletsLeft = pool.AmountToPool;
    }*/

    void RayCasting()
    {
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            var Target = hit.transform;
            if (Target.CompareTag("Zombie"))
            {
                Reticle.color = new Color(255, 0, 0, 255);
                Cross.color = new Color(255, 0, 0, 200);
            }
            else if (Target.CompareTag("Target"))
            {
                Reticle.color = new Color(0, 255, 0, 255);
                Cross.color = new Color(0, 255, 0, 200);
            }
            else
            {
                Reticle.color = new Color(255, 255, 255, 255);
                Cross.color = new Color(0, 0, 255, 200);
            }
        }

        Debug.DrawRay(ShootPoint.position, ShootPoint.forward * Range, Color.green);
    }
}