using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {

	public float Speed = 15;

	private Rigidbody2D _rigidbody2D;

	// Use this for initialization
	void Start () {
		_rigidbody2D = gameObject.GetComponent<Rigidbody2D> ();
		_rigidbody2D.velocity = transform.forward * Speed;
	}
}
