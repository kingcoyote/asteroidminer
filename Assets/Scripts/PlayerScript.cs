using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float EngineForce;
    public float GunCooldown = 0.5f;

    public int Money;
    public int Health = 50;
    public int Shields = 50;
    public float HealthPercent = 1.0f;
    public float ShieldPercent = 1.0f;

    public int EngineLevel { get; private set; }
    public int HealthLevel { get; private set; }
    public int ShieldLevel { get; private set; }
    public int WeaponLevel { get; private set; }
    public int MiningLevel { get; private set; }

	private Rigidbody2D _rigidBody2D;
	private TurretScript _turret;
    private float _gunCooldown;
    private MiningScript _mining;

	// Use this for initialization
	public void Start () {
		_rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
		_turret = gameObject.GetComponentInChildren<TurretScript> ();
        _mining = gameObject.GetComponentInChildren<MiningScript>();

	    EngineLevel = 1;
        HealthLevel = 1;
        ShieldLevel = 1;
        WeaponLevel = 1;
        MiningLevel = 1;
	}
	
	// Update is called once per frame
	public void FixedUpdate () {
		var force = new Vector2 (0, Input.GetAxis ("Vertical")) * EngineForce;
		_rigidBody2D.AddForce (force);
	}

	public void Update()
	{
        if (HealthPercent <= 0)
        {
            DestroyPlayer();
        }

        _gunCooldown -= Time.deltaTime;
        if (Input.GetButton("Fire1") && _gunCooldown <= 0)
        {
            _gunCooldown = GunCooldown;
            _turret.Fire();
        }

	    ShieldPercent += 0.025f * Time.deltaTime;
        if (ShieldPercent > 1.0f) ShieldPercent = 1.0f;
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponentInChildren<MineralScript>() != null)
        {
            Money += other.gameObject.GetComponentInChildren<MineralScript>().Value;
            Destroy(other.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponentInChildren<AsteroidScript>() != null)
        {
            HealthPercent -= other.gameObject.GetComponentInChildren<AsteroidScript>().Health / (float)Health;
            Destroy(other.gameObject);
        }
    }

    public bool IsShieldActive()
    {
        return ShieldPercent*Shields > 1;
    }

    public void UpgradeEngine()
    {
        var cost = CostOfUpgrade(EngineLevel);
        
        if (Money < cost) return;

        Money -= cost;
        EngineLevel++;

        EngineForce = (int) (EngineForce*1.25f);
    }

    public void UpgradeHealth()
    {
        var cost = CostOfUpgrade(HealthLevel);

        if (Money < cost) return;

        Money -= cost;
        HealthLevel++;

        Health = (int) (Health*1.25f);
        HealthPercent = 1.0f;
    }

    public void UpgradeShield()
    {
        var cost = CostOfUpgrade(ShieldLevel);

        if (Money < cost) return;

        Money -= cost;
        ShieldLevel++;

        Shields = (int)(Shields * 1.25f);
        ShieldPercent = 1.0f;
    }

    public void UpgradeWeapon()
    {
        var cost = CostOfUpgrade(WeaponLevel);

        if (Money < cost) return;

        Money -= cost;
        WeaponLevel++;

        GunCooldown *= 0.85f;
    }

    public void UpgradeMining()
    {
        var cost = CostOfUpgrade(MiningLevel);

        if (Money < cost) return;

        Money -= cost;
        MiningLevel++;

        _mining.Size += 0.25f;
    }

    public static int CostOfUpgrade(int level)
    {
        return level*level*20;
    }

    public void DestroyPlayer()
    {
        Destroy(transform.parent.gameObject);
        Time.timeScale = 0;
    }
}
