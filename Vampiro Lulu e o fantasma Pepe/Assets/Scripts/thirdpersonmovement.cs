using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdpersonmovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float speed = 6f;
    public float turnsmoothtime = 0.1f;
    float turnsmoothvelocity;
    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
       
        if(direction.magnitude >= 0.1f)
        {
            float targetAnngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAnngle, ref turnsmoothvelocity, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 movedir = Quaternion.Euler(0f, targetAnngle, 0f) * Vector3.forward;
            controller.Move(movedir.normalized*speed*Time.deltaTime);
        }
    } 
}
