using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{  
    int i = 0;

    public GameObject player;
    public GameObject enemy;
    
    public void Start()
    {
        enemy = this.gameObject;
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RandomiseAttack();

            int damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
            string attack_element = enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type.ToString();
            player.GetComponent<CharScript>().TakeDamage(damage, attack_element);
            Debug.Log("Enemy is using " + enemy.GetComponent<Skills>().Skill_List[i].Name + 
                "(" + attack_element +") , -" + damage + " damage to Player");


        }
    }

    private void RandomiseAttack()
    {
        int num_of_skills = enemy.GetComponent<Skills>().Skill_List.Length;
        i = Random.Range(0, num_of_skills);
        Debug.Log("Attack is" + enemy.GetComponent<Skills>().Skill_List[i].Name);
    }

    private void RandomiseTarget()
    {
       // if(player)
        //    player.GetComponent<CharScript>().TakeDamage(DamageList[i], Element_Type.ToString());

    }
}