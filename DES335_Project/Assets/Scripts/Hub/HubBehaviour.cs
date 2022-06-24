using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HubBehaviour : MonoBehaviour
{
    public GameObject generalStoreCanvas, blacksmithCanvas, hubCanvas, profileCanvas;

    public GameObject purchaseItems, sellItems, options;

    public GameObject playerInfo, allyInfo;

    public GameObject itemPanel, inventoryPanel;

    public SliderBehaviour sliderScript;

    public SellSliderBehaviour sellSliderScript;

    int herbPrice =30, elixirPrice=50;

    public TextMeshProUGUI itemName, itemInfo, itemCost, itemQuantity;

    public TextMeshProUGUI sellItemName, sellItemInfo, sellItemCost, sellItemQuantity;

    public TextMeshProUGUI[] itemAmountLabel;

    public ProfileBehaviour profileScript;

    public GameObject notEnoughSF;


    public void Start()
    {
        blacksmithCanvas.SetActive(false);
        generalStoreCanvas.SetActive(false);
        profileCanvas.SetActive(false);
        hubCanvas.SetActive(true);

        playerInfo.SetActive(true);
        allyInfo.SetActive(false);

        sliderScript.GetComponent<SliderBehaviour>();

        sellSliderScript.GetComponent<SellSliderBehaviour>();

        profileScript.GetComponent<ProfileBehaviour>();

    }

    public void Update()
    {
        switch (itemName.text) {
            case "Herb":
                if (sliderScript.totalItem <= 1) {
                    itemCost.text = herbPrice.ToString();
                }

                else {
                    itemCost.text = (herbPrice * sliderScript.totalItem).ToString();
                }
                break;

            case "Elixir":
                if (sliderScript.totalItem <= 1){
                    itemCost.text = elixirPrice.ToString();
                }

                else {
                    itemCost.text = (elixirPrice * sliderScript.totalItem).ToString();
                }
                break;

            default:
                break;
        }

        switch (sellItemName.text)
        {
            case "Herb":
                    sellItemCost.text = (herbPrice * sellSliderScript.sellTotalItem).ToString();
                    sellSliderScript.sellQuantitySlider.maxValue = int.Parse(itemAmountLabel[0].text);
                    
                break;

            case "Elixir":
                    sellItemCost.text = (elixirPrice * sellSliderScript.sellTotalItem).ToString();
                    sellSliderScript.sellQuantitySlider.maxValue = int.Parse(itemAmountLabel[1].text);
                    
                break;

            default:
                break;
        }
    }

    public void BuyItemBtn() {
        if (profileScript.sfAmount - int.Parse(itemCost.text) >= 0)
        {
            switch (itemName.text)
            {
                case "Herb":
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(itemCost.text);
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) + sliderScript.totalItem).ToString();
                    itemPanel.SetActive(false);

                    break;

                case "Elixir":
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(itemCost.text);
                    itemAmountLabel[1].text = (int.Parse(itemAmountLabel[1].text) + sliderScript.totalItem).ToString();
                    itemPanel.SetActive(false);
                    break;

                default:
                    break;
            }
        }
        else {
            notEnoughSF.SetActive(true);
        }
        
    }


    public void SellItemBtn()
    {
        switch (sellItemName.text)
        {
            case "Herb":
                if (int.Parse(itemAmountLabel[0].text) > 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount + int.Parse(sellItemCost.text);
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) - sellSliderScript.sellTotalItem).ToString();
                    inventoryPanel.SetActive(false);
                }
               break;

                case "Elixir":
                    if (int.Parse(itemAmountLabel[1].text) > 0)
                    {
                        profileScript.sfAmount = profileScript.sfAmount + int.Parse(sellItemCost.text);
                        itemAmountLabel[1].text = (int.Parse(itemAmountLabel[1].text) - sellSliderScript.sellTotalItem).ToString();
                        inventoryPanel.SetActive(false);
                    }
                    break;

                default:
                    break;
            }
      

    }


    public void closeErrorMessage() {
        notEnoughSF.SetActive(false);
    }


    public void ClickHerbBtn() {
        sliderScript.quantitySlider.value = 1;
        itemPanel.SetActive(true);
        itemName.text = "Herb";
        itemInfo.text = "Heal 10 HP";
        itemCost.text = herbPrice.ToString();
        itemQuantity.text = "1";
      
    }


    public void ClickSellHerbBtn()
    {
        if (int.Parse(itemAmountLabel[0].text) > 0)
        {
            sellSliderScript.sellQuantitySlider.maxValue = int.Parse(itemAmountLabel[0].text);
            sellSliderScript.sellQuantitySlider.value = 1;
            inventoryPanel.SetActive(true);
            sellItemName.text = "Herb";
            sellItemInfo.text = "Heal 10 HP";
            sellItemCost.text = herbPrice.ToString();
            sellItemQuantity.text = "1";
        }
        else {
            //error message
            Debug.Log("You don't have any herbs");
        }
    }

    public void ClickElixirBtn()
    {
        sliderScript.quantitySlider.value = 1;
        itemPanel.SetActive(true);
        itemName.text = "Elixir";
        itemInfo.text = "Heal 25 HP";
        itemCost.text = elixirPrice.ToString();
        itemQuantity.text = "1";
    }

    public void ClickSellElixirBtn()
    {
        if (int.Parse(itemAmountLabel[1].text) > 0)
        {
            sellSliderScript.sellQuantitySlider.maxValue = int.Parse(itemAmountLabel[1].text);
            sellSliderScript.sellQuantitySlider.value = 1;
            inventoryPanel.SetActive(true);
            sellItemName.text = "Elixir";
            sellItemInfo.text = "Heal 25 HP";
            sellItemCost.text = elixirPrice.ToString();
            sellItemQuantity.text = "1";
        }
        else {
            //error message
            Debug.Log("You don't have any elixir");
        }
    }

    public void OpenBlacksmithCanvas()
    {
        playerInfo.SetActive(true);
        blacksmithCanvas.SetActive(true);
        hubCanvas.SetActive(false);
    }


    public void OpenProfile() {
        hubCanvas.SetActive(false);
        profileCanvas.SetActive(true);
    }

    public void OpenGeneralStoreCanvas()
    {
        generalStoreCanvas.SetActive(true);
        hubCanvas.SetActive(false);
    }

    public void OpenBuyCanvas()
    {
        purchaseItems.SetActive(true);
        options.SetActive(false);
    }

    public void CloseBuyCanvas()
    {
        purchaseItems.SetActive(false);
        options.SetActive(true);
    }

    public void OpenSellCanvas()
    {
        sellItems.SetActive(true);
        options.SetActive(false);
    }

    public void CloseSellCanvas()
    {
        sellItems.SetActive(false);
        options.SetActive(true);
    }


    public void CloseCanvas()
    {
        if (blacksmithCanvas.activeSelf)
        {
            blacksmithCanvas.SetActive(false);
            allyInfo.SetActive(false);
            playerInfo.SetActive(false);
            hubCanvas.SetActive(true);
        }
        else if (generalStoreCanvas.activeSelf)
        {
            generalStoreCanvas.SetActive(false);
            itemPanel.SetActive(false);

            sliderScript.quantitySlider.value = 1;
            itemName.text = "";
            itemInfo.text = "";

            hubCanvas.SetActive(true);
        }
        else {
            hubCanvas.SetActive(true);
            profileCanvas.SetActive(false);
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

