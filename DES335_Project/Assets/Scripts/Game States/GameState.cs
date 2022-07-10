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

    private enum Route
    {
        Route_1 = 1,
        Route_2,
        Route_3,
        Route_4,
    }


    int g_state = 0;
    static int route = 1;

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
                if(route != (int)(Route.Route_4))
                    Application.LoadLevel("Victory");
                else
                    Application.LoadLevel("Level_Complete");
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

        if (g_state == (int)GameState.state.MAIN_MENU)
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

        if (route == (int)Route.Route_1)
            Application.LoadLevel("Route_2_3");
        else if (route == (int)Route.Route_2 || route == (int)Route.Route_3)
            Application.LoadLevel("Route_4");

        Debug.Log("Route: " + route);

    }
    void BackPopUp()
    {
        if (BackButton != null)
        {
            BackButton.SetActive(true);
        }
    }

    public void BackToHubButtonPressed()
    {
        Debug.Log("BackToHub Button Pressed");
        g_state = (int)GameState.state.HUB;

        Application.LoadLevel("Hub");

    }

    public void route2Pressed()
    {
        Debug.Log("Route 2 Pressed");
        Application.LoadLevel("QH'sScene");
        route = (int)Route.Route_2;
        Debug.Log("Route: " + route);

    }

    public void route3Pressed()
    {
        Debug.Log("Route 3 Pressed");
        Application.LoadLevel("QH'sScene");
        route = (int)Route.Route_3;
        Debug.Log("Route: " + route);
    }

    public void route4Pressed()
    {
        Debug.Log("Route 4 Pressed");
        Application.LoadLevel("QH'sScene");
        route = (int)Route.Route_4;
        Debug.Log("Route: " + route);
    }

    public void BackButtonPressed()
    {
        if (route != (int)Route.Route_4)
            Application.LoadLevel("Victory");
    }
}
