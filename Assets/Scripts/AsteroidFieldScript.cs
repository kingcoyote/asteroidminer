using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidFieldScript : MonoBehaviour {

    public List<GameObject> Asteroids;
    public float SpawnRate;
    public float SpawnTimer = 2.0f;
    public float SpawnIncrease = 1.005f;

    private float _nextSpawn;
    private BoxCollider2D _boxCollider;
    private float _nextSpawnSpeedup;

    // Use this for initialization
    void Start () {
        _nextSpawn = 1 / SpawnRate;
        _boxCollider = gameObject.GetComponent<BoxCollider2D> ();
        _nextSpawnSpeedup = SpawnTimer;
    }
    
    // Update is called once per frame
    void Update () {
        _nextSpawn -= Time.deltaTime;
        if (_nextSpawn < 0) {
            SpawnAsteroid ();
            _nextSpawn = 1 / SpawnRate;
        }
        _nextSpawnSpeedup -= Time.deltaTime;
        if (_nextSpawnSpeedup < 0) {
            _nextSpawnSpeedup = SpawnTimer;
            SpawnRate *= SpawnIncrease;
        }
    }

    private void SpawnAsteroid() {
        var loc = new Vector2 (
            _boxCollider.bounds.min.x + Random.Range (0.0f, _boxCollider.bounds.size.x), 
            _boxCollider.bounds.min.y + Random.Range (0.0f, _boxCollider.bounds.size.y)
        );
        var dir = new Vector2 (-1, Random.Range (-0.33f, 0.33f));
        var speed = Random.Range (3, 5);

        var asteroid = Instantiate (Asteroids [Random.Range (0, Asteroids.Count - 1)]);
        asteroid.transform.parent = transform;
        asteroid.transform.position = loc;
        asteroid.GetComponent<Rigidbody2D>().velocity = dir * speed;
    }
}
