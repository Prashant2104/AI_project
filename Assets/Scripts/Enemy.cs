using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform currentObject;
    public Transform goalObject;
    public float speed;
    public float closeEnoughDistance = 1f;
    //public float turnspeed = 3f;
    //public float smoothmoveTime = 0.1f;

    //float angle;
    //Vector3 Velocity;
    //float smoothinputMagnitude;
    //float smoothmoveVelocity;

    private Animator anim;
    private Rigidbody rb;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }

    void Update()
    {
        float distanceToGoal = Vector3.Distance(currentObject.position, goalObject.position);
        Vector3 goalDirection = (currentObject.position - goalObject.position).normalized;
        transform.LookAt(goalObject.gameObject.transform);

        /*float InputMagnitude = goalDirection.magnitude;
        smoothinputMagnitude = Mathf.SmoothDamp(smoothinputMagnitude, InputMagnitude, ref smoothmoveVelocity, smoothmoveTime);
        float targetAngle = Mathf.Atan2(goalDirection.x, goalDirection.z) * Mathf.Rad2Deg;
        angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnspeed * InputMagnitude);
        Velocity = transform.forward * speed * smoothinputMagnitude;*/

        if (Mathf.Abs(distanceToGoal) > closeEnoughDistance)
        {
            currentObject.Translate(goalDirection * Time.deltaTime * speed);
        }

        if(speed >= 0.01)
        {
            anim.SetBool("Walk", true);
        }
        else if (speed < 0.01)
        {
            anim.SetBool("Walk", false);
        }

        if (speed >= 2)
        {
            anim.SetBool("Run", true);
        }
        else if (speed < 2)
        {
            anim.SetBool("Run", false);
        }
    }
    /*private void FixedUpdate()
    {
        rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
        rb.MovePosition(rb.position + Velocity * Time.deltaTime);
    }*/

    /*private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.SetActive(false);
            //Destroy(this.gameObject);
        }
    }*/
}