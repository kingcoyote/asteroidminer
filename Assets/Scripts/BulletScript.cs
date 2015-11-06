using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float Speed = 5;

	// Use this for initialization
	public void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Speed;
	}

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Asteroids"))
        {
            other.gameObject.GetComponent<AsteroidScript>().Health -= 1;
            other.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(gameObject.GetComponent<Rigidbody2D>().velocity * Speed * Speed, gameObject.transform.position);
            Destroy(gameObject);
        }
    }
}
