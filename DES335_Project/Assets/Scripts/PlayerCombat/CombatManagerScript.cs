using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CombatManagerScript : MonoBehaviour
{
    private string currState;

    public GameObject pointer;
    public GameObject friendlyPointer;

    public GameObject combatMenu;
    public GameObject attackMenu;
    public GameObject itemMenu;

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
                itemMenu.SetActive(false);
                attackMenu.SetActive(false);
                combatMenu.SetActive(true);
                pointer.SetActive(false);
                break;

            case "Attack":
                attackMenu.SetActive(true);
                combatMenu.SetActive(false);
                pointer.SetActive(false);
                break;

            case "Item":
                itemMenu.SetActive(true);
                combatMenu.SetActive(false);
                break;

            case "Targeting":
                attackMenu.SetActive(false);
                //pointer.SetActive(true);
                break;

            case "FriendlyTargeting":
                itemMenu.SetActive(false);
                //friendlyPointer.SetActive(true);
                break;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (currState == "Targeting")
            {
                currState = "Attack";
            }
            else if (currState == "FriendlyTargeting")
            {
                currState = "Item";
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
                hit.collider.transform.GetComponent<CharScript>().TakeDamage(10, "Fire");
                currState = "Main";
            }
        }

        //if (currState == "FriendlyTargeting")
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //    if (hit.collider != null && hit.collider.transform.tag == "Enemy")
        //    {
        //        //Debug.Log("Target name: " + hit.collider.name);
        //        pointer.transform.position = hit.collider.transform.position + new Vector3(0, (hit.collider.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 3.5f / 2) + (pointer.transform.GetComponent<SpriteRenderer>().sprite.bounds.size.y * 4.0f / 2), 0);
        //    }

        //    if (Input.GetMouseButtonDown(0) && hit.collider.transform.tag == "Enemy")
        //    {
        //        Debug.Log("Target name: " + hit.collider.name);
        //        hit.collider.transform.GetComponent<CharScript>().TakeDamage(10);
        //        currState = "Main";
        //    }
        //}
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

    public void UseItem(string ItemName)
    {
        currState = "FriendlyTargeting";
    }

    public void EnableEnemyPointer(GameObject EnemySprite)
    {
        if (currState == "Targeting")
        {
            pointer.SetActive(true);
            pointer.transform.localPosition = EnemySprite.transform.localPosition + new Vector3(0, (EnemySprite.transform.GetComponent<Image>().rectTransform.rect.height / 2) + (friendlyPointer.transform.GetComponent<Image>().rectTransform.rect.height / 2), 0);
        }
    }

    public void DisableEnemyPointer()
    {
        if (currState == "Targeting")
        {
            pointer.SetActive(false);
            //pointer.transform.localPosition = EnemySprite.transform.localPosition + new Vector3(0, (EnemySprite.transform.GetComponent<Image>().rectTransform.rect.height / 2) + (friendlyPointer.transform.GetComponent<Image>().rectTransform.rect.height / 2), 0);
        }
    }

    public void EnableFriendlyPointer(GameObject friendlyHP)
    {
        if (currState == "FriendlyTargeting")
        {
            friendlyPointer.SetActive(true);
            friendlyPointer.transform.localPosition = friendlyHP.transform.localPosition + new Vector3((friendlyHP.transform.GetComponent<Image>().rectTransform.rect.width / 2) + (friendlyPointer.transform.GetComponent<Image>().rectTransform.rect.width / 2), 0, 0);
        }
    }

    public void DisableFriendlyPointer()
    {
        if (currState == "FriendlyTargeting")
        {
            friendlyPointer.SetActive(false);
            //friendlyPointer.transform.localPosition = friendlyHP.transform.localPosition + new Vector3((friendlyHP.transform.GetComponent<Image>().rectTransform.rect.width / 2) + (friendlyPointer.transform.GetComponent<Image>().rectTransform.rect.width / 2), 0, 0);
        }
    }

}
