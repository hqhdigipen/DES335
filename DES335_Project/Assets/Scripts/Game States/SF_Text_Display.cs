using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SF_Text_Display : MonoBehaviour
{
    List<int> SF_List = new List<int> {100, 150, 150, 200,
                                       200, 250, 250, 300,
                                       300, 350, 350, 400};

    public int SF = 0;
    public Text SF_Text;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("routeTest:" + GameState.route);

        for (int i = 0; i < 4; i++)
        {
            if (GameState.route == i + 1)
                SF_Text.text = SF_List[i].ToString();
        }
    }
}
