using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HitWall : MonoBehaviour
{   
    public static bool isCrash;
    public AudioClip explosion;
    public ParticleSystem explode;
    AudioSource audioSource;
    MeshRenderer meshrender;
    Rigidbody rb;
    private bool cheat;

    private void Start() {
        cheat = false;
        isCrash = false;
        audioSource = GetComponent<AudioSource>();
        meshrender = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.C))
            cheat = !cheat;
    }

    private void whenCrash()
    {
        if (isCrash == true)
            return;
        
        rb.constraints = RigidbodyConstraints.FreezePosition;
        audioSource.Stop();
        audioSource.PlayOneShot(explosion);
        explode.Play();
        meshrender.enabled = false;
        isCrash = true;
    }

    private void OnCollisionEnter(Collision other) {
        if (cheat == true)
            return;
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Obstacles"){
            whenCrash();
        }
    }
}
