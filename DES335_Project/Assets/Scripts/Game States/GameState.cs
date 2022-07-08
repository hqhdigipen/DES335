using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private enum state
    { 
        MAIN_MENU, 
        HUB,
        COMBAT,
        WIN,
        LOSE,
    }

    int g_state = 0; 

    GameObject companion, enemy, enemy2, player;
    public GameObject VictoryButton, BackButton;
   
// Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        player = GameObject.FindGameObjectWithTag("Player");
        companion = GameObject.FindGameObjectWithTag("Companion");

        if (VictoryButton != null)
        {
            VictoryButton.SetActive(false);
        }

        if (BackButton != null)
        {
            BackButton.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            player.GetComponent<CharScript>().TakeDamage(100, "Normal");
            companion.GetComponent<CharScript>().TakeDamage(100, "Normal");
        }

        if (enemy != null && enemy2 != null)
        {
            if (enemy.GetComponent<CharScript>().currentHealth <= 0 && enemy2.GetComponent<CharScript>().currentHealth <= 0)
            {
                g_state = (int)GameState.state.WIN;
                Application.LoadLevel("Victory");

            }
        }

        if (player != null && companion != null)
        {
            if (player.GetComponent<CharScript>().currentHealth <= 0 && companion.GetComponent<CharScript>().currentHealth <= 0)
            {
                g_state = (int)GameState.state.LOSE;
                Application.LoadLevel("Lose");

            }
        }

        if(g_state == (int)GameState.state.MAIN_MENU)
        {

        }
        else if (g_state == (int)GameState.state.HUB)
        {

        }
        else if (g_state == (int)GameState.state.COMBAT)
        {

        }
        else if (g_state == (int)GameState.state.WIN)
        {
            ContinuePopUp();
        }
        else if (g_state == (int)GameState.state.LOSE)
        {

        }
    }

    void ContinuePopUp()
    {
        if (VictoryButton != null)
        {
            VictoryButton.SetActive(true);
        }
    }

    public void ContinueButtonPressed()
    {
        Debug.Log("Continue Button Pressed");
    }

    void BackPopUp()
    {
        if (BackButton != null)
        {
            BackButton.SetActive(true);
        }
    }

    public void BackButtonPressed()
    {
        Debug.Log("Back Button Pressed");
        g_state = (int)GameState.state.HUB;

        Application.LoadLevel("Hub");

    }
}
