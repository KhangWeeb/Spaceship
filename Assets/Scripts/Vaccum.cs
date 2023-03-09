using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaccum : MonoBehaviour
{
    public float strength;
    Rigidbody rb;

    private void OnTriggerStay(Collider other) 
   {
        if (other.gameObject.tag == "vacuum"){
            Vector3 t = new Vector3(other.transform.position.x-transform.position.x, 0, other.transform.position.z-transform.position.z);
            //Debug.Log(t);
            rb.AddForce(t*0.1f);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == "vacuum"){
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
