using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacleObject;

    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private float startDelay = 2f;
    private float repeatRate = 4f;
    private PlayerControllerScript pcScript;

    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerControllerScript>();
        InvokeRepeating("SpawnObject", startDelay, repeatRate);        
    }

    void SpawnObject()
    {
        if (pcScript.gameOver == false)
        {
            Instantiate(obstacleObject, spawnPosition, obstacleObject.transform.rotation);
        }
               
    }
}
