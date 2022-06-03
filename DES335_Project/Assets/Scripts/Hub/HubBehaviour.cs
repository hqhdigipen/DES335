using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HubBehaviour : MonoBehaviour
{
    public GameObject generalStoreCanvas, blacksmithCanvas, motherTreeCanvas;

    public void Update()
    {
        blacksmithCanvas.SetActive(false);
        generalStoreCanvas.SetActive(false);
        motherTreeCanvas.SetActive(false);
    }

    public void OpenBlacksmithCanvas()
    {
            blacksmithCanvas.SetActive(true);
        
    }



  
}

