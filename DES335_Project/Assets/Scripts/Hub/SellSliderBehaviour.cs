using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SellSliderBehaviour : MonoBehaviour
{
    public TextMeshProUGUI sellItemQuantity;
    public int sellTotalItem = 1;
    public Slider sellQuantitySlider;
    // Start is called before the first frame update
    void Start()
    {
        sellQuantitySlider.onValueChanged.AddListener((v) => {
            sellItemQuantity.text = v.ToString("0");
            sellTotalItem = (int)v;
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
