using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public Transform Bullet;
    
    // Update is called once per frame
    public void Update ()
    {
        var vectorDelta = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var angle = (90 + Mathf.Atan2(vectorDelta.y, vectorDelta.x) * Mathf.Rad2Deg) % 360;
        if (angle > 135 ) angle = 135;
        if (angle < 45) angle = 45;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }

    public void Fire() {
        var b = Instantiate(Bullet) as Transform;
        b.transform.up = transform.right;
        b.transform.position = transform.position;
        Destroy(b.gameObject, 5.0f);
    }
}
