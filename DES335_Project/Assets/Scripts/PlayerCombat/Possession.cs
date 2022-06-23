using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possession : MonoBehaviour
{
    public enum POSSESSED_CHARACTER_ELEMENTS
    {
        Fire,
        Water,
        Earth
    }
    public enum POSSESSED_SKILL_TYPE
    {
        Normal,
        Fire,
        Water,
        Earth,
    }

    public enum POSSESSED_DAMAGE_TYPE
    {
        SINGLE_TARGET,
        AOE,
        DOT
    }

    [System.Serializable]
    public struct Possessed_Skill
    {
        public string Name;
        public int Damage;
        public int MP;
        public POSSESSED_SKILL_TYPE Skill_Element_Type;
        public POSSESSED_DAMAGE_TYPE Skill_Damage_Type;
    }

    public POSSESSED_CHARACTER_ELEMENTS Possess_Character_Element;
    public Possessed_Skill[] Possessed_Skill_List = new Possessed_Skill[4];

    public GameObject companion, enemy, player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    void PossessEnemy()
    {

        for (int i = 0; i < 4; ++i)
        {
            Possessed_Skill_List[i].Name = enemy.GetComponent<Skills>().Skill_List[i].Name;
            Possessed_Skill_List[i].Damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
            Possessed_Skill_List[i].MP = enemy.GetComponent<Skills>().Skill_List[i].MP;
            Possessed_Skill_List[i].Skill_Element_Type = (POSSESSED_SKILL_TYPE)(int)enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type;
            Possessed_Skill_List[i].Skill_Damage_Type = (POSSESSED_DAMAGE_TYPE)(int)enemy.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type;

            Debug.Log("PS: " + Possessed_Skill_List[i].Name
                + " Damage: " + Possessed_Skill_List[i].Damage
                + " MP: " + Possessed_Skill_List[i].MP
                + " Skill Type: " + Possessed_Skill_List[i].Skill_Element_Type
                + "Damage Type: " + Possessed_Skill_List[i].Skill_Damage_Type); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            PossessEnemy();
        }
    }

}
