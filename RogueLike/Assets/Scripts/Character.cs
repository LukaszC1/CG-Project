using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    public int armor = 0;
    private bool playerIsDead = false;

    [HideInInspector] public int currentHp = 100;
    [SerializeField] StatusBar hpBar;
    int level = 1;
    int experience = 0;


    [SerializeField] ExperienceBar experienceBar;
    [SerializeField] UpgradePanelManager upgradePanelManager;
    [SerializeField] List<UpgradeData> upgrades;

    List<UpgradeData> selectedUpgrades;
    [SerializeField] List<UpgradeData> acquiredUpgrades;

    
    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }
    
    private void Start()
    {
        currentHp = maxHp;
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
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
        if(damage < 0) { damage = 0; }
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

        upgradePanelManager.OpenPanel(selectedUpgrades);
        experience -= TO_LEVEL_UP;
        level += 1;
        experienceBar.SetLevelText(level);

    }

    public List<UpgradeData> GetUpgrades(int count)
    {
        List<UpgradeData> upgradeList = new List<UpgradeData>();


        if(count > upgrades.Count)
            count = upgrades.Count;

        for(int i = 0; i < count; i++)
        upgradeList.Add(upgrades[Random.Range(0, upgrades.Count)]); //select random upgrades from the list

        return upgradeList;
    }

    public void Upgrade (int selectedUpgrade)
    {
        UpgradeData upgradeData = selectedUpgrades[selectedUpgrade];

       if( acquiredUpgrades == null ) { acquiredUpgrades = new List<UpgradeData>(); }   

       acquiredUpgrades.Add(upgradeData);
       upgrades.Remove(upgradeData);
    }
}
