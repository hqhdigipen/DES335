using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        //Debug.Log(currState);

        switch (currState)
        {
            case "Main":
                ItemMenu.SetActive(false);
                AttackMenu.SetActive(false);
                CombatMenu.SetActive(true);
                pointer.SetActive(false);
                break;

            case "Attack":
                AttackMenu.SetActive(true);
                CombatMenu.SetActive(false);
                pointer.SetActive(false);
                break;

            case "Item":
                ItemMenu.SetActive(true);
                CombatMenu.SetActive(false);
                break;

            case "Targeting":
                AttackMenu.SetActive(false);
                pointer.SetActive(true);
                break;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currState == "Targeting")
            {
                currState = "Attack";
            }
            else
            {
                currState = "Main";
            }
        }

        if (currState == "Targeting")
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.transform.tag == "Enemy")
            {
                //Debug.Log("Target name: " + hit.collider.name);
                pointer.transform.position = hit.collider.transform.position + new Vector3(0, (hit.collider.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 3.5f / 2) + (pointer.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 4.0f / 2), 0);
            }

            if (Input.GetMouseButtonDown(0) && hit.collider.transform.tag == "Enemy")
            {
                Debug.Log("Target name: " + hit.collider.name);
                hit.collider.transform.GetComponent<CharScript>().TakeDamage(10);
                currState = "Main";
            }
        }
    }


    public void AttackButton()
    {
        currState = "Attack";
    }

    public void ItemButton()
    {
        currState = "Item";
    }

    public void Attack1Button()
    {
        currState = "Targeting";      
    }
}
