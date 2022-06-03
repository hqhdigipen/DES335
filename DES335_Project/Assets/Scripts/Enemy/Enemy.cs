using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public enum ENEMY_TYPE 
    { 
      FIRE, 
      WATER, 
      EARTH 
    };
    
    public ENEMY_TYPE Element_Type;

    public List<string> attackList = new List<string>();
    private void AttackStart()
    {

       // CheckElement();
        //List<string> AttackList = new List<string> { "Attack1", "Attack2", "Attack3", "Attack4" };
        int i = Random.Range(0, attackList.Count);

        Debug.Log("Attack is" + attackList[i]);
    }

    private void CheckElement() 
    {
        //if(ENEMY_TYPE.FIRE)

    }
}