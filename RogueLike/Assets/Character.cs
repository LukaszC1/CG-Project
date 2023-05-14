using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 100;
    [HideInInspector] public int currentHp = 100;
    [SerializeField] StatusBar hpBar;


    int level = 1;
    int experience = 0;
    [SerializeField] ExperienceBar experienceBar;

    int TO_LEVEL_UP
    {
        get { return level * 1000; }
    }
    private void Awake()
    {
        
    }

    private void Start()
    {
        currentHp = maxHp;
        experienceBar.UpdateExperienceSlider(experience, TO_LEVEL_UP);
        experienceBar.SetLevelText(level);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if(currentHp <= 0)
        {
            Destroy(gameObject);
        }
        hpBar.SetState(currentHp, maxHp);
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
            experience -= TO_LEVEL_UP;
            level+=1;
            experienceBar.SetLevelText(level);
        }
    }


}
