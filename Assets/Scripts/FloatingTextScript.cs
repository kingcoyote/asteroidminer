using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public int Number;
    public Color Color;
    public float Speed = 0.01f;
    public bool Immortal = false;

    private UnityEngine.UI.Text _text;
    private double _alpha = 1.0f;

	// Use this for initialization
	public void Start ()
	{
	    _text = gameObject.GetComponent<UnityEngine.UI.Text>();
        _text.color = Color;
	    transform.SetParent(GameObject.Find("/Canvas").transform);
        transform.position += new Vector3(Random.Range(-50, 50), 0, 0);
        if (!Immortal)
	        Destroy(gameObject, 0.75f);
	}
	
	// Update is called once per frame
	public void Update ()
	{
        _text.text = Number.ToString("+#;-#");
        transform.position += new Vector3(0, 1, 0) * Speed * Time.deltaTime;
	    _alpha -= Time.deltaTime*0.5f;
	    _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, (float)_alpha);
	}
}
