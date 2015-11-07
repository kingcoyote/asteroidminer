using UnityEngine;
using System.Collections;

public class MiningScript : MonoBehaviour {

    public float Size;
    public float Force = 1.0f;

    private CircleCollider2D _circle;

    // Use this for initialization
    public void Start () {
        _circle = gameObject.GetComponent<CircleCollider2D>();
        Size = _circle.radius;
    }
    
    // Update is called once per frame
    public void Update () {
        _circle.radius = Size;
    }

    public void OnTriggerStay2D(Collider2D other) {
        other.gameObject.GetComponent<Rigidbody2D>().AddForce((gameObject.transform.position - other.gameObject.transform.position).normalized * Force);
    }
}
