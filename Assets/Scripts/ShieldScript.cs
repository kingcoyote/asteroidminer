using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class ShieldScript : MonoBehaviour
{

    private PlayerScript _player;
    private SpriteRenderer _renderer;

    // Use this for initialization
    public void Start ()
    {
        _player = transform.parent.GetComponentInChildren<PlayerScript>();
        _renderer = gameObject.GetComponent<SpriteRenderer>();

        _renderer.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<AsteroidScript>() != null)
        {
            if (_player.IsShieldActive())
            {
                _player.ShieldPercent -= ((float)(other.gameObject.GetComponent<AsteroidScript>().Health) / _player.Shields);
                Destroy(other.gameObject);
                StartCoroutine(Flicker());
            }
        }
    }

    private IEnumerator Flicker()
    {
        _renderer.enabled = true;
        yield return new WaitForSeconds(Random.Range(0.2f, 0.3f));
        _renderer.enabled = false;
    }
}
