using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuScript : MonoBehaviour
{
    private Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = this.gameObject.GetComponent<Text>();
        textBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayHerbInfo()
    {
        textBox.text = "Herb \n\nRestore 20% HP on a character";
    }

    public void DisplayElixirInfo()
    {
        textBox.text = "Elixir \n\nRestore 40 % on a character";
    }

    public void ClearInfo()
    {
        textBox.text = "";
    }
}
