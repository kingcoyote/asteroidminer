using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public Transform Bullet;

    public void Fire(Vector3 target) {
        Aim(target);

        var b = Instantiate(Bullet) as Transform;
        b.transform.up = transform.right + new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        b.transform.position = transform.position;
        Destroy(b.gameObject, 5.0f);
    }

    public void Aim(Vector3 target) {
        var vectorDelta = target - transform.position;
        var angle = (90 + Mathf.Atan2(vectorDelta.y, vectorDelta.x) * Mathf.Rad2Deg) % 360;
        if (angle > 135) angle = 135;
        if (angle < 45) angle = 45;
        transform.localEulerAngles = new Vector3(0, 0, angle);
    }
}
