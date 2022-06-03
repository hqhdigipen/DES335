using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HubBehaviour : MonoBehaviour
{
    public GameObject generalStoreCanvas, blacksmithCanvas, motherTreeCanvas, hubCanvas;

    public GameObject playerInfo, allyInfo;

    public void Start()
    {
        blacksmithCanvas.SetActive(false);
        generalStoreCanvas.SetActive(false);
        motherTreeCanvas.SetActive(false);
        hubCanvas.SetActive(true);

        playerInfo.SetActive(true);
        allyInfo.SetActive(false);
    }
    public void Update()
    {
       
    }

    public void OpenBlacksmithCanvas()
    {
        playerInfo.SetActive(true);
        blacksmithCanvas.SetActive(true);
        hubCanvas.SetActive(false);
    }

    public void OpenMotherTreeCanvas()
    {
        motherTreeCanvas.SetActive(true);
        hubCanvas.SetActive(false);
    }

    public void OpenGeneralStoreCanvas()
    {
        generalStoreCanvas.SetActive(true);
        hubCanvas.SetActive(false);
    }

    public void CloseCanvas()
    {
        if (blacksmithCanvas.activeSelf) {
            blacksmithCanvas.SetActive(false);
            allyInfo.SetActive(false);
            playerInfo.SetActive(false);
            hubCanvas.SetActive(true);
        }
       
    }

    public void OpenPlayerDetails() {
        playerInfo.SetActive(true);
        allyInfo.SetActive(false);
    }

    public void OpenAllyDetails()
    {
        allyInfo.SetActive(true);
        playerInfo.SetActive(false);
    }
}

