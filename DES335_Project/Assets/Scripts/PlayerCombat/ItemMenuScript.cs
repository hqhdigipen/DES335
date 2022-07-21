using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuScript : MonoBehaviour
{
    private Text textBox;
    public Text herbCount, elixirCount;
    public GameObject herbBtn, elixirBtn;

    // Start is called before the first frame update
    void Start()
    {
        textBox = this.gameObject.GetComponent<Text>();
        textBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        herbCount.text = Inventory.inventHerb.ToString();
        elixirCount.text = Inventory.inventElixir.ToString();

        if (Inventory.inventHerb <= 0)
        {
            herbBtn.GetComponent<Image>().color = Color.gray;
        }

        if (Inventory.inventElixir <= 0)
        {
            elixirBtn.GetComponent<Image>().color = Color.gray;
        }
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
