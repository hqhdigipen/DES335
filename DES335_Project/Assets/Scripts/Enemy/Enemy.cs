using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //int num_enemies = 2;
    string attack_element;

    static int healCounter = 2;
    float healProbability = 0.0f;

    public GameObject player;
    public GameObject companion;
    public GameObject enemy;
    
    public void Start()
    {
        enemy = this.gameObject;
        companion = GameObject.FindGameObjectWithTag("Companion");
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            HealOrAttack();
        }
    }

    public void Enemy_Attack()
    {
        HealOrAttack();
    }
    private void HealOrAttack()
    {
        float hpPercentage = ((float)enemy.GetComponent<CharScript>().currentHealth 
                              / (float)enemy.GetComponent<CharScript>().maxHealth)*100.0f;

        Debug.Log("HP / Max HP : " + hpPercentage);

        if (healCounter == 0)
        {
            RandomiseAttack();
            return;
        }

        if (hpPercentage <= 25.0f)
        {
            healProbability = 50.0f;
            float random = Random.Range(0.0f, 100.0f);
            Debug.Log("Random Heal probability /100 : " + random);

            if (random <= healProbability)
                Heal();
            else
                RandomiseAttack(); 
        }
        else
            RandomiseAttack();
    }
    private void Heal()
    {
        Debug.Log("Enemy HP Before: " + enemy.GetComponent<CharScript>().currentHealth + ". Heal Counter: " + healCounter);

        if (healCounter != 0)
        {
            enemy.GetComponent<CharScript>().currentHealth = enemy.GetComponent<CharScript>().currentHealth +
              (enemy.GetComponent<CharScript>().maxHealth / 2);

            enemy.GetComponent<HealthBarScript>().SetHealth(enemy.GetComponent<CharScript>().currentHealth);

            healCounter--;

            Debug.Log("Enemy HP after heal: " + enemy.GetComponent<CharScript>().currentHealth + ". Heal Counter: " + healCounter);
        }
        else
            Debug.Log("Heal Counter = 0");
    }

    private void RandomiseAttack()
    {
        int num_of_skills = enemy.GetComponent<Skills>().Skill_List.Length;
        i = Random.Range(0, num_of_skills);

        damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
        attack_element = enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type.ToString();
        enemy.GetComponent<Skills>().Skill_List[i].MP--;
        RandomiseTarget(damage, attack_element);
    }

    private void RandomiseTarget(int damage, string attack_element)
    {
        target = Random.Range(0, opponent);

        if (target == (int)OPPONENT.PLAYER)
        {
            player.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            
            Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + 
             damage + " damage to Player");

           // if(player.GetComponent<CharScript>().currentHealth <= 0)
                
        }
        else
        {
            companion.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            
            Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + 
             damage + " damage to Companion");
        }
    }
}