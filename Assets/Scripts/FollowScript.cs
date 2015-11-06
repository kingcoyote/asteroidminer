using UnityEngine;
using System.Collections;

public class FollowScript : MonoBehaviour
{

    public Transform Target;
    private Vector3 _offset;

	// Use this for initialization
	void Start ()
	{
	    _offset = gameObject.transform.position - Target.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    gameObject.transform.position = Target.position + _offset;
	}
}
