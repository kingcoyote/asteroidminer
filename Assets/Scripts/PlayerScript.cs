using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float EngineForce;
    public float GunCooldown = 0.5f;

    public int Money;
    public int Health = 100;
    public int Shields = 100;
    public float HealthPercent = 1.0f;
    public float ShieldPercent = 1.0f;
    public float LifeSpan;
    public float ShieldCharge = 0.005f;

    public int EngineLevel { get; private set; }
    public int HealthLevel { get; private set; }
    public int ShieldLevel { get; private set; }
    public int WeaponLevel { get; private set; }
    public int MiningLevel { get; private set; }

    public FloatingTextScript FloatingText;

    public Transform DeathAnimation;

    private Rigidbody2D _rigidBody2D;
    private TurretScript[] _turrets;
    private float _gunCooldown;
    private MiningScript _mining;

    private AudioSource _audio;

    // Use this for initialization
    public void Start () {
        _rigidBody2D = gameObject.GetComponent<Rigidbody2D> ();
        _mining = gameObject.GetComponentInChildren<MiningScript>();

        EngineLevel = 1;
        HealthLevel = 1;
        ShieldLevel = 1;
        WeaponLevel = 1;
        MiningLevel = 1;

        _audio = gameObject.GetComponent<AudioSource>();

        _turrets = gameObject.GetComponentsInChildren<TurretScript>();
    }

    // Update is called once per frame
    public void FixedUpdate () {
        var force = new Vector2 (0, Input.GetAxis ("Vertical")) * EngineForce;
        _rigidBody2D.AddForce (force);
    }

    public void Update()
    {
        var aimAxis = new Vector3(Input.GetAxis("HorizontalAim"), Input.GetAxis("VerticalAim"), 0);
        if (aimAxis.magnitude > 0.3) Aim(transform.position + aimAxis);
        if(Input.GetAxis("Fire2") > 0.5) Fire(); 
        
        if (HealthPercent <= 0)
        {
            DestroyPlayer();
        }

        _gunCooldown -= Time.deltaTime;
        if (ShieldPercent < 0f) ShieldPercent = 0f;
        ShieldPercent += ShieldCharge * Time.deltaTime * ShieldLevel;
        if (ShieldPercent > 1.0f) ShieldPercent = 1.0f;

        LifeSpan += Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponentInChildren<AsteroidScript>() != null)
        {

            var ft = Instantiate(FloatingText, Camera.main.WorldToScreenPoint(transform.position), new Quaternion(0, 0, 0, 0)) as FloatingTextScript;
            ft.Immortal = false;
            ft.Number -= (other.gameObject.GetComponentInChildren<AsteroidScript>().Health);

            HealthPercent -= other.gameObject.GetComponentInChildren<AsteroidScript>().Health / (float)Health;
            other.gameObject.GetComponent<AsteroidScript>().SpawnDeathAnimation();
            _audio.PlayOneShot(_audio.clip);
            Destroy(other.gameObject);
        }
    }

    public void Fire()
    {
        if (_gunCooldown > 0) return;
        _gunCooldown = GunCooldown;

        foreach (var turret in _turrets)
        {
            turret.Fire();
        }
    }

    public void Aim(Vector2 target)
    {
        foreach (var turret in _turrets)
        {
            turret.Aim(target);
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

        HealthPercent = 1.0f;
    }

    public void UpgradeShield()
    {
        var cost = CostOfUpgrade(ShieldLevel);

        if (Money < cost) return;

        Money -= cost;
        ShieldLevel++;
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
        var death = Instantiate(DeathAnimation);
        death.gameObject.SetActive(true);
        death.transform.position = transform.position;
        Destroy(gameObject);
    }
}
