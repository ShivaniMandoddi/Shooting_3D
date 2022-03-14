using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class EnemyLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public GameObject enemyPrefab;
    //GameObject player;
    PlayerMovement playerMovement;
    Rigidbody rb;

    void Start()
    {

        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.IsGameOver == false)
        {
            time = time + Time.deltaTime;
            if (time > 2f)
            {
                Vector3 position = GetPosition();
                //Debug.Log(position);
                GameObject enemy = Instantiate(enemyPrefab, position, Quaternion.identity);
                //rb = enemy.GetComponent<Rigidbody>();
                //enemy.transform.Translate(position * enemySpeed*Time.deltaTime);
                //rb.velocity=enemy.transform.rotation*(Vector3.forward * enemySpeed);
                enemy.transform.Rotate(0, UnityEngine.Random.Range(0, 270), 0);
                time = 0f;
            }
        }
    }

    private Vector3 GetPosition()
    {
   
        float[] zPosition = { UnityEngine.Random.Range(-12f, -2f), UnityEngine.Random.Range(4f, 11f) };//, UnityEngine.Random.Range(4f, 11f));
        int index = UnityEngine.Random.Range(0, 2);
        return (new Vector3(UnityEngine.Random.Range(-43f, 48f), 0,zPosition[index]));
    }
}
