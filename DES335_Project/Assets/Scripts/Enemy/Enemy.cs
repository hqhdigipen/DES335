using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum ENEMY_TYPE 
    { 
      Fire, 
      Water, 
      Earth 
    };
    
    public ENEMY_TYPE Element_Type;
    public GameObject player;
    int i = 0;

    public List<string> attackList = new List<string>();
    public List<int> DamageList = new List<int>();
    public void Enemy_Attack()
    {
       
    }   

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            RandomiseAttack();

            player.GetComponent<CharScript>().TakeDamage(DamageList[i], Element_Type.ToString());
            Debug.Log("Enemy is using " + attackList[i] + " , -" + DamageList[i] + " damage to Player");
        }
    }

    private void RandomiseAttack()
    {
        i = Random.Range(0, attackList.Count);
        Debug.Log("Attack is" + attackList[i]);
    }
}