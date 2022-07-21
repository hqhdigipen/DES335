using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyElementUI : MonoBehaviour
{
    public Sprite spriteFire, spriteWater, spriteEarth;

    public CharScript characterScript;

    private string element;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        element = characterScript.elementType.ToString();

        switch (element)
        {
            case "Fire":
                this.gameObject.GetComponent<Image>().sprite = spriteFire;
                break;
            case "Water":
                this.gameObject.GetComponent<Image>().sprite = spriteWater;
                break;
            case "Earth":
                this.gameObject.GetComponent<Image>().sprite = spriteEarth;
                break;
        }
    }
}
