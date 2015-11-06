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
            var m = Instantiate(mineral);
            m.position = transform.position + new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0);
            m.gameObject.GetComponent<SpaceBodyScript>().Direction =
                gameObject.GetComponent<SpaceBodyScript>().Direction + new Vector2(Random.Range(-1, 1), 0);
            m.gameObject.GetComponent<SpaceBodyScript>().Speed =
                gameObject.GetComponent<SpaceBodyScript>().Speed + Random.Range(0, 1.0f);
        }

        Destroy(gameObject);
    }
}
