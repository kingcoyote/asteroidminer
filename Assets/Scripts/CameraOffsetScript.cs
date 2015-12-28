using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraOffsetScript : MonoBehaviour
{

    public int ScreenOffset;
    public enum SideT {Top,Bottom,Left,Right}

    public SideT Side;

	// Use this for initialization
	public void Start () {
	    switch (Side)
	    {
	        case SideT.Top:
                transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight - ScreenOffset, 0)).y, 0);
	            break;
            case SideT.Bottom:
                transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(new Vector3(0, ScreenOffset, 0)).y, 0);
	            break;
            case SideT.Left:
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(ScreenOffset, 0, 0)).x, transform.position.y, 0);
	            break;
            case SideT.Right:
                transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth - ScreenOffset, 0, 0)).x, transform.position.y, 0);
	            break;
	    }
	}

    public void Update()
    {
        if (Application.isEditor)
        {
            Start();
        }
    }
}
