using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class EnemyLauncher : MonoBehaviour
{
    // Start is called before the first frame update
    float time;
    public GameObject enemyPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
        if(time>2f)
        {
            Vector3 position = GetPosition();
            //Debug.Log(position);
            Instantiate(enemyPrefab, position, Quaternion.identity);
            time = 0f;
        }
    }

    private Vector3 GetPosition()
    {
   
        float[] zPosition = { UnityEngine.Random.Range(-12f, -2f), UnityEngine.Random.Range(4f, 11f) };//, UnityEngine.Random.Range(4f, 11f));
        int index = UnityEngine.Random.Range(0, 2);
        return (new Vector3(UnityEngine.Random.Range(-43f, 48f), 0,zPosition[index]));
    }
}
