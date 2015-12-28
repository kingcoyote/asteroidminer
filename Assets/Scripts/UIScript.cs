using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerScript Player;

    private Slider _health;
    private Slider _shield;
    private Text _money;

    private Text _engineUpgrade;
    private Text _healthUpgrade;
    private Text _shieldUpgrade;
    private Text _weaponUpgrade;
    private Text _miningUpgrade;

    private Button _engineUpgradeButton;
    private Button _healthUpgradeButton;
    private Button _shieldUpgradeButton;
    private Button _weaponUpgradeButton;
    private Button _miningUpgradeButton;

    // Use this for initialization
    public void Start ()
    {
        _health = gameObject.transform.Find("StatusPanel/HealthSlider").GetComponent<Slider>();
        _shield = gameObject.transform.Find("StatusPanel/ShieldSlider").GetComponent<Slider>();
        _money = gameObject.transform.Find("StatusPanel/MoneyText").GetComponent<Text>();

        _engineUpgradeButton = gameObject.transform.Find("UpgradePanel/EngineUpgrade").GetComponent<Button>();
        _healthUpgradeButton = gameObject.transform.Find("UpgradePanel/HealthUpgrade").GetComponent<Button>();
        _shieldUpgradeButton = gameObject.transform.Find("UpgradePanel/ShieldUpgrade").GetComponent<Button>();
        _weaponUpgradeButton = gameObject.transform.Find("UpgradePanel/WeaponUpgrade").GetComponent<Button>();
        _miningUpgradeButton = gameObject.transform.Find("UpgradePanel/MiningUpgrade").GetComponent<Button>();

        _engineUpgrade = gameObject.transform.Find("UpgradePanel/EngineUpgrade").GetComponentInChildren<Text>();
        _healthUpgrade = gameObject.transform.Find("UpgradePanel/HealthUpgrade").GetComponentInChildren<Text>();
        _shieldUpgrade = gameObject.transform.Find("UpgradePanel/ShieldUpgrade").GetComponentInChildren<Text>();
        _weaponUpgrade = gameObject.transform.Find("UpgradePanel/WeaponUpgrade").GetComponentInChildren<Text>();
        _miningUpgrade = gameObject.transform.Find("UpgradePanel/MiningUpgrade").GetComponentInChildren<Text>();
    }
    
    // Update is called once per frame
    public void Update ()
    {
        _health.value = Player.HealthPercent * 100;
        _shield.value = Player.ShieldPercent * 100;
        _money.text = string.Format("Minerals\n{0}", Player.Money);

        _engineUpgradeButton.interactable = Player.Money > PlayerScript.CostOfUpgrade(Player.EngineLevel);
        _healthUpgradeButton.interactable = Player.Money > PlayerScript.CostOfUpgrade(Player.HealthLevel);
        _shieldUpgradeButton.interactable = Player.Money > PlayerScript.CostOfUpgrade(Player.ShieldLevel);
        _weaponUpgradeButton.interactable = Player.Money > PlayerScript.CostOfUpgrade(Player.WeaponLevel);
        _miningUpgradeButton.interactable = Player.Money > PlayerScript.CostOfUpgrade(Player.MiningLevel);

        _engineUpgrade.text = string.Format("Engines\n({0})", PlayerScript.CostOfUpgrade(Player.EngineLevel));
        _healthUpgrade.text = string.Format("Health\n({0})", PlayerScript.CostOfUpgrade(Player.HealthLevel));
        _shieldUpgrade.text = string.Format("Shields\n({0})", PlayerScript.CostOfUpgrade(Player.ShieldLevel));
        _weaponUpgrade.text = string.Format("Weapons\n({0})", PlayerScript.CostOfUpgrade(Player.WeaponLevel));
        _miningUpgrade.text = string.Format("Mining\n({0})", PlayerScript.CostOfUpgrade(Player.MiningLevel));
    }
}
