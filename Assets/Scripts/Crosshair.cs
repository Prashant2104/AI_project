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
    public int ReloadAllowed;

    public float Range;

    public Transform Gun;
    public Transform cam;

    public Text ReloadText;
    public float BulletsLeft;

    private int ReloadDone;
    public AudioManager audioManager;
    private BulletPool pool;

    void Start()
    {
        pool = FindObjectOfType<BulletPool>();
        ReloadDone = 0;
        Reticle.color = new Color(255, 255, 255, 255);
        Cross.color = new Color(0, 0, 255, 200);
        BulletsLeft = pool.AmountToPool;
        ReloadText.enabled = false;
    }

    void Update()
    {
        RotateGun();

        RayCasting();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(BulletsLeft > 0)
            {
                BulletsLeft--;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadDone++;
            if(ReloadDone < ReloadAllowed)
                StartCoroutine(Reload());
        }
        if(BulletsLeft < 1)
        {
            ReloadText.enabled = true;
        }

        Cross.fillAmount = (float)(BulletsLeft / pool.AmountToPool);
    }

    void RotateGun()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, Range))
        {
            //Debug.Log("Gun: "+hitInfo.transform.name);
            if (hitInfo.transform.CompareTag("Zombie") || hitInfo.transform.CompareTag("Bulb"))
            {
                Vector3 direction = hitInfo.point - Gun.position;
                Gun.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    /*void Shoot()
    {
        GameObject Bullet = BulletPool.SharedInstance.GetPooledObjects();
        
        if (Bullet != null)
        {
            BulletsLeft--;
        }
    }*/
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(0.5f);
        audioManager.Reloading();
        yield return new WaitForSeconds(1.5f);
        BulletsLeft = pool.AmountToPool;
        ReloadText.enabled = false;
    }

    void RayCasting()
    {
        Ray ray = new Ray(ShootPoint.position, ShootPoint.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, Range))
        {
            var Target = hit.transform;
            if (Target.CompareTag("Zombie") || Target.CompareTag("Bulb"))
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
        //Debug.DrawRay(ShootPoint.position, ShootPoint.forward * Range, Color.green);
    }
}