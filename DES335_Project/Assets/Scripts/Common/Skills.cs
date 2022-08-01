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
    private static bool keypressed = false;

    public GameObject player, companion;

    //Player
    Skill PlayerEqLvl2Skill1 = new Skill("Slam", 15, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl2Skill2 = new Skill("Flame Rush", 20, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl2Skill3 = new Skill("Blaze Kick", 25, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl2Skill4 = new Skill("Inferno Claw ", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl3Skill1 = new Skill("Hyper Punch", 20, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl3Skill2 = new Skill("Flame Blitz", 25, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl3Skill3 = new Skill("Blaze Gigs", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl3Skill4 = new Skill("Inferno Blast", 35, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl4Skill1 = new Skill("Sonic Boom", 25, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl4Skill2 = new Skill("Flame Nado", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl4Skill3 = new Skill("Blaze Tempest", 35, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl4Skill4 = new Skill("Inferno Impact", 40, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill PlayerEqLvl5Skill1 = new Skill("Sonic Punch", 30, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerEqLvl5Skill2 = new Skill("Flame Call", 35, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl5Skill3 = new Skill("Blade Inferno", 40, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill PlayerAmourLvl5Skill4 = new Skill("Inferno Infinite", 45, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    //Companion
    Skill AllyEqLvl2Skill1 = new Skill("Magic Ring", 10, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyEqLvl2Skill2 = new Skill("Water Jet", 15, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl2Skill3 = new Skill("Aqua Splash", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl2Skill4 = new Skill("Hydro Blast", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill AllyEqLvl3Skill1 = new Skill("Magic Whirwind", 15, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyEqLvl3Skill2 = new Skill("Water Rush", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl3Skill3 = new Skill("Aqua Waterfall", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl3Skill4 = new Skill("Hydro Pump", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill AllyEqLvl4Skill1 = new Skill("Magic Vortex", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyEqLvl4Skill2 = new Skill("Water Blade", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl4Skill3 = new Skill("Aqua Surf", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl4Skill4 = new Skill("Hydro Beam", 35, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill AllyEqLvl5Skill1 = new Skill("Magic Tornado", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyEqLvl5Skill2 = new Skill("Water Bolt", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl5Skill3 = new Skill("Aqua Tsunami", 35, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill AllyAmourLvl5Skill4 = new Skill("Hydro Blast", 40, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    private void Start()
    {
        player = GameObject.Find("Player");
        companion = GameObject.Find("Companion");
    }

    // Update is called once per frame  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !keypressed)
        {
            keypressed = true;
            HubBehaviour.playerEqLvl++;
        }

        if (Input.GetKeyDown(KeyCode.W) && !keypressed)
        {
            keypressed = true;
            HubBehaviour.playerArmourLvl++;
        }

        if (Input.GetKeyDown(KeyCode.E) && !keypressed)
        {
            keypressed = true;
            HubBehaviour.allyEqLvl++;
        }

        if (Input.GetKeyDown(KeyCode.R) && !keypressed)
        {
            keypressed = true;
            HubBehaviour.allyAmourLvl++;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            keypressed = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            HubBehaviour.playerEqLvl = 1;
            HubBehaviour.playerArmourLvl = 1;
            HubBehaviour.allyEqLvl = 1;
            HubBehaviour.allyAmourLvl = 1;
        }

        //Player Eq
        if (HubBehaviour.playerEqLvl == 2)
        {
            player.GetComponent<Skills>().Skill_List[0] = PlayerEqLvl2Skill1;
            player.GetComponent<Skills>().Skill_List[1] = PlayerEqLvl2Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 3)
        {
            player.GetComponent<Skills>().Skill_List[0] = PlayerEqLvl3Skill1;
            player.GetComponent<Skills>().Skill_List[1] = PlayerEqLvl3Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 4)
        {
            player.GetComponent<Skills>().Skill_List[0] = PlayerEqLvl4Skill1;
            player.GetComponent<Skills>().Skill_List[1] = PlayerEqLvl4Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 5)
        {
            player.GetComponent<Skills>().Skill_List[0] = PlayerEqLvl5Skill1;
            player.GetComponent<Skills>().Skill_List[1] = PlayerEqLvl5Skill2;
        }

        //Player Amour
        if (HubBehaviour.playerArmourLvl == 2)
        {
            player.GetComponent<Skills>().Skill_List[2] = PlayerAmourLvl2Skill3;
            player.GetComponent<Skills>().Skill_List[3] = PlayerAmourLvl2Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 3)
        {
            player.GetComponent<Skills>().Skill_List[2] = PlayerAmourLvl3Skill3;
            player.GetComponent<Skills>().Skill_List[3] = PlayerAmourLvl3Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 4)
        {
            player.GetComponent<Skills>().Skill_List[2] = PlayerAmourLvl4Skill3;
            player.GetComponent<Skills>().Skill_List[3] = PlayerAmourLvl4Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 5)
        {
            player.GetComponent<Skills>().Skill_List[2] = PlayerAmourLvl5Skill3;
            player.GetComponent<Skills>().Skill_List[3] = PlayerAmourLvl5Skill4;
        }

        //Companion Eq
        if (HubBehaviour.allyEqLvl == 2)
        {
            companion.GetComponent<Skills>().Skill_List[0] = AllyEqLvl2Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = AllyEqLvl2Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 3)
        {
            companion.GetComponent<Skills>().Skill_List[0] = AllyEqLvl3Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = AllyEqLvl3Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 4)
        {
            companion.GetComponent<Skills>().Skill_List[0] = AllyEqLvl4Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = AllyEqLvl4Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 5)
        {
            companion.GetComponent<Skills>().Skill_List[0] = AllyEqLvl5Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = AllyEqLvl5Skill2;
        }

        //Companion Amour
        if (HubBehaviour.allyAmourLvl == 2)
        {
            companion.GetComponent<Skills>().Skill_List[2] = AllyAmourLvl2Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = AllyAmourLvl2Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 3)
        {
            companion.GetComponent<Skills>().Skill_List[2] = AllyAmourLvl3Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = AllyAmourLvl3Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 4)
        {
            companion.GetComponent<Skills>().Skill_List[2] = AllyAmourLvl4Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = AllyAmourLvl4Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 5)
        {
            companion.GetComponent<Skills>().Skill_List[2] = AllyAmourLvl5Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = AllyAmourLvl5Skill4;
        }
    }
}
