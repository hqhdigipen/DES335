using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public enum state
    {
        MAIN_MENU,
        INSTRUCTIONS,
        CREDITS,
        HUB,
        COMBAT,
        WIN,
        LOSE
    }

    public enum Route
    {
        Route_1 = 1,
        Route_2,
        Route_3,
        Route_4,
    }

    public int g_state = 0;
    static public int route = 1;

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            enemy.GetComponent<CharScript>().TakeDamage(100, "Normal");
            enemy2.GetComponent<CharScript>().TakeDamage(100, "Normal");
        }

        if (enemy != null && enemy2 != null)
        {
            if (enemy.GetComponent<CharScript>().currentHealth <= 0 && enemy2.GetComponent<CharScript>().currentHealth <= 0)
            {
                g_state = (int)GameState.state.WIN;

                if (Possession.possessed)
                {
                    SceneManager.LoadScene("Possess Victory");
                }
                else if (route != (int)(Route.Route_4))
                {
                    SceneManager.LoadScene("Victory");
                }
                else
                {
                    SceneManager.LoadScene("Level_Complete");
                }
            }
        }

        if (player != null && companion != null)
        {
            if (player.GetComponent<CharScript>().currentHealth <= 0 && companion.GetComponent<CharScript>().currentHealth <= 0)
            {
                g_state = (int)GameState.state.LOSE;
                SceneManager.LoadScene("Lose");

            }
        }

        if (g_state == (int)GameState.state.WIN)
        {
           Inventory.added = false;

            ContinuePopUp();
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
        {
            SceneManager.LoadScene("Route_2_3");
        }
        else if (route == (int)Route.Route_2 || route == (int)Route.Route_3)
        {
            SceneManager.LoadScene("Route_4");
        }

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

        SceneManager.LoadScene("Hub");

    }

    public void route2Pressed()
    {
        Debug.Log("Route 2 Pressed");
        SceneManager.LoadScene("QH'sScene");
        route = (int)Route.Route_2;
        Debug.Log("Route: " + route);

    }

    public void route3Pressed()
    {
        Debug.Log("Route 3 Pressed");
        SceneManager.LoadScene("QH'sScene");
        route = (int)Route.Route_3;
        Debug.Log("Route: " + route);
    }

    public void route4Pressed()
    {
        Debug.Log("Route 4 Pressed");
        SceneManager.LoadScene("QH'sScene");
        route = (int)Route.Route_4;
        Debug.Log("Route: " + route);
    }

    public void BackButtonPressed()
    {
        if (route != (int)Route.Route_4)
            SceneManager.LoadScene("Victory");
    }

    public void StartGameButtonPressed()
    {
        g_state = (int)GameState.state.HUB;
        SceneManager.LoadScene("Hub");
    }

    public void InstructionsButtonPressed()
    {
        g_state = (int)GameState.state.INSTRUCTIONS;
        SceneManager.LoadScene("Instructions");
    }

    public void CreditsButtonPressed()
    {
        g_state = (int)GameState.state.CREDITS;
        SceneManager.LoadScene("Credits");
    }

    public void BacktoMainMenuButtonPressed()
    {
        g_state = (int)GameState.state.MAIN_MENU;
        SceneManager.LoadScene("MainMenu");

    }

    public void ExitButtonPressed()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Debug.Log("Quit");
    }
}
