using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public enum CHARACTER_ELEMENTS
    {
        Fire,
        Water,
        Earth
    }

    public enum SKILL_TYPE
    { 
        Normal,
        Fire,
        Water,
        Earth,
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
        public int MP;
        public SKILL_TYPE Skill_Element_Type;
        public DAMAGE_TYPE Skill_Damage_Type;

    }

    public CHARACTER_ELEMENTS Character_Element;
    public Skill[] Skill_List = new Skill[4];
    void Start()
    {

}

// Update is called once per frame
void Update()
    {
        
    }
}
