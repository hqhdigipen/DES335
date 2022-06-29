using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    enum OPPONENT
    { 
        PLAYER,
        COMPANION
    }

    int i = 0;
    int target = 0;
    int opponent = 2;
    int damage = 0;
    int num_enemies = 2;
    int target_remaining = 0;
    string attack_element;

    static int healCounter = 2;
    float healProbability = 0.0f;
    bool enemy_win = false;

    public GameObject player;
    public GameObject companion;
    public GameObject enemy;

    private GameObject gameManager;
    private Text actionLogTextBox;
    
    public void Start()
    {
        enemy = this.gameObject;
        companion = GameObject.FindGameObjectWithTag("Companion");
        gameManager = GameObject.Find("GameManager");
        if (GameObject.Find("TextBox") != null)
        {
            actionLogTextBox = GameObject.Find("TextBox").GetComponent<Text>();
        }
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !enemy_win)
        {
            if (num_enemies != 0)
                HealOrAttack();
        }
    }

    public void Enemy_Attack()
    {
        if(!enemy_win && num_enemies != 0)
            HealOrAttack();
    }
    private void HealOrAttack()
    {
        float hpPercentage = ((float)enemy.GetComponent<CharScript>().currentHealth 
                              / (float)enemy.GetComponent<CharScript>().maxHealth)*100.0f;

        //Debug.Log("HP / Max HP : " + hpPercentage);

        if (healCounter == 0)
        {
            RandomiseSkill();
            return;
        }

        if (hpPercentage <= 25.0f)
        {
            healProbability = 50.0f;
            float random = Random.Range(0.0f, 100.0f);
            //Debug.Log("Random Heal probability /100 : " + random);

            if (random <= healProbability)
                Heal();
            else if (num_enemies == 2)
            {
                RandomiseSkill();
                RandomiseTarget();
            }
            else
                FixedTargetAttack();
        }
        else if (num_enemies == 2)
        {
            RandomiseSkill();
            RandomiseTarget();
        }
        else if (num_enemies == 1)
            FixedTargetAttack();         

    }
    private void Heal()
    {
        //Debug.Log("Enemy HP Before: " + enemy.GetComponent<CharScript>().currentHealth + ". Heal Counter: " + healCounter);

        if (healCounter != 0)
        {
            enemy.GetComponent<CharScript>().currentHealth = enemy.GetComponent<CharScript>().currentHealth +
              (enemy.GetComponent<CharScript>().maxHealth / 2);

            //enemy.GetComponent<HealthBarScript>().SetHealth(enemy.GetComponent<CharScript>().currentHealth);
            enemy.GetComponent<CharScript>().SetHPinUI();

           healCounter--;

            //Debug.Log("Enemy HP after heal: " + enemy.GetComponent<CharScript>().currentHealth + ". Heal Counter: " + healCounter);
            if (actionLogTextBox != null)
            {
                actionLogTextBox.text = "Enemy HP after heal: " + enemy.GetComponent<CharScript>().currentHealth + ". Heal Counter: " + healCounter;
            }
        }
        else
        {

        }
            //Debug.Log("Heal Counter = 0");
    }

    private void RandomiseSkill()
    {
        int num_of_skills = enemy.GetComponent<Skills>().Skill_List.Length;
        i = Random.Range(0, num_of_skills);

        damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
        attack_element = enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type.ToString();

        if (enemy.GetComponent<Skills>().Skill_List[i].MP > 0)
        {
            enemy.GetComponent<Skills>().Skill_List[i].MP--;
        }
        else
        {
            RandomiseSkill();
        }
    }

    private void FixedTargetAttack()
    {
        RandomiseSkill();

        if (target_remaining == (int)OPPONENT.PLAYER)
        {
            player.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            enemy.GetComponent<Skills>().Skill_List[i].MP--;

            Debug.Log("Player Left, Companion Dead. Enemy using" + enemy.GetComponent<Skills>().Skill_List[i].Name +
            "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" +
            damage + " damage to Player");

            if (player.GetComponent<CharScript>().currentHealth <= 0)
            {
                num_enemies--;
                enemy_win = true;
                Debug.Log("Enemies Win");
            }
        }
        else if (target_remaining == (int)OPPONENT.COMPANION)
        {
            companion.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            enemy.GetComponent<Skills>().Skill_List[i].MP--;

            Debug.Log("Companion Left, Player Dead. Enemy using" + enemy.GetComponent<Skills>().Skill_List[i].Name +
           "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" +
           damage + " damage to Companion");

            if (companion.GetComponent<CharScript>().currentHealth <= 0)
            {
                num_enemies--;
                enemy_win = true;
                Debug.Log("Enemies Win");
            }
        }
    }

    private void RandomiseTarget()
    {
        target = Random.Range(0, opponent);

        if (target == (int)OPPONENT.PLAYER)
        {
            player.GetComponent<CharScript>().TakeDamage(damage, attack_element);

            //Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
            // "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + 
            // damage + " damage to Player");
            if (actionLogTextBox != null)
            {
                actionLogTextBox.text = enemy.transform.name + " is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
                 "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" +
                 damage + " damage to Player";
            }

            if (player.GetComponent<CharScript>().currentHealth <= 0)
            {
                target_remaining = (int)OPPONENT.COMPANION;
                num_enemies--;

                Debug.Log("Player Dead, number of enemies left: " + num_enemies);
            }
        }
        else
        {
            companion.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            
            Debug.Log(enemy.transform.name + " is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + 
             damage + " damage to Companion");

            if (companion.GetComponent<CharScript>().currentHealth <= 0)
            {
                target_remaining = (int)OPPONENT.PLAYER;
                num_enemies--;

                Debug.Log("Companion Dead, number of enemies left: " + num_enemies);
            }
            //Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
            // "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + 
            // damage + " damage to Companion");

            if (actionLogTextBox != null)
            {
                actionLogTextBox.text = enemy.transform.name + " is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" +
             damage + " damage to Companion";
            }
        }

        //gameManager.GetComponent<CombatManagerScript>().AddActionCounter(1);
    }
}