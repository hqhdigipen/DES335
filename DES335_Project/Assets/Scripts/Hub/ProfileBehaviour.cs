using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ProfileBehaviour : MonoBehaviour
{
    public int sfAmount;

    public TextMeshProUGUI currSF, buySF, sellSF, upgradeSF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currSF.text = sfAmount.ToString();
        buySF.text = sfAmount.ToString();
        sellSF.text = sfAmount.ToString();
        upgradeSF.text = sfAmount.ToString();
    }
}
