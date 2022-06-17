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

    private int actionCounter;
    private bool isPlayerTurn;

    bool shakeEnemy;
    GameObject targetEnemy;

    private GameObject playerEntity, companionEntitiy, enemyEntity1, enemyEntity2;

    private void Start()
    {
        currState = "Main";
        actionCounter = 0;
        isPlayerTurn = true;

        playerEntity = GameObject.FindGameObjectWithTag("Player");
        companionEntitiy = GameObject.FindGameObjectWithTag("Companion");
        enemyEntity1 = GameObject.FindGameObjectWithTag("Enemy");
        enemyEntity2 = GameObject.FindGameObjectWithTag("Enemy2");

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

            case "EnemyTurn":
                itemMenu.SetActive(false);
                attackMenu.SetActive(false);
                combatMenu.SetActive(false);
                pointer.SetActive(false);
                StartCoroutine(EnemyStart());               
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

        if (shakeEnemy == true)
        {
            //targetEnemy.GetComponent<RectTransform>().anchoredPosition = new Vector2(Mathf.Sin(Time.time * 3f) * 1f, 0);
            Vector3 newPos = Random.insideUnitSphere * (Time.deltaTime * 5f);
            newPos.y = targetEnemy.GetComponent<RectTransform>().anchoredPosition.y;
            newPos.z = 0;

            targetEnemy.GetComponent<RectTransform>().anchoredPosition = newPos;
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

    public void AttackEenemy(GameObject enemy)
    {
        if (currState == "Targeting")
        {
            enemy.GetComponent<CharScript>().TakeDamage(-5, "Fire");
            StartCoroutine(shake(enemy, 1f));
            currState = "Main";
            AddActionCounter(1);
        }
    }

    //Shake function

    IEnumerator shake(GameObject enemy, float waitTime)
    {
        Vector2 temp = enemy.GetComponent<RectTransform>().anchoredPosition;
        targetEnemy = enemy;
        if (shakeEnemy == false)
        {
            shakeEnemy = true;
        }
        yield return new WaitForSeconds(waitTime);
        shakeEnemy = false;
        enemy.GetComponent<RectTransform>().anchoredPosition = temp;
    }

    private IEnumerator EnemyStart()
    {
        enemyEntity1.GetComponent<Enemy>().Enemy_Attack();

        yield return waitForKeyPress(KeyCode.Space);

        enemyEntity2.GetComponent<Enemy>().Enemy_Attack();

        yield return waitForKeyPress(KeyCode.Space);

        StopCoroutine(EnemyStart());

    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }

    public void AddActionCounter(int actionWeight)
    {
        if (actionWeight != 0)
        {
            actionCounter += (actionWeight);
        }
        else
        {
            actionCounter++;
        }


        if (actionCounter == 2)
        {
            if (isPlayerTurn == true)
            {
                currState = "EnemyTurn";
                isPlayerTurn = false;
            }
            else
            {
                currState = "Main";
                isPlayerTurn = true;
            }

            actionCounter = 0;
            Debug.Log("actionCounter: " + actionCounter);
        }
    }
}
