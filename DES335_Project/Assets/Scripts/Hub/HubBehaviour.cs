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

    public GameObject playerSkill1Panel, playerSkill2Panel, playerArmorPanel, playerWeaponPanel;
    public TextMeshProUGUI playerSkill1Lv, playerSkill2Lv, playerArmorLv, playerWeaponLv;
    public TextMeshProUGUI playerSkill1Price, playerSkill2Price, playerArmorPrice, playerWeaponPrice;
    public TextMeshProUGUI playerSkill1Des, playerSkill2Des, playerArmorDes, playerWeaponDes, upgradeLvDes;
    public TextMeshProUGUI skill1Dmg, skill2Dmg, armorDef, weaponAttk;

    public TextMeshProUGUI[] nyxHP;

    public TextMeshProUGUI cSF, bSF, sSF, upSF, invSF;
    int soulForce;

    public GameObject upgradeLvPanel;
    public TextMeshProUGUI profileLv, upgradeLv, charLv, upgradeLvPrice;

    int currLv;

    public void Start()
    {
        soulForce = profileScript.sfAmount;
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
        charLv.text = currLv.ToString();
        profileLv.text = currLv.ToString();

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
                    itemPanel.SetActive(false);

                    break;

                case "Elixir":
                    Debug.Log("Amount: " + profileScript.sfAmount + " Item Cost: " + itemCost.text);
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(itemCost.text);
                    soulForce = profileScript.sfAmount;
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
                    soulForce = profileScript.sfAmount;
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) - sellSliderScript.sellTotalItem).ToString();
                    inventoryPanel.SetActive(false);
                }
               break;

                case "Elixir":
                    if (int.Parse(itemAmountLabel[1].text) > 0)
                    {
                        profileScript.sfAmount = profileScript.sfAmount + int.Parse(sellItemCost.text);
                        soulForce = profileScript.sfAmount;
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

    public void PlayerSkill1Btn() {
        playerSkill1Panel.SetActive(true);
        playerSkill2Panel.SetActive(false);
        playerWeaponPanel.SetActive(false);
        playerArmorPanel.SetActive(false);
        upgradeLvPanel.SetActive(false);
    }

    public void PlayerSkill2Btn()
    {
        playerSkill1Panel.SetActive(false);
        playerSkill2Panel.SetActive(true);
        playerWeaponPanel.SetActive(false);
        playerArmorPanel.SetActive(false);
        upgradeLvPanel.SetActive(false);
    }

    public void PlayerArmorBtn()
    {
        playerSkill1Panel.SetActive(false);
        playerSkill2Panel.SetActive(false);
        playerWeaponPanel.SetActive(false);
        playerArmorPanel.SetActive(true);
        upgradeLvPanel.SetActive(false);
    }

    public void PlayerWeaponBtn()
    {
        playerSkill1Panel.SetActive(false);
        playerSkill2Panel.SetActive(false);
        playerWeaponPanel.SetActive(true);
        playerArmorPanel.SetActive(false);
        upgradeLvPanel.SetActive(false);
    }

    public void PlayerLevelBtn()
    {
        playerSkill1Panel.SetActive(false);
        playerSkill2Panel.SetActive(false);
        playerWeaponPanel.SetActive(false);
        playerArmorPanel.SetActive(false);
        upgradeLvPanel.SetActive(true);
    }

    public void UpgradePlayer() {
        if (playerSkill1Panel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(playerSkill1Price.text))
            {
                if (profileScript.sfAmount - int.Parse(playerSkill1Price.text) >= 0) {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(playerSkill1Price.text);
                    soulForce = profileScript.sfAmount;
                    playerSkill1Price.text = (int.Parse(playerSkill1Price.text) * 2).ToString();
                    playerSkill1Lv.text = (int.Parse(playerSkill1Lv.text) + 1).ToString();
                    skill1Dmg.text = (int.Parse(skill1Dmg.text) + 5).ToString();
                }
            }

        } else if (playerSkill2Panel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(playerSkill2Price.text))
            {
                if (profileScript.sfAmount - int.Parse(playerSkill2Price.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(playerSkill2Price.text);
                    soulForce = profileScript.sfAmount;
                    playerSkill2Price.text = (int.Parse(playerSkill2Price.text) * 2).ToString();
                    playerSkill2Lv.text = (int.Parse(playerSkill2Lv.text) + 1).ToString();
                    skill2Dmg.text = (int.Parse(skill2Dmg.text) + 5).ToString();
                }
            }

        } else if (playerArmorPanel.activeSelf) {
            if (profileScript.sfAmount > int.Parse(playerArmorPrice.text))
            {
                if (profileScript.sfAmount - int.Parse(playerArmorPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(playerArmorPrice.text);
                    soulForce = profileScript.sfAmount;
                    playerArmorPrice.text = (int.Parse(playerArmorPrice.text) * 2).ToString();
                    playerArmorLv.text = (int.Parse(playerArmorLv.text) + 1).ToString();
                    armorDef.text = (int.Parse(armorDef.text) + 5).ToString();
                }
            }

        } else if (upgradeLvPanel.activeSelf) {
            profileScript.sfAmount = profileScript.sfAmount - int.Parse(upgradeLvPrice.text);
            soulForce = profileScript.sfAmount;
            upgradeLvPrice.text = (int.Parse(upgradeLvPrice.text) * 2).ToString();
            upgradeLv.text = (int.Parse(upgradeLv.text) + 1).ToString();
            currLv = int.Parse(upgradeLv.text);
            nyxHP[0].text = (int.Parse(nyxHP[0].text) + 10).ToString();
            nyxHP[1].text = (int.Parse(nyxHP[1].text) + 10).ToString();
            nyxHP[2].text = (int.Parse(nyxHP[2].text) + 10).ToString();

        }

        else {
            if (profileScript.sfAmount > int.Parse(playerWeaponPrice.text))
            {
                if (profileScript.sfAmount - int.Parse(playerWeaponPrice.text) >= 0)
                {
                    profileScript.sfAmount = profileScript.sfAmount - int.Parse(playerWeaponPrice.text);
                    soulForce = profileScript.sfAmount;
                    playerWeaponPrice.text = (int.Parse(playerWeaponPrice.text) * 2).ToString();
                    playerWeaponLv.text = (int.Parse(playerWeaponLv.text) + 1).ToString();
                    weaponAttk.text = (int.Parse(weaponAttk.text) + 5).ToString();
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

            playerSkill1Panel.SetActive(false);
            playerSkill2Panel.SetActive(false);
            playerWeaponPanel.SetActive(false);
            playerArmorPanel.SetActive(false);
            upgradeLvPanel.SetActive(false);

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
        playerSkill1Panel.SetActive(false);
        playerSkill2Panel.SetActive(false);
        playerWeaponPanel.SetActive(false);
        playerArmorPanel.SetActive(false);
    }
}

