using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

    public Transform Bullet;

    private AudioSource _audio;

    public void Start()
    {
        _audio = gameObject.GetComponent<AudioSource>();
    }

    public void Fire() {
        var b = Instantiate(Bullet) as Transform;
        b.transform.up = transform.right + new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f));
        b.transform.position = transform.position;
        _audio.PlayOneShot(b.GetComponent<AudioSource>().clip);
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
