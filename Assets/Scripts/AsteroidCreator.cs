using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCreator : MonoBehaviour
{
    GameObject ship;
    float time = 0.0f;
    float interval = 0.1f;
    float spawnDistance = 50.0f;
    public GameObject Asteroid1;
    public GameObject Asteroid2;
    public GameObject Asteroid3;


    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.Find("PlayerShip");
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > interval)
        {
            spawnAsteroid();
            time = 0.0f;
        }
    }

    void spawnAsteroid()
    {
        Vector3 shipLocation = ship.transform.position;
        Vector3 spawnLocation = new Vector3(Random.Range(-20, 20), Random.Range(-20, 20), shipLocation.z + spawnDistance);
        int randomNumber = Random.Range(1, 4);
        if(randomNumber == 1)
        {
            Instantiate(Asteroid1, spawnLocation, Quaternion.identity);
        }
        else if(randomNumber == 2)
        {
            Instantiate(Asteroid2, spawnLocation, Quaternion.identity);
        }
        else
        {
            Instantiate(Asteroid3, spawnLocation, Quaternion.identity);
        }
    }
}

