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

    public List<string> attackList = new List<string>();
    public List<int> DamageList = new List<int>();
    public void Enemy_Attack()
    {
        int i = Random.Range(0, attackList.Count);
        Debug.Log("Attack is" + attackList[i]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            player.GetComponent<CharScript>().TakeDamage(10, Element_Type.ToString());
            Debug.Log("A key is pressed, player taking 10 damage");

        }
    }
}