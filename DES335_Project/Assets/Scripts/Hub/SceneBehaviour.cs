using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneBehaviour : MonoBehaviour
{

    public GameObject disulas, rualie, map;

    // Start is called before the first frame update
    void Start()
    {
        //map.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void RualieHover()
    {
        rualie.SetActive(true);
    }

    public void DisulasHover()
    {
        disulas.SetActive(true);
    }

    public void ExitHover()
    {
        disulas.SetActive(false);
        rualie.SetActive(false);
    }

    public void CloseMap()
    {
        map.SetActive(false);
        disulas.SetActive(false);
        rualie.SetActive(false);
    }

    public void OpenMap()
    {
        map.SetActive(true);
        disulas.SetActive(false);
        rualie.SetActive(false);
    }

    public void DisulasRoute()
    {
        SceneManager.LoadScene("QH'sScene");
    }

    public void RualieRoute() {
        SceneManager.LoadScene("QH'sScene");
    }

    public void ExitGameBtn()
    {
        Debug.Log("exitgame");
        Application.Quit();
    }
}
