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
    public Text attack1Text, attack2Text, attack3Text, attack4Text;

    private int actionCounter;
    private bool isPlayerTurn;

    private GameObject announcer;
    private bool playerMoved;
    private bool companionMoved;
    private bool enemy1Moved;
    private bool enemy2Moved;
    private string activeCharacter;

    bool shakeEnemy;
    GameObject targetEnemy;

    private GameObject playerEntity, companionEntity, enemyEntity1, enemyEntity2;

    private void Start()
    {
        currState = "P_Announcer";
        isPlayerTurn = true;

        announcer = GameObject.Find("TurnAnnouncer");
        playerEntity = GameObject.FindGameObjectWithTag("Player");
        companionEntity = GameObject.FindGameObjectWithTag("Companion");
        enemyEntity1 = GameObject.FindGameObjectWithTag("Enemy");
        enemyEntity2 = GameObject.FindGameObjectWithTag("Enemy2");

        activeCharacter = "Player";
        playerMoved = false;
        companionMoved = false;
    }

    private void Update()
    {
        //Debug.Log(currState);

        switch (currState)
        {
            case "P_Announcer":
                itemMenu.SetActive(false);
                attackMenu.SetActive(false);
                combatMenu.SetActive(false);
                pointer.SetActive(false);

                if (announcer != null)
                {
                    announcer.SetActive(true);
                    announcer.transform.GetChild(0).gameObject.SetActive(true);
                    announcer.transform.GetChild(1).gameObject.SetActive(false);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        announcer.SetActive(false);
                        currState = "Main";
                    }
                }
                else
                {
                    currState = "Main";
                }
                break;

            case "E_Announcer":
                if (announcer != null)
                {
                    announcer.SetActive(true);
                    announcer.transform.GetChild(0).gameObject.SetActive(false);
                    announcer.transform.GetChild(1).gameObject.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        announcer.SetActive(false);
                        currState = "EnemyTurn";
                    }
                }
                else
                {
                    currState = "Main";
                }
                break;

            case "Main":
                itemMenu.SetActive(false);
                attackMenu.SetActive(false);
                combatMenu.SetActive(true);
                pointer.SetActive(false);
                CheckActiveChar();
                break;

            case "Attack":
                attackMenu.SetActive(true);
                combatMenu.SetActive(false);
                pointer.SetActive(false);
                CheckActiveChar();
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
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (enemy1Moved == false)
                    {
                        enemyEntity1.GetComponent<Enemy>().Enemy_Attack();
                        enemy1Moved = true;
                    }
                    else if (enemy2Moved == false)
                    {
                        enemyEntity2.GetComponent<Enemy>().Enemy_Attack();
                        enemy2Moved = true;
                    }

                    if (enemy1Moved == true && enemy2Moved == true)
                    {
                        playerMoved = false;
                        companionMoved = false;
                        currState = "P_Announcer";
                    }
                }
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

        if (currState == "Attack")
        {
            if (activeCharacter == "Player")
            {
                attack1Text.text = playerEntity.GetComponent<Skills>().Skill_List[0].Name;
                attack2Text.text = playerEntity.GetComponent<Skills>().Skill_List[1].Name;
                attack3Text.text = playerEntity.GetComponent<Skills>().Skill_List[2].Name;
                attack4Text.text = playerEntity.GetComponent<Skills>().Skill_List[3].Name;
            }
            else if (activeCharacter == "Companion")
            {
                attack1Text.text = companionEntity.GetComponent<Skills>().Skill_List[0].Name;
                attack2Text.text = companionEntity.GetComponent<Skills>().Skill_List[1].Name;
                attack3Text.text = companionEntity.GetComponent<Skills>().Skill_List[2].Name;
                attack4Text.text = companionEntity.GetComponent<Skills>().Skill_List[3].Name;
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

    public void AttackEnemy(GameObject enemy)
    {
        if (currState == "Targeting")
        {
            enemy.GetComponent<CharScript>().TakeDamage(5, "Fire");
            StartCoroutine(shake(enemy, 1f));
            MarkAction(activeCharacter);
            currState = "Main";
        }
    }

    public void SwitchActiveCharacter(GameObject selected)
    {
        if (selected.transform.tag == "Player")
        {
            if (playerMoved != true)
            {
                activeCharacter = "Player";
            }
            else
            {
                activeCharacter = "Companion";
            }
        }
        else if (selected.transform.tag == "Companion")
        {
            if (companionMoved != true)
            {
                activeCharacter = "Companion";
            }
            else
            {
                activeCharacter = "player";
            }
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

    private IEnumerator EnemyStart(KeyCode keyCode)
    {
        while (!Input.GetKeyDown(keyCode))
        {
            enemyEntity1.GetComponent<Enemy>().Enemy_Attack();

            yield return waitForKeyPress(KeyCode.Space);

            enemyEntity2.GetComponent<Enemy>().Enemy_Attack();

            yield return waitForKeyPress(KeyCode.Space);
            yield return null;
        }
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

    
    public void CheckActiveChar()
    {
        if (activeCharacter == "Player")
        {
            if (playerMoved != true)
            {
                playerEntity.GetComponent<Image>().color = Color.yellow;
                companionEntity.GetComponent<Image>().color = Color.white;
            }
            else if (companionMoved != true)
            {
                activeCharacter = "Companion";
                CheckActiveChar();
            }
        }

        if (activeCharacter == "Companion")
        {
            if (companionMoved != true)
            {
                companionEntity.GetComponent<Image>().color = Color.yellow;
                playerEntity.GetComponent<Image>().color = Color.white;
            }
            else if (playerMoved != true)
            {
                activeCharacter = "Player";
                CheckActiveChar();
            }
        }

        if (playerMoved == true)
        {
            playerEntity.GetComponent<Image>().color = Color.gray;
        }

        if (companionMoved == true)
        {
            companionEntity.GetComponent<Image>().color = Color.gray;
        }

        if (playerMoved == true && companionMoved == true)
        {
            enemy1Moved = false;
            enemy2Moved = false;
            currState = "E_Announcer";
        }
    }
    
    public void MarkAction(string currentActiveCharacter)
    {
        switch (currentActiveCharacter)
        {
            case "Player":
                playerMoved = true;
                CheckActiveChar();
                break;
            case "Companion":
                companionMoved = true;
                CheckActiveChar();
                break;
        }
    }
}
