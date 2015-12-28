using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public PlayerScript PlayerPrefab;

    private PlayerScript _player;

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

    private Transform _topMenuPanel;

    private bool _isPaused;

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

        _topMenuPanel = gameObject.transform.Find("TopMenuPanel");

        Pause();
    }
    
    // Update is called once per frame
    public void Update ()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }

        if (_player == null) return;

        _health.value = _player.HealthPercent * 100;
        _shield.value = _player.ShieldPercent * 100;
        _money.text = string.Format("Minerals\n{0}", _player.Money);

        _engineUpgradeButton.interactable = _player.Money > PlayerScript.CostOfUpgrade(_player.EngineLevel);
        _healthUpgradeButton.interactable = _player.Money > PlayerScript.CostOfUpgrade(_player.HealthLevel);
        _shieldUpgradeButton.interactable = _player.Money > PlayerScript.CostOfUpgrade(_player.ShieldLevel);
        _weaponUpgradeButton.interactable = _player.Money > PlayerScript.CostOfUpgrade(_player.WeaponLevel);
        _miningUpgradeButton.interactable = _player.Money > PlayerScript.CostOfUpgrade(_player.MiningLevel);

        _engineUpgrade.text = string.Format("Engines\n({0})", PlayerScript.CostOfUpgrade(_player.EngineLevel));
        _healthUpgrade.text = string.Format("Health\n({0})", PlayerScript.CostOfUpgrade(_player.HealthLevel));
        _shieldUpgrade.text = string.Format("Shields\n({0})", PlayerScript.CostOfUpgrade(_player.ShieldLevel));
        _weaponUpgrade.text = string.Format("Weapons\n({0})", PlayerScript.CostOfUpgrade(_player.WeaponLevel));
        _miningUpgrade.text = string.Format("Mining\n({0})", PlayerScript.CostOfUpgrade(_player.MiningLevel));
    }

    private void Pause()
    {
        _isPaused = !_isPaused;

        Time.timeScale = _isPaused ? 0 : 1;
        _topMenuPanel.gameObject.SetActive(_isPaused);
        _topMenuPanel.transform.Find("ResumeGameButton").GetComponent<Button>().interactable = _player != null;
    }

    public void NewGame()
    {
        foreach (var go in GameObject.FindGameObjectsWithTag("Disposable"))
        {
            Destroy(go);
        }

        _player = Instantiate(PlayerPrefab, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, -90)) as PlayerScript;
        gameObject.GetComponentInChildren<TurretAimScript>().Player = _player;
        Pause();
    }

    public void ResumeGame()
    {
        Pause();
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#else
        Application.Quit();
#endif
    }
}
