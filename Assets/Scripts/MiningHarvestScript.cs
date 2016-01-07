using UnityEngine;

public class MiningHarvestScript : MonoBehaviour {

    private PlayerScript _player;
    private AudioSource _audio;

    public FloatingTextScript FloatingText;
    private FloatingTextScript _ft;

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
            if (_ft == null)
            {
                _ft = Instantiate(FloatingText, Camera.main.WorldToScreenPoint(transform.position), new Quaternion(0, 0, 0, 0)) as FloatingTextScript;
                _ft.Immortal = false;
            }

            _ft.Number += (other.gameObject.GetComponentInChildren<MineralScript>().Value);

            _player.Money += other.gameObject.GetComponentInChildren<MineralScript>().Value;
            _audio.PlayOneShot(_audio.clip);
            Destroy(other.gameObject);
        }
    }
}
