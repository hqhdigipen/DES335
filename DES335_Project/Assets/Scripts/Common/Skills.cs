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

        public Skill(string v1, int v2, int v3, SKILL_TYPE skill_type, DAMAGE_TYPE damage_type) : this()
        {
            Name = v1;
            Damage = v2;
            MP = v3;
            Skill_Element_Type = skill_type;
            Skill_Damage_Type = damage_type;
        }
    }

    public CHARACTER_ELEMENTS Character_Element;
    public Skill[] Skill_List = new Skill[4];
    //private Skill[] Skills_Upgraded_List = new Skill[4];

    public GameObject player, companion;

    Skill PlayerEqLvl2Skill1 = new Skill("Skill1Level2", 50, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl3Skill1 = new Skill("Skill1Level3", 60, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl4Skill1 = new Skill("Skill1Level4", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl5Skill1 = new Skill("Skill1Level5", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl2Skill2 = new Skill("Skill2Level2", 50, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl3Skill2 = new Skill("Skill2Level3", 60, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl4Skill2 = new Skill("Skill2Level4", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl5Skill2 = new Skill("Skill2Level5", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl2Skill3 = new Skill("Skill2Level2", 50, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl3Skill3 = new Skill("Skill2Level3", 60, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl4Skill3 = new Skill("Skill2Level4", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl5Skill3 = new Skill("Skill2Level5", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl2Skill4 = new Skill("Skill2Level2", 50, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl3Skill4 = new Skill("Skill2Level3", 60, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl4Skill4 = new Skill("Skill2Level4", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl5Skill4 = new Skill("Skill2Level5", 70, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    // Update is called once per frame
    void Update()
    {
        if (HubBehaviour.playerEqLvl == 2)
        {
            player.GetComponent<Skills>().Skill_List[0] = PlayerEqLvl2Skill1;
            player.GetComponent<Skills>().Skill_List[1] = PlayerEqLvl2Skill2;
            player.GetComponent<Skills>().Skill_List[2] = PlayerEqLvl2Skill3;
            player.GetComponent<Skills>().Skill_List[3] = PlayerEqLvl2Skill4;
        }
    }
}
