using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HotKeyScript : MonoBehaviour
{
    public KeyCode Key;

    private Button _button;

	// Use this for initialization
	public void Start ()
	{
	    _button = gameObject.GetComponent<Button>();
	}
	
	// Update is called once per frame
	public void Update () {
	    if (Input.GetKeyDown(Key)) _button.onClick.Invoke();
	}
}
