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
        Debug.Log(_mode);

        switch(_mode)
        {
            case Mode.Idle:
                return;
                break;
            case Mode.Aim:
                Player.Aim(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                break;
            case Mode.Fire:
                Player.Fire(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                break;
        }
    }
}
