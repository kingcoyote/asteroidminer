using UnityEngine;

public class FloatingTextScript : MonoBehaviour
{
    public int Number;
    public Color Color;
    public float Speed = 0.01f;
    public float Lifetime = 2;

    private UnityEngine.UI.Text _text;
    private double _alpha = 1.0f;

	// Use this for initialization
	public void Start ()
	{
        Debug.Log(transform.position);
	    _text = gameObject.GetComponent<UnityEngine.UI.Text>();
        _text.color = Color;
        _text.text = Number.ToString("+#;-#");
	    //var pos = Camera.main.WorldToScreenPoint(transform.position);
        //transform.eulerAngles = new Vector3(0, 0, 0);
	    transform.SetParent(GameObject.Find("/Canvas").transform);
	    //transform.position = pos;
        if (Lifetime > 0)
	    Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	public void Update ()
	{
        transform.position += new Vector3(0, 1, 0) * Speed * Time.deltaTime;
	    //_alpha -= Time.deltaTime*0.5f;
	    _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, (float)_alpha);
	}
}
