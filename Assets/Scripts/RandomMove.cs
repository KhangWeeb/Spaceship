using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{   
    private GameObject go;
    public float minThrust = .1f;
    public float maxThrust = .5f;
    private Rigidbody rg;
    private float spin;
    private Vector3 spawnPoint;
    private Vector3 temp;
    // Start is called before the first frame update
    void Start()
    {
        go = GameObject.Find("AsteroidSpawnLv2");
        spawnPoint = new Vector3(-317.8f, 0, 194.7f);
        spin = Random.Range(1f, 5f);
        float thrust = Random.Range(minThrust, maxThrust);
        rg = GetComponent<Rigidbody>();
        temp = new Vector3(
            Random.Range(-5, 5),
            Random.Range(0,0),
            Random.Range(-5,5)
            );
    }

    private void OnCollisionEnter(Collision other) {
        temp = -temp;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, spin * Time.deltaTime);
        rg.velocity = temp;
        float dist = Vector3.Distance(transform.position, go.transform.position);
        if (dist >= 115){
            //rg.velocity = Vector3.MoveTowards(transform.position, spawnPoint, 1*Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, go.transform.position, 5*Time.deltaTime);
            //rg.AddForce(Vector3.MoveTowards(transform.position, go.transform.position, 5*Time.deltaTime));
        }
    }
}
