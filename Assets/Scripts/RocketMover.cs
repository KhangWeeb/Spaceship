using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMover : MonoBehaviour
{
    private new Rigidbody rigidbody;
    public float maxSpeed = 3.0f;
    public float maxRotateSpeed = 2f;
    public ParticleSystem backFlameEngineLeft;
    public ParticleSystem backFlameEngineRight;
    public ParticleSystem frontFlameEngine;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void FixedUpdate() 
    {
        float accel = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        FlyForward(accel);
        Rotate(transform, rotate*maxRotateSpeed);
    }

    private void playParticle(ParticleSystem ptc, bool pl)
    {
        if (!ptc.isPlaying && pl == true)
            ptc.Play();
        else if (pl == false)
            ptc.Stop();
    }

    private void FlyForward(float amount)
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
            rigidbody.velocity += transform.forward*maxSpeed;
            playParticle(backFlameEngineRight, true);
            playParticle(backFlameEngineLeft, true);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
            rigidbody.velocity -= transform.forward*maxSpeed;
            playParticle(frontFlameEngine, true);
        }
        else
        {
            playParticle(backFlameEngineLeft, false);
            playParticle(backFlameEngineRight, false);
            playParticle(frontFlameEngine, false);
        }
        //Vector3 force = transform.forward*amount;
        //rigidbody.velocity += force;
    }

    private void Rotate(Transform x, float amount)
    {
        x.Rotate(0, amount, 0);
    }
}
