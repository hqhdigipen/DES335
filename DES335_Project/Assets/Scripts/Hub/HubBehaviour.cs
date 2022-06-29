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

    public GameObject allyWeaponPanel, allyArmorPanel, mainArmorPanel, mainWeaponPanel, noEquipmentMsg, witchPanel;
    public GameObject noWeaponBtn, noArmorBtn;
    public TextMeshProUGUI allyWeaponLv, allyArmorLv, mainArmorLv, mainWeaponLv;
    public TextMeshProUGUI allyWeaponPrice, allyArmorPrice, mainArmorPrice, mainWeaponPrice;

    public TextMeshProUGUI[] nyxHP, allyHP;

    public TextMeshProUGUI cSF, bSF, sSF, upSF, invSF;
    int soulForce;

    public GameObject upgradeMainPanel;
    public TextMeshProUGUI profileMainLv, upgradeMain, mainLv, upgradeMainPrice;

    public GameObject upgradeAllyPanel;
    public TextMeshProUGUI profileAllyLv, upgradeAlly, allyLv, upgradeAllyPrice;

    int mainCurrLv, allyCurrLv;

    public void Start()
    {
        allyCurrLv = 1;
        mainCurrLv = 1;
        noWeaponBtn.SetActive(true);
        noArmorBtn.SetActive(true);
        noEquipmentMsg.SetActive(true);
        soulForce = profileScript.sfAmount;
        witchPanel.SetActive(false);
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

        allyLv.text = allyCurrLv.ToString();
        profileAllyLv.text = allyCurrLv.ToString();

        mainLv.text = mainCurrLv.ToString();
        profileMainLv.text = mainCurrLv.ToString();

        cSF.text = soulForce.ToString();
        bSF.text = soulForce.ToString();
        sSF.text = soulForce.ToString();
        invSF.text = soulForce.ToString();
        upSF.text = soulForce.ToString();



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
                    Debug.Log("Amount: "+ profileScript.sfAmount + " Item Cost: "+ itemCost.text);
                    profileScript.sfAmount= profileScript.sfAmount - int.Parse(itemCost.text);
                    soulForce = profileScript.sfAmount;
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[2].text = (int.Parse(itemAmountLabel[2].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[4].text = (int.Parse(itemAmountLabel[4].text) + sliderScript.totalItem).ToString();
                    itemPanel.SetActive(false);

                    break;

                case "Elixir":
                    Debug.Log("Amount: " + profileScript.sfAmount + " Item Cost: " + itemCost.text);
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(itemCost.text);
                    soulForce = profileScript.sfAmount;
                    itemAmountLabel[1].text = (int.Parse(itemAmountLabel[1].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[3].text = (int.Parse(itemAmountLabel[3].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[5].text = (int.Parse(itemAmountLabel[5].text) + sliderScript.totalItem).ToString();
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
                    soulForce = profileScript.sfAmount;
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) - sellSliderScript.sellTotalItem).ToString();
                    itemAmountLabel[2].text = (int.Parse(itemAmountLabel[2].text) - sellSliderScript.sellTotalItem).ToString();
                    itemAmountLabel[4].text = (int.Parse(itemAmountLabel[4].text) - sellSliderScript.sellTotalItem).ToString();
                    inventoryPanel.SetActive(false);
                }
               break;

                case "Elixir":
                    if (int.Parse(itemAmountLabel[1].text) > 0)
                    {
                        profileScript.sfAmount = profileScript.sfAmount + int.Parse(sellItemCost.text);
                        soulForce = profileScript.sfAmount;
                        itemAmountLabel[1].text = (int.Parse(itemAmountLabel[1].text) - sellSliderScript.sellTotalItem).ToString();
                        itemAmountLabel[3].text = (int.Parse(itemAmountLabel[3].text) - sellSliderScript.sellTotalItem).ToString();
                        itemAmountLabel[5].text = (int.Parse(itemAmountLabel[5].text) - sellSliderScript.sellTotalItem).ToString();
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

    public void AllyWeaponBtn() {
        allyWeaponPanel.SetActive(true);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void AllyArmorBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(true);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void MainArmorBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(true);
        upgradeMainPanel.SetActive(false);
    }

    public void MainWeaponBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(true);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void PlayerLevelBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(true);
        noEquipmentMsg.SetActive(false);
        upgradeAllyPanel.SetActive(false);
    }

    public void WitchBtn()
    {
        witchPanel.SetActive(true);
        hubCanvas.SetActive(false);
    }

    public void AllyLevelBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
        noEquipmentMsg.SetActive(false);
        upgradeAllyPanel.SetActive(true);
    }


    public void UpgradePlayer() {
        if (allyWeaponPanel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(allyWeaponPrice.text) && int.Parse(allyWeaponLv.text)<5)
            {
                if (profileScript.sfAmount - int.Parse(allyWeaponPrice.text) >= 0) {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(allyWeaponPrice.text);
                    soulForce = profileScript.sfAmount;
                    allyWeaponPrice.text = (int.Parse(allyWeaponPrice.text) * 2).ToString();
                    allyWeaponLv.text = (int.Parse(allyWeaponLv.text) + 1).ToString();
                }
            }

        } else if (allyArmorPanel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(allyArmorPrice.text) && int.Parse(allyArmorLv.text) < 5)
            {
                if (profileScript.sfAmount - int.Parse(allyArmorPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(allyArmorPrice.text);
                    soulForce = profileScript.sfAmount;
                    allyArmorPrice.text = (int.Parse(allyArmorPrice.text) * 2).ToString();
                    allyArmorLv.text = (int.Parse(allyArmorLv.text) + 1).ToString();
                }
            }

        } else if (mainArmorPanel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(mainArmorPrice.text) && int.Parse(mainArmorLv.text) < 5)
            {
                if (profileScript.sfAmount - int.Parse(mainArmorPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(mainArmorPrice.text);
                    soulForce = profileScript.sfAmount;
                    mainArmorPrice.text = (int.Parse(mainArmorPrice.text) * 2).ToString();
                    mainArmorLv.text = (int.Parse(mainArmorLv.text) + 1).ToString();
                }
            }

        } else if (upgradeMainPanel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(upgradeMainPrice.text))
            {
                if (profileScript.sfAmount - int.Parse(upgradeMainPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(upgradeMainPrice.text);
                    soulForce = profileScript.sfAmount;
                    upgradeMainPrice.text = (int.Parse(upgradeMainPrice.text) * 2).ToString();
                    upgradeMain.text = (int.Parse(upgradeMain.text) + 1).ToString();
                    mainCurrLv = int.Parse(upgradeMain.text);
                    nyxHP[0].text = (int.Parse(nyxHP[0].text) + 10).ToString();
                    nyxHP[1].text = (int.Parse(nyxHP[1].text) + 10).ToString();
                    nyxHP[2].text = (int.Parse(nyxHP[2].text) + 10).ToString();
                }
            }

        }
        else if (upgradeAllyPanel.activeSelf)
        {
            if (profileScript.sfAmount > int.Parse(upgradeAllyPrice.text))
            {
                if (profileScript.sfAmount - int.Parse(upgradeAllyPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(upgradeAllyPrice.text);
                    soulForce = profileScript.sfAmount;
                    upgradeAllyPrice.text = (int.Parse(upgradeAllyPrice.text) * 2).ToString();
                    upgradeAlly.text = (int.Parse(upgradeAlly.text) + 1).ToString();
                    allyCurrLv = int.Parse(upgradeAlly.text);
                    allyHP[0].text = (int.Parse(allyHP[0].text) + 10).ToString();
                    allyHP[1].text = (int.Parse(allyHP[1].text) + 10).ToString();
                    allyHP[2].text = (int.Parse(allyHP[2].text) + 10).ToString();
                }
            }

        }

        else 
        {
            if (profileScript.sfAmount > int.Parse(mainWeaponPrice.text) && int.Parse(mainWeaponLv.text) < 5)
            {
                if (profileScript.sfAmount - int.Parse(mainWeaponPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(mainWeaponPrice.text);
                    soulForce = profileScript.sfAmount;
                    mainWeaponPrice.text = (int.Parse(mainWeaponPrice.text) * 2).ToString();
                    mainWeaponLv.text = (int.Parse(mainWeaponLv.text) + 1).ToString();
                }
            }
        }
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
            noWeaponBtn.SetActive(true);
            noArmorBtn.SetActive(true);
            noEquipmentMsg.SetActive(true);
            allyWeaponPanel.SetActive(false);
            allyArmorPanel.SetActive(false);
            mainWeaponPanel.SetActive(false);
            mainArmorPanel.SetActive(false);
            upgradeMainPanel.SetActive(false);
            upgradeAllyPanel.SetActive(false);

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
        else if (witchPanel.activeSelf) {
            witchPanel.SetActive(false);
            hubCanvas.SetActive(true);
        }
        else
        {
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
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
    }
}

