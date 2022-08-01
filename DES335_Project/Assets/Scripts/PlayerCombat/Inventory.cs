using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<int> SF_List = new List<int> {100, 200, 200, 300,
                                       200, 300, 300, 400,
                                       300, 400, 400, 500};
    // Update is called once per frame

    public static int inventorySF = 1000;
    public static int inventHerb = 0;
    public static int inventElixir = 0;
    public static bool added = true;

    void Update()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (GameState.route == i+1 && !added)
            {
                if (Possession.possessed)
                {
                    inventorySF += SF_List[i]/2;

                }
                else
                {
                    inventorySF += SF_List[i];
                }
                added = true;
            }

          //  Debug.Log("Route:" + GameState.route + " InventorySF: " + inventorySF + " added: " + added);
        }
    }
}
