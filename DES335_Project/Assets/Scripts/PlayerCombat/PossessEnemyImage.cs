using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossessEnemyImage : MonoBehaviour
{
    public GameObject enemy;
    public Sprite redSprite, blueSprite, greenSprite;

    // Update is called once per frame
    void Update()
    {
        if (Possession.EnemyElementType == (int)POSSESSED_CHARACTER_ELEMENTS.Earth)
       {
            enemy.GetComponent<SpriteRenderer>().sprite = greenSprite;
        }
        else if (Possession.EnemyElementType == (int)POSSESSED_CHARACTER_ELEMENTS.Fire)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = redSprite;
        }
        else if (Possession.EnemyElementType == (int)POSSESSED_CHARACTER_ELEMENTS.Water)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = blueSprite;
        }
    }
}
