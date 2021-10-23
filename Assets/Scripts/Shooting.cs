using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public GunMuzzleFlash muzzleFlash;

    public AudioManager audioManager;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            muzzleFlash.StopFiring();
        }
    }

    public void Shoot()
    {
        GameObject Bullet = BulletPool.SharedInstance.GetPooledObjects();
        if (Bullet != null)
        {
            Bullet.transform.position = transform.position;
            Bullet.transform.rotation = transform.rotation;
            Bullet.SetActive(true);
            muzzleFlash.StartFiring();
            audioManager.Shooting_Gun1();
        }
    }
}