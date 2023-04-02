using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    private float obstacleSpeed = 5;
    //private float leftBound = -15;
    private PlayerControllerScript pcScript;

    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerControllerScript>();  
    }

    void Update()
    {
        if (pcScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * obstacleSpeed);
        }
        //if (transform.position.x < leftBound && gameOject.CompareTag("ObstaclePrefab"))
        //{
        //    Destroy(gameObject);
        //}
    }

}
