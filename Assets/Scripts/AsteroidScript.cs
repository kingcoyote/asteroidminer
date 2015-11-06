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
        foreach (var mineral in Minerals)
        {
            
        }

        Destroy(gameObject);
    }
}
