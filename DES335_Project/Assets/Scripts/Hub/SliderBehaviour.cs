using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SliderBehaviour : MonoBehaviour
{
    public TextMeshProUGUI itemQuantity;
    public int totalItem=1;
    public Slider quantitySlider;
    // Start is called before the first frame update
    void Start()
    {
        quantitySlider.onValueChanged.AddListener((v) => {
            itemQuantity.text = v.ToString("0");
            totalItem = (int) v;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
