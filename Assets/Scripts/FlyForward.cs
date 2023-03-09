using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyForward : MonoBehaviour
{
    private Rigidbody rg;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        speed = Random.Range(3f, 12f);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Wall"){
            transform.position = transform.position + new Vector3(-211, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        rg.velocity = Vector3.right*speed;
    }
}
