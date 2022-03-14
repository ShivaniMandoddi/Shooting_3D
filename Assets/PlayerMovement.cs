using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerSpeed;
    public float rotationSpeed;
    Rigidbody rb;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    float time;
    public AudioClip audioClip;
    AudioSource source;
    public AudioClip bulletSound;
    AudioSource bulletAudioSource;
    public bool IsGameOver = false;
    public Text gameOver;
    GameObject bullet;
    public Button quit;
    public Button restart;

    void Start()
    {

        //rb.useGravity = false;
        source = GetComponent<AudioSource>();
        quit.onClick.AddListener(Quit);
        restart.onClick.AddListener(Restart);


    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsGameOver == false)
        {
            float inputZ = Input.GetAxis("Vertical") * playerSpeed;
            float inputX = Input.GetAxis("Horizontal") * playerSpeed;
            if (inputX != 0 || inputZ != 0)
            {
                source.clip = audioClip;
                source.Play();
            }
            transform.Translate(inputX * Time.deltaTime, 0, 0);

            transform.Translate(0, 0, inputZ * Time.deltaTime);
            //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, inputZ);
            //transform.rotation = transform.rotation * Quaternion.Euler(inputZ * rotationSpeed, 0,0); //Rotating player in y direction
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bullet = Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
                bulletAudioSource = bullet.GetComponent<AudioSource>();
                bulletAudioSource.clip = bulletSound;
                bulletAudioSource.Play();
                rb = bullet.GetComponent<Rigidbody>();
                rb.velocity = transform.rotation * (Vector3.forward * bulletSpeed);
                StartCoroutine("Destroy"); 

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

    private void Restart()
    {
        SceneManager.LoadScene(1);
    }
   
    private void Quit()
    {
        SceneManager.LoadScene(0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Debug.Log("Game Over!!");
            IsGameOver = true;
            gameOver.text = "Game Over!!";
            quit.gameObject.SetActive(true);
            restart.gameObject.SetActive(true);
        }
    }
    IEnumerator Destroy()
    {
        yield return (new WaitForSeconds(3f));
        Destroy(bullet);
    }
    
}
