using UnityEngine;

public class TurretAimScript : MonoBehaviour
{

    public PlayerScript Player;

    private Mode _mode = Mode.Idle;

    private enum Mode
    {
        Idle,
        Aim,
        Fire
    };

    public void OnMouseDown()
    {
        _mode = Mode.Fire;
    }

    public void OnMouseUp()
    {
        _mode = Mode.Aim;
    }

    public void OnMouseEnter()
    {
        _mode = Input.GetButton("Fire1") ? Mode.Fire : Mode.Aim;
    }

    public void OnMouseExit()
    {
        _mode = Mode.Idle;
    }

    public void Update()
    {
        switch(_mode)
        {
            case Mode.Idle:
                break;
            case Mode.Aim:
                Player.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                break;
            case Mode.Fire:
                Player.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Player.Fire();
                break;
        }
    }
}
