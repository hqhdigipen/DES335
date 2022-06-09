using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element_Skill_Type : MonoBehaviour
{
    public enum CHARACTER_ELEMENTS
    {
        Fire,
        Water,
        Earth
    }

    public enum SKILL_TYPE
    { 
        NORMAL,
        FIRE,
        WATER,
        EARTH,
    }

    public enum DAMAGE_TYPE
    { 
        SINGLE_TARGET,
        AOE,
        DOT
    }

    [System.Serializable]
    public struct Skill
    {
        public string Name;
        public int Damage;
        public SKILL_TYPE Skill_Type;
        public DAMAGE_TYPE Skill_Damage_Type;
    }

    public CHARACTER_ELEMENTS Character_Element;
    //public List<Skill> Skill_List = new List<Skill>();
    public Skill[] Skill_List = new Skill[4];
    void Start()
    {

}

// Update is called once per frame
void Update()
    {
        
    }
}
