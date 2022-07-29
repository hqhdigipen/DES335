using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SF_Text_Display : MonoBehaviour
{
    List<int> SF_List = new List<int> {100, 200, 200, 300,
                                       200, 300, 300, 400,
                                       300, 400, 400, 500};

    public int SF = 0;
    public int level = 0;
    public static int total_SF = 0;
    public Text SF_Text, level_Text, total_SF_Text;
    private GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 4; i++)
        {
            int sf = 0;

            if (GameState.route == i + 1)
            {
                if (Possession.possessed)
                {
                    sf = SF_List[i] / 2;
                    SF_Text.text = sf.ToString();

                    //SF_Text.text = SF_List[i].ToString();
                }
                else
                {
                    SF_Text.text = SF_List[i].ToString();
                    //Debug.Log("routeTest:" + GameState.route);
                }
            }
        }


        
        if (GameState.route == 4)
        {
            level = 1;
            level_Text.text = level.ToString();
        }
        

        total_SF = Inventory.inventorySF;
        total_SF_Text.text = total_SF.ToString();

    }
}
