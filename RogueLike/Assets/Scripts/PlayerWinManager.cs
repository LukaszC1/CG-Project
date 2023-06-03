using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWinManager : MonoBehaviour
{
    [SerializeField] GameObject winPanel;

    PauseManager pauseManager;

    private void Start()
    {
        pauseManager = GetComponent<PauseManager>();
    }

    public void Win()
    {
        winPanel.SetActive(true);
        pauseManager.PauseGame();
    }
}
