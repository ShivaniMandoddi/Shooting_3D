using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float rotationSpeed;
    Rigidbody rb;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    float time;
    void Start()
    {
        
        //rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal") * playerSpeed;
        transform.Translate(inputX * Time.deltaTime, 0, 0);
        float inputZ = Input.GetAxis("Vertical") * playerSpeed;
        transform.Translate(0, 0, inputZ * Time.deltaTime);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, inputZ);
        //transform.rotation = transform.rotation * Quaternion.Euler(inputZ * rotationSpeed, 0,0); //Rotating player in y direction
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
            rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = transform.rotation * (Vector3.forward * bulletSpeed);
            time = time + Time.deltaTime;
            if (time > 2f)
            {
                Destroy(bullet);
                time = 0f;
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            //transform.Rotate(0, inputX, 0);
            transform.rotation = transform.rotation * Quaternion.Euler(0, rotationSpeed, 0);
        }
        if (Input.GetKey(KeyCode.N))
        {
            //transform.Rotate(0, inputX, 0);
            transform.rotation = transform.rotation * Quaternion.Euler(0, -rotationSpeed, 0);
        }
        
    }

   
}
