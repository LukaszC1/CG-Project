using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    [SerializeField] GameObject weapons;

    public void PlayerGameOver()
    {
        Debug.Log("Game over!");
        GetComponent<PlayerMove>().enabled = false;
        gameOverPanel.SetActive(true);
        weapons.SetActive(false);
    }
}
