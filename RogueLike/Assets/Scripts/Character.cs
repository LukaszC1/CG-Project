using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    public int armor = 0;
    public float hpRegen = 1f;
    public float damageMultiplier = 1f;
    public float areaMultiplier = 1f;
    public float projectileSpeedMultiplier = 1f;
    public float magnetSize = 1f;
    public float cooldownMultiplier = 1f;
    public int amountBonus = 0;

    private bool playerIsDead = false;

    public float hpRegenTimer;


    [HideInInspector] public int currentHp = 100;
    [SerializeField] StatusBar hpBar;
    int level = 1;
    int experience = 0;


    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanelManager;
    [SerializeField] List<UpgradeData> upgrades;

    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;
    [SerializeField] List<UpgradeData> upgradesAvailableOnStart;
    
    WeaponManager weaponManager;
    PassiveItems passiveItems;
    Magnet magnet;

    private void Awake()
    {
        weaponManager = GetComponent<WeaponManager>();
        magnet = GetComponent<Magnet>();
        passiveItems = GetComponent<PassiveItems>();
    }

    private void Update()
    {
        hpRegenTimer += Time.deltaTime * hpRegen;

        if(hpRegenTimer > 1f)
        {
            Heal(1);
            hpRegenTimer -= 1f;
        }
    }
    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }
    
    private void Start()
    {
        currentHp = maxHp;
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
        hpBar.SetState(currentHp, maxHp);
        AddUpgradesIntoList(upgradesAvailableOnStart);
    }

    public void TakeDamage(int damage)
    {
        if (playerIsDead) return;
        ApplyArmor(ref damage);
        currentHp -= damage;

        if(currentHp <= 0)
        {
            //Destroy(gameObject);
           

            if (!playerIsDead)
            {
                playerIsDead = true;
                GetComponent<GameOver>().PlayerGameOver();
            }
       }

        hpBar.SetState(currentHp, maxHp);
    }

    public void ApplyArmor(ref int damage)
    {
        damage -= armor;
        if (damage <= 0) { damage = 1; }
    }


    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp)
        {
            currentHp=maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void AddExperience(int amount)
    {
        experience += amount;
        CheckLevelUp();
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
    }


    public void CheckLevelUp()
    {
        if (experience >= TO_LEVEL_UP)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        if(selectedUpgrades == null) { selectedUpgrades = new List<UpgradeData>(); }
        selectedUpgrades.Clear();
        selectedUpgrades.AddRange(GetUpgrades(4));

        if(selectedUpgrades.Count > 0)
        upgradePanelManager.OpenPanel(selectedUpgrades);

        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);

        magnet.LevelUpUpdate();
       
        updateWeapons();
    }

    public void updateWeapons()
    {
        foreach (var weapon in weaponManager.weapons)
            weapon.LevelUpUpdate();
    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();


        if(count > upgrades.Count)
            count = upgrades.Count;

        for(int i = 0; i < count; i++)
        {
            UpgradeData upgradeData = upgrades[Random.Range(0, upgrades.Count)];
            while (upgradeList.Contains(upgradeData))
            {
                upgradeData = upgrades[Random.Range(0, upgrades.Count)];
            }
            upgradeList.Add(upgradeData); //select random upgrades from the list
        }

        return upgradeList;
    }

    public void Upgrade (int selectedUpgrade)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgrade];

       if( acquiredUpgrades == null ) { acquiredUpgrades = new List<UpgradeData>(); }

        switch (upgradeData.upgradeType)
        {
            case UpgradeType.WeaponUpgrade:
                weaponManager.UpgradeWeapon(upgradeData);
                break;
            case UpgradeType.ItemUpgrade:
                passiveItems.UpgradeItem(upgradeData);
                break;
            case UpgradeType.WeaponUnlock:
                weaponManager.AddWeapon(upgradeData.weaponData);
                break;
            case UpgradeType.ItemUnlock:
                passiveItems.Equip(upgradeData.item);
                break;
        }

        acquiredUpgrades.Add(upgradeData);
       upgrades.Remove(upgradeData);

       

    }

    internal void AddUpgradesIntoList(List<UpgradeData> upgradesToAdd)
    {
        if(upgradesToAdd == null) { return; }

       this.upgrades.AddRange(upgradesToAdd);
    }
    internal void AddUpgradeIntoList(UpgradeData upgradeToAdd)
    {
        if (upgradeToAdd == null) { return; }

        upgrades.Add(upgradeToAdd);
    }
}
