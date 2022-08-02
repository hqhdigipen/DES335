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

    public GameObject notEnoughSF;

    public GameObject allyWeaponPanel, allyArmorPanel, mainArmorPanel, mainWeaponPanel, noEquipmentMsg, witchPanel;
    public TextMeshProUGUI allyWeaponLv, allyArmorLv, mainArmorLv, mainWeaponLv;
    public TextMeshProUGUI allyWeaponPrice, allyArmorPrice, mainArmorPrice, mainWeaponPrice;

    public TextMeshProUGUI[] nyxHP, allyHP;

    public TextMeshProUGUI cSF, bSF, sSF, upSF, invSF, wSF;
    int soulForce;

    public GameObject upgradeMainPanel;
    public TextMeshProUGUI profileMainLv, upgradeMain, mainLv, upgradeMainPrice, witchMainLv;
    public static int playerEqLvl = 1, playerArmourLvl = 1, allyEqLvl = 1, allyAmourLvl = 1;
    public static bool firetype = false, watertype = true, earthtype = false;
    public static string s1 = "", s2 = "", s3 = "", s4 = "";
    public static string p1 = "", p2 = "", p3 = "", p4 = "";
    public static string c1 = "", c2 = "", c3 = "", c4 = ""; //companion skills
    public GameObject upgradeAllyPanel;
    public TextMeshProUGUI profileAllyLv, upgradeAlly, allyLv, upgradeAllyPrice, witchAllyLv;

    int mainCurrLv, allyCurrLv;

    public TextMeshProUGUI[] cNyxWeapon, cNyxArmor;
    public TextMeshProUGUI[] cAllyWeapon, cAllyArmor;
    public TextMeshProUGUI[] cEnemyWeapon, cEnemyArmor;

    public List <TextMeshProUGUI> cNyxSkill1, cNyxSkill2, cNyxSkill3, cNyxSkill4;

    public List<TextMeshProUGUI> cAllySkill1, cAllySkill2, cAllySkill3, cAllySkill4;

    public List <TextMeshProUGUI> cEnemySkill1, cEnemySkill2, cEnemySkill3, cEnemySkill4;

    public TextMeshProUGUI pgNum, maxPgNum;

    public List<GameObject> enemyList;

    public GameObject alreadySwitchMsg;

    public GameObject noWeaponPanel, noArmorPanel;

    string switchID="";
    //string absorbID = "0";

    public GameObject switchAlly, switchNyx;

    //public GameObject switchBackBtn;

    public GameObject hideLArrow, hideRArrow, allyWitchUI;

    bool checkLvUpgradeBtn;

    public TextMeshProUGUI mWeaponAttk, mArmorDef, aWeaponAttk, aWeaponDef;

    public GameObject notPossossYet;

    
    public void Start()
    {
        pgNum.text = 1.ToString();

        foreach (GameObject enemy in enemyList)
        {
            enemy.SetActive(false);
        }

        enemyList[0].SetActive(true);

        allyCurrLv = 1;
        mainCurrLv = 1;
        noEquipmentMsg.SetActive(true);
        soulForce = Inventory.inventorySF;
        witchPanel.SetActive(false);
        blacksmithCanvas.SetActive(false);
        generalStoreCanvas.SetActive(false);
        profileCanvas.SetActive(false);
        //hubCanvas.SetActive(true);

        playerInfo.SetActive(true);
        allyInfo.SetActive(false);

        sliderScript.GetComponent<SliderBehaviour>();

        sellSliderScript.GetComponent<SellSliderBehaviour>();
    }

    public void Update()
    {

        allyLv.text = allyCurrLv.ToString();
        profileAllyLv.text = allyCurrLv.ToString();
        witchAllyLv.text = allyCurrLv.ToString();

        mainLv.text = mainCurrLv.ToString();
        witchMainLv.text = mainCurrLv.ToString();
        profileMainLv.text = mainCurrLv.ToString();

        cSF.text = soulForce.ToString();
        bSF.text = soulForce.ToString();
        sSF.text = soulForce.ToString();
        invSF.text = soulForce.ToString();
        upSF.text = soulForce.ToString();
        wSF.text = soulForce.ToString();

        if (s1 != "" && s2 != "" && s3 != "" && s4 != "")
        {
            notPossossYet.SetActive(false);
            switch (Possession.EnemyElementType)
            {
                case 0:
                    cEnemyWeapon[int.Parse(pgNum.text) - 1].text = "Fire Orb";
                    cEnemyArmor[int.Parse(pgNum.text) - 1].text = "Fire Cloak";
                    break;

                case 1:
                    cEnemyWeapon[int.Parse(pgNum.text) - 1].text = "Water Orb";
                    cEnemyArmor[int.Parse(pgNum.text) - 1].text = "Water Cloak";
                    break;

                case 2:
                    cEnemyWeapon[int.Parse(pgNum.text) - 1].text = "Earth Orb";
                    cEnemyArmor[int.Parse(pgNum.text) - 1].text = "Earth Cloak";
                    break;
            }

            cEnemySkill1[int.Parse(pgNum.text) - 1].text = s1;
            cEnemySkill2[int.Parse(pgNum.text) - 1].text = s2;
            cEnemySkill3[int.Parse(pgNum.text) - 1].text = s3;
            cEnemySkill4[int.Parse(pgNum.text) - 1].text = s4;
        }
        else {
            //shows player that they don't have possessed enemies
            notPossossYet.SetActive(true);
        }


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
                if (sliderScript.totalItem <= 1) {
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

        if (switchNyx.activeSelf)
        {
            allyWitchUI.SetActive(false);
            hideLArrow.SetActive(true);
            hideRArrow.SetActive(true);
            if (switchID != "" && int.Parse(switchID) == int.Parse(pgNum.text) - 1)
            {
                alreadySwitchMsg.SetActive(true);
                //switchBackBtn.SetActive(true);
            }
            /*else if (absorbID != "" && int.Parse(absorbID) == int.Parse(pgNum.text) - 1) {
                alreadySwitchMsg.SetActive(true);
                //switchBackBtn.SetActive(false);
            }*/
            else
            {
                alreadySwitchMsg.SetActive(false);
                //switchBackBtn.SetActive(false);
            }
        }
        else {

            allyWitchUI.SetActive(true);
            hideLArrow.SetActive(false);
            hideRArrow.SetActive(false);
        }
        /*else {
            if (switchID != "" && int.Parse(switchID) == int.Parse(pgNum.text) - 1)
            {
                alreadySwitchMsg.SetActive(true);
                //switchBackBtn.SetActive(false);
            }
            else if (absorbID != "" && int.Parse(absorbID) == int.Parse(pgNum.text) - 1) {
                alreadySwitchMsg.SetActive(true);
                //switchBackBtn.SetActive(true);
            }
            else
            {
                alreadySwitchMsg.SetActive(false);
                //switchBackBtn.SetActive(false);
            }
        }*/


        if (playerInfo.activeSelf)
        {
            if (switchID == "")
            {
                noWeaponPanel.SetActive(true);
                noArmorPanel.SetActive(true);
            }
            else {
                noWeaponPanel.SetActive(false);
                noArmorPanel.SetActive(false);
            }
            if (switchID == "" && !checkLvUpgradeBtn)
            {
                noEquipmentMsg.SetActive(true);

            }
            else
            {
                noEquipmentMsg.SetActive(false);
            }
        }
        else
        {
            noEquipmentMsg.SetActive(false);
            /*if (absorbID == "" && !checkLvUpgradeBtn)
            {
                noEquipmentMsg.SetActive(true);
            }
            else
            {
                noEquipmentMsg.SetActive(false);
            }*/

        }
    }

    public void SwitchToAllyBtn() {
        switchAlly.SetActive(true);
        switchNyx.SetActive(false);
    }

    public void SwitchToNyxBtn()
    {
        switchAlly.SetActive(false);
        switchNyx.SetActive(true);
    }

    public void LeftBtn() {
        if (int.Parse(pgNum.text) - 1 > 0)
        {

            pgNum.text = (int.Parse(pgNum.text) - 1).ToString();
            enemyList[int.Parse(pgNum.text) - 1].SetActive(true);
            enemyList[int.Parse(pgNum.text)].SetActive(false);

        }
    }

    public void RightBtn() {
        if (int.Parse(pgNum.text)< int.Parse(maxPgNum.text))
        {
            enemyList[int.Parse(pgNum.text) - 1].SetActive(false);
            enemyList[int.Parse(pgNum.text)].SetActive(true);

            pgNum.text = (int.Parse(pgNum.text) + 1).ToString();
        }
    }

    public void SwitchBackBtn() {
      
            if (enemyList[int.Parse(pgNum.text)-1].activeSelf)
            {
            if (switchNyx.activeSelf && switchID != "")
            {
                switchID = "";
                foreach (TextMeshProUGUI weapon in cNyxWeapon)
                {
                    weapon.text = "No Weapon";
                }
                foreach (TextMeshProUGUI armor in cNyxArmor)
                {
                    armor.text = "No Armor";
                }

                foreach (TextMeshProUGUI skill in cNyxSkill1)
                {
                    skill.text = "Banshee Wail";
                }

                foreach (TextMeshProUGUI skill in cNyxSkill2)
                {
                    skill.text = "Phantom Claw";
                }

                foreach (TextMeshProUGUI skill in cNyxSkill3)
                {
                    skill.text = "Astral Plane";
                }

                foreach (TextMeshProUGUI skill in cNyxSkill4)
                {
                    skill.text = "Merciful Protection";
                }

                alreadySwitchMsg.SetActive(false);
            }
            /*else if (switchAlly.activeSelf && absorbID != "")
            {
                absorbID = "";
                foreach (TextMeshProUGUI weapon in cAllyWeapon)
                {
                    weapon.text = "No Weapon";
                }
                foreach (TextMeshProUGUI armor in cAllyArmor)
                {
                    armor.text = "No Armor";
                }

                foreach (TextMeshProUGUI skill in cAllySkill1)
                {
                    skill.text = "Punch";
                }

                foreach (TextMeshProUGUI skill in cAllySkill2)
                {
                    skill.text = "Dash";
                }

                foreach (TextMeshProUGUI skill in cAllySkill3)
                {
                    skill.text = "Dust Storm";
                }

                foreach (TextMeshProUGUI skill in cAllySkill4)
                {
                    skill.text = "Resistance";
                }
                alreadySwitchMsg.SetActive(false);
            }
            else {
                Debug.Log("You did not switch skill with this enemy");
            }*/
        }
        
    }

    public void SwitchBtn() {

        if (enemyList[int.Parse(pgNum.text) - 1].activeSelf)
        {
            if (s1!="" && s2 != "" && s3 != "" && s4 != "")
                if (switchNyx.activeSelf)
                {
                    switchID = (int.Parse(pgNum.text) - 1).ToString();
                    foreach (TextMeshProUGUI weapon in cNyxWeapon)
                    {
                        switch (Possession.EnemyElementType)
                        {
                            case 0:
                                weapon.text = "Fire Orb";
                                break;

                            case 1:
                                weapon.text = "Water Orb";
                                break;

                            case 2:
                                weapon.text = "Earth Orb";
                                break;

                        }
                    }
                    foreach (TextMeshProUGUI armor in cNyxArmor)
                    {
                        //armor.text = cEnemyArmor[int.Parse(pgNum.text) - 1].text;
                        switch (Possession.EnemyElementType)
                        {
                            case 0:
                                armor.text = "Fire Cloak";
                                break;

                            case 1:
                                armor.text = "Water Cloak";
                                break;

                            case 2:
                                armor.text = "Earth Cloak";
                                break;
                        }
                    }

                    foreach (TextMeshProUGUI skill in cNyxSkill1)
                    {
                        //skill.text = cEnemySkill1[int.Parse(pgNum.text) - 1].text;
                        skill.text = s1;
                    }

                    foreach (TextMeshProUGUI skill in cNyxSkill2)
                    {
                        // skill.text = cEnemySkill2[int.Parse(pgNum.text) - 1].text;
                        skill.text = s2;
                    }

                    foreach (TextMeshProUGUI skill in cNyxSkill3)
                    {
                        // skill.text = cEnemySkill3[int.Parse(pgNum.text) - 1].text;
                        skill.text = s3;
                    }

                    foreach (TextMeshProUGUI skill in cNyxSkill4)
                    {
                        // skill.text = cEnemySkill4[int.Parse(pgNum.text) - 1].text;
                        skill.text = s4;
                    }

                    alreadySwitchMsg.SetActive(true);

                }
            /*else {
                absorbID = (int.Parse(pgNum.text) - 1).ToString();
                foreach (TextMeshProUGUI weapon in cAllyWeapon)
                {
                    weapon.text = cEnemyWeapon[int.Parse(pgNum.text) - 1].text;
                }
                foreach (TextMeshProUGUI armor in cAllyArmor)
                {
                    armor.text = cEnemyArmor[int.Parse(pgNum.text) - 1].text;
                }

                foreach (TextMeshProUGUI skill in cAllySkill1)
                {
                    skill.text = cEnemySkill1[int.Parse(pgNum.text) - 1].text;
                }

                foreach (TextMeshProUGUI skill in cAllySkill2)
                {
                    skill.text = cEnemySkill2[int.Parse(pgNum.text) - 1].text;
                }

                foreach (TextMeshProUGUI skill in cAllySkill3)
                {
                    skill.text = cEnemySkill3[int.Parse(pgNum.text) - 1].text;
                }

                foreach (TextMeshProUGUI skill in cAllySkill4)
                {
                    skill.text = cEnemySkill4[int.Parse(pgNum.text) - 1].text;
                }
                alreadySwitchMsg.SetActive(true);
            }*/
        }
        else { 
            //show error
        }
            Debug.Log("This Works");
        
    }

    public void BuyItemBtn() {
        if (Inventory.inventorySF - int.Parse(itemCost.text) >= 0)
        {
            switch (itemName.text)
            {
                case "Herb":
                    Debug.Log("Amount: "+ Inventory.inventorySF + " Item Cost: "+ itemCost.text);
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(itemCost.text);
                    Inventory.inventHerb = Inventory.inventHerb + sliderScript.totalItem;
                    soulForce = Inventory.inventorySF;
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[2].text = (int.Parse(itemAmountLabel[2].text) + sliderScript.totalItem).ToString();
                    itemAmountLabel[4].text = (int.Parse(itemAmountLabel[4].text) + sliderScript.totalItem).ToString();
                    itemPanel.SetActive(false);

                    break;

                case "Elixir":
                    Debug.Log("Amount: " + Inventory.inventorySF + " Item Cost: " + itemCost.text);
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(itemCost.text);
                    Inventory.inventElixir = Inventory.inventElixir + sliderScript.totalItem;
                    soulForce = Inventory.inventorySF;
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
                    Inventory.inventorySF = Inventory.inventorySF + int.Parse(sellItemCost.text);
                    soulForce = Inventory.inventorySF;
                    itemAmountLabel[0].text = (int.Parse(itemAmountLabel[0].text) - sellSliderScript.sellTotalItem).ToString();
                    itemAmountLabel[2].text = (int.Parse(itemAmountLabel[2].text) - sellSliderScript.sellTotalItem).ToString();
                    itemAmountLabel[4].text = (int.Parse(itemAmountLabel[4].text) - sellSliderScript.sellTotalItem).ToString();
                    inventoryPanel.SetActive(false);
                }
               break;

                case "Elixir":
                    if (int.Parse(itemAmountLabel[1].text) > 0)
                    {
                    Inventory.inventorySF = Inventory.inventorySF + int.Parse(sellItemCost.text);
                        soulForce = Inventory.inventorySF;
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
        upgradeAllyPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void AllyArmorBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(true);
        upgradeAllyPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void MainArmorBtn()
    {
        checkLvUpgradeBtn = false;
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        upgradeAllyPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(true);
        upgradeMainPanel.SetActive(false);
    }

    public void MainWeaponBtn()
    {
        checkLvUpgradeBtn = false;
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        upgradeAllyPanel.SetActive(false);
        mainWeaponPanel.SetActive(true);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
    }

    public void PlayerLevelBtn()
    {
        checkLvUpgradeBtn = true;
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        upgradeAllyPanel.SetActive(false);

        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(true);
    }

    public void WitchBtn()
    {
        witchPanel.SetActive(true);
        hubCanvas.SetActive(false);
        switchAlly.SetActive(false);
        switchNyx.SetActive(true);
    }

    public void AllyLevelBtn()
    {
        allyWeaponPanel.SetActive(false);
        allyArmorPanel.SetActive(false);
        mainWeaponPanel.SetActive(false);
        mainArmorPanel.SetActive(false);
        upgradeMainPanel.SetActive(false);
        upgradeAllyPanel.SetActive(true);
    }


    public void UpgradePlayer() {
        if (allyWeaponPanel.activeSelf) {
            if (Inventory.inventorySF >= int.Parse(allyWeaponPrice.text) && int.Parse(allyWeaponLv.text)<5)
            {
                if (Inventory.inventorySF - int.Parse(allyWeaponPrice.text) >= 0) {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(allyWeaponPrice.text);
                    soulForce = Inventory.inventorySF;
                    allyWeaponPrice.text = (int.Parse(allyWeaponPrice.text) * 1.3).ToString();
                    allyWeaponLv.text = (int.Parse(allyWeaponLv.text) + 1).ToString();
                }

                ++allyEqLvl;
                Debug.Log("Current Ally Weapon Upgrade Level: " + allyEqLvl);
            }

        } else if (allyArmorPanel.activeSelf) {
            if (Inventory.inventorySF >= int.Parse(allyArmorPrice.text) && int.Parse(allyArmorLv.text) < 5)
            {
                if (Inventory.inventorySF - int.Parse(allyArmorPrice.text) >= 0)
                {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(allyArmorPrice.text);
                    soulForce = Inventory.inventorySF;
                    allyArmorPrice.text = (int.Parse(allyArmorPrice.text) * 1.3).ToString();
                    allyArmorLv.text = (int.Parse(allyArmorLv.text) + 1).ToString();
                }

                ++allyAmourLvl;
                Debug.Log("Current Ally Amour Upgrade Level: " + allyAmourLvl);
            }

        } else if (mainArmorPanel.activeSelf) {
            if (Inventory.inventorySF >= int.Parse(mainArmorPrice.text) && int.Parse(mainArmorLv.text) < 5)
            {
                if (Inventory.inventorySF - int.Parse(mainArmorPrice.text) >= 0)
                {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(mainArmorPrice.text);
                    soulForce = Inventory.inventorySF;
                    mainArmorPrice.text = (int.Parse(mainArmorPrice.text) * 1.3).ToString();
                    mainArmorLv.text = (int.Parse(mainArmorLv.text) + 1).ToString();
                }

                ++playerArmourLvl;
                Debug.Log("Current Player Amour Upgrade Level: " + playerArmourLvl);
            }

        } else if (upgradeMainPanel.activeSelf) {
            if (Inventory.inventorySF >= int.Parse(upgradeMainPrice.text) && mainCurrLv < 5)
            {
                if (Inventory.inventorySF - int.Parse(upgradeMainPrice.text) >= 0)
                {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(upgradeMainPrice.text);
                    soulForce = Inventory.inventorySF;
                    upgradeMainPrice.text = (int.Parse(upgradeMainPrice.text) * 1.3).ToString();
                    upgradeMain.text = (int.Parse(upgradeMain.text) + 1).ToString();
                    mainCurrLv = int.Parse(upgradeMain.text);
                    foreach (TextMeshProUGUI hp in nyxHP)
                    {
                        hp.text = (int.Parse(hp.text) * 1.3).ToString();
                    }
                }
            }

        }
        else if (upgradeAllyPanel.activeSelf)
        {
            if (Inventory.inventorySF >= int.Parse(upgradeAllyPrice.text) && int.Parse(upgradeAlly.text)<5)
            {
                if (Inventory.inventorySF - int.Parse(upgradeAllyPrice.text) >= 0)
                {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(upgradeAllyPrice.text);
                    soulForce = Inventory.inventorySF;
                    upgradeAllyPrice.text = (int.Parse(upgradeAllyPrice.text) * 1.3).ToString();
                    upgradeAlly.text = (int.Parse(upgradeAlly.text) + 1).ToString();
                    allyCurrLv = int.Parse(upgradeAlly.text);

                    foreach (TextMeshProUGUI hp in allyHP) { 
                        hp.text = (int.Parse(hp.text) * 1.3).ToString();
                    }
                }
            }

        }

        else 
        {
            if (Inventory.inventorySF >= int.Parse(mainWeaponPrice.text) && int.Parse(mainWeaponLv.text) < 5)
            {
                if (Inventory.inventorySF - int.Parse(mainWeaponPrice.text) >= 0)
                {
                    Inventory.inventorySF = Inventory.inventorySF - int.Parse(mainWeaponPrice.text);
                    soulForce = Inventory.inventorySF;
                    mainWeaponPrice.text = (int.Parse(mainWeaponPrice.text) * 1.3).ToString();
                    mainWeaponLv.text = (int.Parse(mainWeaponLv.text) + 1).ToString();
                }

                ++playerEqLvl;
                Debug.Log("Current Player Weapon Upgrade Level: " + playerEqLvl);
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

    public void WeaponUpgradeDetails() { 
        
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

            pgNum.text = 1.ToString();

            foreach (GameObject enemy in enemyList)
            {
                enemy.SetActive(false);
            }

            enemyList[0].SetActive(true);
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

    public void switchFireSkills()
    {
        if (Inventory.inventorySF - 50 >= 0)
        {
            Inventory.inventorySF = Inventory.inventorySF - 50;
            soulForce = Inventory.inventorySF;
            firetype = true;
            watertype = false;
            earthtype = false;

            foreach (TextMeshProUGUI weapon in cAllyWeapon)
            {
                weapon.text = "Fire Orb";
            }

            foreach (TextMeshProUGUI armor in cAllyArmor)
            {
                armor.text = "Fire Cloak";
            }

            foreach (TextMeshProUGUI skill1 in cAllySkill1)
            {
                skill1.text = "Fire Wall";
            }
            foreach (TextMeshProUGUI skill2 in cAllySkill2)
            {
                skill2.text = "Fire Blessing";
            }

            foreach (TextMeshProUGUI skill3 in cAllySkill3)
            {
                skill3.text = "Fire Bolt";
            }

            foreach (TextMeshProUGUI skill4 in cAllySkill4)
            {
                skill4.text = "Fire Blessing";
            }
        }

    }

    public void switchWaterSkills()
    {
        if (Inventory.inventorySF - 50 >= 0)
        {
            Inventory.inventorySF = Inventory.inventorySF - 50;
            soulForce = Inventory.inventorySF;
            watertype = true;
            earthtype = false;
            firetype = false;

            foreach (TextMeshProUGUI weapon in cAllyWeapon)
            {
                weapon.text = "Water Orb";
            }

            foreach (TextMeshProUGUI armor in cAllyArmor)
            {
                armor.text = "Water Cloak";
            }

            foreach (TextMeshProUGUI skill1 in cAllySkill1)
            {
                skill1.text = "Water Wall";
            }
            foreach (TextMeshProUGUI skill2 in cAllySkill2)
            {
                skill2.text = "Water Blessing";
            }

            foreach (TextMeshProUGUI skill3 in cAllySkill3)
            {
                skill3.text = "Hydro Shot";
            }

            foreach (TextMeshProUGUI skill4 in cAllySkill4)
            {
                skill4.text = "Water Fall";
            }


            Debug.Log("Ally is Water type");
        }
    }

    public void switchEarthSkills()
    {
        if (Inventory.inventorySF - 50 >= 0)
        {
            Inventory.inventorySF = Inventory.inventorySF - 50;
            soulForce = Inventory.inventorySF;
            earthtype = true;
            firetype = false;
            watertype = false;

            foreach (TextMeshProUGUI weapon in cAllyWeapon)
            {
                weapon.text = "Earth Orb";
            }

            foreach (TextMeshProUGUI armor in cAllyArmor)
            {
                armor.text = "Earth Cloak";
            }

            foreach (TextMeshProUGUI skill1 in cAllySkill1)
            {
                skill1.text = "Bash";
            }
            foreach (TextMeshProUGUI skill2 in cAllySkill2)
            {
                skill2.text = "Vine Whip";
            }

            foreach (TextMeshProUGUI skill3 in cAllySkill3)
            {
                skill3.text = "Hibernation";
            }

            foreach (TextMeshProUGUI skill4 in cAllySkill4)
            {
                skill4.text = "Toughen";
            }


            Debug.Log("Ally is Earth type");
        }
    }
}

