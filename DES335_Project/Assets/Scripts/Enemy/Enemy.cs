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
    string attack_element;

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
            RandomiseAttack();
            
            damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
            attack_element = enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type.ToString();
            enemy.GetComponent<Skills>().Skill_List[i].MP--;
            RandomiseTarget(damage, attack_element);
        }
    }

    public void Enemy_Attack()
    {
        
    }
    private void Heal()
    {

    }

    private void RandomiseAttack()
    {
        int num_of_skills = enemy.GetComponent<Skills>().Skill_List.Length;
        i = Random.Range(0, num_of_skills);
    }

    private void RandomiseTarget(int damage, string attack_element)
    {
        target = Random.Range(0, opponent);

        if (target == (int)OPPONENT.PLAYER)
        {
            player.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + damage + " damage to Player");
        }
        else
        {
            companion.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name +
             "(" + attack_element + enemy.GetComponent<Skills>().Skill_List[i].MP + "/5) , -" + damage + " damage to Companion");
        }
    }
}