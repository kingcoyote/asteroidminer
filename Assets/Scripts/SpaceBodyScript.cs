using UnityEngine;
using System.Collections;

public class SpaceBodyScript : MonoBehaviour {

    public float Speed;
    public Vector2 Direction;

    private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	public void Start () {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Direction = Direction.normalized;
	}

    public void FixedUpdate()
    {
        _rigidbody2D.velocity = Direction * Speed;
    }
}
