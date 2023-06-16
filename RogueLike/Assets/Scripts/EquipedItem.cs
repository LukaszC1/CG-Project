using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipedItem : MonoBehaviour
{
    [SerializeField] public  Image icon;
    [SerializeField] TextMeshProUGUI levelText;
    private int level = 1;

    public bool isSet = false;
    
    public void Set(UpgradeData upgradeData)
    {
        gameObject.SetActive(true);
        isSet = true;
        icon.sprite = upgradeData.icon;
        
    }

    public void Clean()
    {
        icon.sprite = null;
    }

    public void LevelEquipedItem()
    {
        this.level++;
        levelText.text = level.ToString();
    }
}
