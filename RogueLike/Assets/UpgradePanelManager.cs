using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelManager : MonoBehaviour
{
    [SerializeField] GameObject upgradePanel;
    PauseManager pauseManager;

    public void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    public void ClosePanel()
    {
        upgradePanel.SetActive(false);
        pauseManager.UnPauseGame();
    }

    public void OpenPanel()
    {
        upgradePanel.SetActive(true);
        pauseManager.PauseGame(); 
    }
}
