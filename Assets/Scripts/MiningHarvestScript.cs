using UnityEngine;

public class MiningHarvestScript : MonoBehaviour {

    private PlayerScript _player;
    private AudioSource _audio;

	// Use this for initialization
	public void Start () {
        _player = gameObject.transform.parent.GetComponent<PlayerScript>();
	    _audio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInChildren<MineralScript>() != null)
        {
            _player.Money += other.gameObject.GetComponentInChildren<MineralScript>().Value;
            _audio.PlayOneShot(_audio.clip);
            Destroy(other.gameObject);
        }
    }
}
