using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidsSpawnlv3 : MonoBehaviour
{
    public Transform asteroids;
    public int fieldRadius = 10;
    public int AsteroidCount = 30;
    public int WaveCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<WaveCount; i++)
            Invoke("generateAsteroid", 2*i);

    }


    private void generateAsteroid()
    {
        Vector3 t = transform.position;
        t.y = 0f;
        for (int i=0; i<AsteroidCount; i++){
            Vector3 x = new Vector3(
            Random.Range(0, 0),
            Random.Range(0, 0),
            Random.Range(-110,110)
            );
            Transform temp = Instantiate(asteroids, t+x, Random.rotation);
            temp.localScale = temp.localScale * Random.Range(0.5f, 1.5f);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
