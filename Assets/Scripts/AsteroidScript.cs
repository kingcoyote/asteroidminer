using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidScript : MonoBehaviour {

    public List<Transform> Minerals;
    public List<Transform> SubAsteroids;
    public GameObject DeathAnimation;
    public int Health;

    // Use this for initialization
    public void Start () {
        Destroy (gameObject, 20);
    }

    public void Update()
    {
        if (Health <= 0)
        {
            DestroyAsteroid();
        }
    }

    public void OnBecameInvisible() {
        Destroy (gameObject);
    }

    private void DestroyAsteroid()
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        var mass = rb.mass;
        var mineralCount = (int)(Random.Range(mass/4, mass) / 100);

        for (var i = 0; i < mineralCount; i++)
        {
            var mineral = Instantiate(Minerals[Random.Range(0, Minerals.Count - 1)]);
            mineral.position = transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 0);
            mineral.GetComponent<Rigidbody2D>().velocity = rb.velocity + new Vector2(Random.Range(-0.5f, 0f), Random.Range(-0.5f, 0.5f));
        }

        foreach (var a in SubAsteroids)
        {
            var asteroid = Instantiate(a);
            asteroid.position = transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 0);
            asteroid.GetComponent<Rigidbody2D>().velocity = rb.velocity + new Vector2(Random.Range(-0.5f, 0f), Random.Range(-0.5f, 0.5f));
        }

        SpawnDeathAnimation();

        Destroy(gameObject);
    }

    public void SpawnDeathAnimation()
    {
        var da = Instantiate(DeathAnimation, transform.position, new Quaternion(0, 0, 0, 0)) as GameObject;
        da.transform.parent = null;
        da.GetComponent<AudioSource>().Play();
        da.GetComponentInChildren<ParticleSystem>().maxParticles = (int)(gameObject.GetComponent<Rigidbody2D>().mass/10.0f);

        Destroy(da, 3);
    }
}
