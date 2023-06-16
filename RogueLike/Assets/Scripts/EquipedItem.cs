using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipedItem : MonoBehaviour
{
    public Image icon;
    [SerializeField] TextMeshProUGUI levelText;
    private int level = 1;

    public bool isSet = false;
    public void Start()
    {
        icon = GetComponent<Image>();
    }
    public void Set(UpgradeData upgradeData)
    {
        isSet = true;
        icon.sprite = upgradeData.icon;
        gameObject.SetActive(true);
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
