using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CombatMenuScript : MonoBehaviour
{
    private string currState;

    public GameObject pointer;

    public GameObject CombatMenu;
    public GameObject AttackMenu;
    public GameObject ItemMenu;

    CharScript clickedEnemy;

    private void Start()
    {
        currState = "Main";
    }

    private void Update()
    {
        if (currState == "Main")
        {
            ItemMenu.SetActive(false);
            AttackMenu.SetActive(false);
            CombatMenu.SetActive(true);
        }


        if (Input.GetMouseButtonDown(1))
        {
            
        }

        if (currState == "Targeting" && Input.GetMouseButtonDown(0))
        {
           
        }
    }

    public void AttackButton()
    {
        AttackMenu.SetActive(true);
        CombatMenu.SetActive(false);
    }

    public void ItemButton()
    {
        ItemMenu.SetActive(true);
        CombatMenu.SetActive(false);
    }

    public void DefendButton()
    {

    }

    public void RunButton()
    {

    }

    public void Attack1Button()
    {
        currState = "Targeting";
        AttackMenu.SetActive(false);
        pointer.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData) // 3
    {
        clickedEnemy.TakeDamage(10);
    }
}
