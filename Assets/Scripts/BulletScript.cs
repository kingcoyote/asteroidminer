using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    public float Speed = 5;
    public Transform HitParticles;

    // Use this for initialization
    public void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Speed;
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Asteroids"))
        {
            other.gameObject.GetComponent<AsteroidScript>().Health -= 1;
            other.gameObject.GetComponent<Rigidbody2D>().AddForceAtPosition(
                gameObject.GetComponent<Rigidbody2D>().velocity * Speed * Speed, 
                gameObject.transform.position
            );
            var hit = Instantiate(HitParticles);
            hit.transform.position = transform.position;
            var vectorDelta = other.transform.position - transform.position;
            var angle = 90 + Mathf.Atan2(vectorDelta.y, vectorDelta.x) * Mathf.Rad2Deg;
            hit.transform.localEulerAngles = new Vector3(0, 0, angle);
            hit.transform.parent = null;
            Destroy(hit.gameObject, 2.5f);
            Destroy(gameObject);
        }
    }

    public void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
