using UnityEngine;
using System.Collections;

public class MiningHarvestScript : MonoBehaviour {

    private PlayerScript _player;

	// Use this for initialization
	void Start () {
        _player = gameObject.transform.parent.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInChildren<MineralScript>() != null)
        {
            _player.Money += other.gameObject.GetComponentInChildren<MineralScript>().Value;
            Destroy(other.gameObject);
        }
    }
}
