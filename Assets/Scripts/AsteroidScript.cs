using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidScript : MonoBehaviour {

    public List<Transform> Minerals;
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
        var rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
        var mass = rigidbody2d.mass;
        var mineralCount = (int)(Random.Range(0, mass) / 100);

        for (int i = 0; i < mineralCount; i++)
        {
            var mineral = Instantiate(Minerals[Random.Range(0, Minerals.Count - 1)]);
            mineral.position = transform.position + new Vector3(Random.Range(0f, 0.5f), Random.Range(0f, 0.5f), 0);
            mineral.GetComponent<Rigidbody2D>().velocity = rigidbody2d.velocity + new Vector2(Random.Range(-0.5f, 0f), Random.Range(-0.5f, 0.5f));
        }

        Destroy(gameObject);
    }
}
