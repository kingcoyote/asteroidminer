using UnityEngine;

[ExecuteInEditMode]
public class PlayerCameraScript : MonoBehaviour
{
    public void Start()
    {
        transform.position = new Vector3(Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + 1, transform.position.y, transform.position.z);
    }

	public void Update () {
        if (Application.isEditor)
        {
            Start();
        }
	}
}
