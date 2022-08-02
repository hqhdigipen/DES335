using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject player, companion, enemy, enemy2;

    Scene m_Scene;
    string sceneName;

    //Fire Skills
    Skill FireEqLvl1Skill1 = new Skill("Bash", 5, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireEqLvl1Skill2 = new Skill("Flame Blade", 10, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl1Skill3 = new Skill("Blaze", 15, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl1Skill4 = new Skill("Inferno Attack", 20, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill FireEqLvl2Skill1 = new Skill("Slam", 10, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireEqLvl2Skill2 = new Skill("Flame Rush", 15, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl2Skill3 = new Skill("Blaze Kick", 20, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl2Skill4 = new Skill("Inferno Claw ", 25, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill FireEqLvl3Skill1 = new Skill("Hyper Punch", 15, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireEqLvl3Skill2 = new Skill("Flame Blitz", 20, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl3Skill3 = new Skill("Blaze Gigs", 25, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl3Skill4 = new Skill("Inferno Blast", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill FireEqLvl4Skill1 = new Skill("Sonic Boom", 20, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireEqLvl4Skill2 = new Skill("Flame Nado", 25, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl4Skill3 = new Skill("Blaze Tempest", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl4Skill4 = new Skill("Inferno Impact", 35, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    Skill FireEqLvl5Skill1 = new Skill("Sonic Punch", 25, 5, SKILL_TYPE.Normal, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireEqLvl5Skill2 = new Skill("Flame Call", 30, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl5Skill3 = new Skill("Blade Inferno", 35, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);
    Skill FireAmourLvl5Skill4 = new Skill("Inferno Infinite", 40, 5, SKILL_TYPE.Fire, DAMAGE_TYPE.SINGLE_TARGET);

    //Water Skills
    Skill WaterEqLvl1Skill1 = new Skill("Water Splash", 5, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterEqLvl1Skill2 = new Skill("Magic Slash", 10, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl1Skill3 = new Skill("Aqua Jet", 15, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl1Skill4 = new Skill("Hydro Cannon", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill WaterEqLvl2Skill1 = new Skill("Water Ring", 10, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterEqLvl2Skill2 = new Skill("Water Jet", 15, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl2Skill3 = new Skill("Aqua Splash", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl2Skill4 = new Skill("Hydro Blast", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill WaterEqLvl3Skill1 = new Skill("Water Whirwind", 15, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterEqLvl3Skill2 = new Skill("Water Rush", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl3Skill3 = new Skill("Aqua Waterfall", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl3Skill4 = new Skill("Hydro Pump", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill WaterEqLvl4Skill1 = new Skill("Water Vortex", 20, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterEqLvl4Skill2 = new Skill("Water Blade", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl4Skill3 = new Skill("Aqua Surf", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl4Skill4 = new Skill("Hydro Beam", 35, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    Skill WaterEqLvl5Skill1 = new Skill("Water Tornado", 25, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterEqLvl5Skill2 = new Skill("Water Bolt", 30, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl5Skill3 = new Skill("Aqua Tsunami", 35, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);
    Skill WaterAmourLvl5Skill4 = new Skill("Hydro Blast", 40, 5, SKILL_TYPE.Water, DAMAGE_TYPE.SINGLE_TARGET);

    //Companion (Earth)
    Skill EarthEqLvl1Skill1 = new Skill("Earth Bound", 5, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthEqLvl1Skill2 = new Skill("Vine Whip", 10, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl1Skill3 = new Skill("Leaf Cut", 15, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl1Skill4 = new Skill("Solar Attack", 20, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);

    Skill EarthEqLvl2Skill1 = new Skill("Earth Ring", 10, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthEqLvl2Skill2 = new Skill("Vine Wrap", 15, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl2Skill3 = new Skill("Leaf Slash", 20, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl2Skill4 = new Skill("Solar Burst", 25, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);

    Skill EarthEqLvl3Skill1 = new Skill("Earth Twirl", 15, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthEqLvl3Skill2 = new Skill("Vine Trap", 20, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl3Skill3 = new Skill("Leaf Blade", 25, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl3Skill4 = new Skill("Solar Blast", 30, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);

    Skill EarthEqLvl4Skill1 = new Skill("Earth Blizzard", 20, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthEqLvl4Skill2 = new Skill("Vine Slash", 25, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl4Skill3 = new Skill("Leaf Lash", 30, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl4Skill4 = new Skill("Solar Beam", 35, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);

    Skill EarthEqLvl5Skill1 = new Skill("Earthquake", 25, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthEqLvl5Skill2 = new Skill("Vine Flare", 30, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl5Skill3 = new Skill("Leaf Storm", 35, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);
    Skill EarthAmourLvl5Skill4 = new Skill("Solar Power", 40, 5, SKILL_TYPE.Earth, DAMAGE_TYPE.SINGLE_TARGET);

    private void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;

        if (sceneName != "Hub")
        {
            player = GameObject.Find("Player");
            companion = GameObject.Find("Companion");
            enemy = GameObject.Find("Enemy");
            enemy2 = GameObject.Find("Enemy (1)");
        }
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

        /*
        Debug.Log("allyEqLvl: " + HubBehaviour.allyEqLvl + " allyAmourlvl: " + HubBehaviour.allyAmourLvl + 
            " Water: " + HubBehaviour.watertype + " Fire: " + HubBehaviour.firetype + " Earth: " + HubBehaviour.earthtype);
        */

        //Player Eq
        if (HubBehaviour.playerEqLvl == 1)
        {
            player.GetComponent<Skills>().Skill_List[0] = FireEqLvl1Skill1;
            player.GetComponent<Skills>().Skill_List[1] = FireEqLvl1Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 2)
        {
            player.GetComponent<Skills>().Skill_List[0] = FireEqLvl2Skill1;
            player.GetComponent<Skills>().Skill_List[1] = FireEqLvl2Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 3)
        {
            player.GetComponent<Skills>().Skill_List[0] = FireEqLvl3Skill1;
            player.GetComponent<Skills>().Skill_List[1] = FireEqLvl3Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 4)
        {
            player.GetComponent<Skills>().Skill_List[0] = FireEqLvl4Skill1;
            player.GetComponent<Skills>().Skill_List[1] = FireEqLvl4Skill2;
        }
        else if (HubBehaviour.playerEqLvl == 5)
        {
            player.GetComponent<Skills>().Skill_List[0] = FireEqLvl5Skill1;
            player.GetComponent<Skills>().Skill_List[1] = FireEqLvl5Skill2;
        }

        //Player Amour
        if (HubBehaviour.playerArmourLvl == 1)
        {
            player.GetComponent<Skills>().Skill_List[2] = FireAmourLvl1Skill3;
            player.GetComponent<Skills>().Skill_List[3] = FireAmourLvl1Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 2)
        {
            player.GetComponent<Skills>().Skill_List[2] = FireAmourLvl2Skill3;
            player.GetComponent<Skills>().Skill_List[3] = FireAmourLvl2Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 3)
        {
            player.GetComponent<Skills>().Skill_List[2] = FireAmourLvl3Skill3;
            player.GetComponent<Skills>().Skill_List[3] = FireAmourLvl3Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 4)
        {
            player.GetComponent<Skills>().Skill_List[2] = FireAmourLvl4Skill3;
            player.GetComponent<Skills>().Skill_List[3] = FireAmourLvl4Skill4;
        }
        else if (HubBehaviour.playerArmourLvl == 5)
        {
            player.GetComponent<Skills>().Skill_List[2] = FireAmourLvl5Skill3;
            player.GetComponent<Skills>().Skill_List[3] = FireAmourLvl5Skill4;
        }

        //Ally Water Type
        if (HubBehaviour.allyEqLvl == 1 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = WaterEqLvl1Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = WaterEqLvl1Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 2 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = WaterEqLvl2Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = WaterEqLvl2Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 3 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = WaterEqLvl3Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = WaterEqLvl3Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 4 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = WaterEqLvl4Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = WaterEqLvl4Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 5 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = WaterEqLvl5Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = WaterEqLvl5Skill2;
        }

        if (HubBehaviour.allyAmourLvl == 1 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl1Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl1Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 2 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl2Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl2Skill4;

        }
        else if (HubBehaviour.allyAmourLvl == 3 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl3Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl3Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 4 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl4Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl4Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 5 && HubBehaviour.watertype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl5Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl5Skill4;
        }

        //Ally Earth Type
        if (HubBehaviour.allyEqLvl == 1 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = EarthEqLvl1Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = EarthEqLvl1Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 2 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = EarthEqLvl2Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = EarthEqLvl2Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 3 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = EarthEqLvl3Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = EarthEqLvl3Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 4 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = EarthEqLvl4Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = EarthEqLvl4Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 5 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = EarthEqLvl5Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = EarthEqLvl5Skill2;
        }

        if (HubBehaviour.allyAmourLvl == 1 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl1Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl1Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 2 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl2Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl2Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 3 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl3Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl3Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 4 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl4Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl4Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 5 && HubBehaviour.earthtype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl5Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl5Skill4;
        }

        //Ally Fire Type
        if (HubBehaviour.allyEqLvl == 1 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = FireEqLvl1Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = FireEqLvl1Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 2 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = FireEqLvl2Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = FireEqLvl2Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 3 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = FireEqLvl3Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = FireEqLvl3Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 4 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = FireEqLvl4Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = FireEqLvl4Skill2;
        }
        else if (HubBehaviour.allyEqLvl == 5 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[0] = FireEqLvl5Skill1;
            companion.GetComponent<Skills>().Skill_List[1] = FireEqLvl5Skill2;
        }

        if (HubBehaviour.allyAmourLvl == 1 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = FireAmourLvl1Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = FireAmourLvl1Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 2 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = FireAmourLvl2Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = FireAmourLvl2Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 3 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = FireAmourLvl3Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = FireAmourLvl3Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 4 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = FireAmourLvl4Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = FireAmourLvl4Skill4;
        }
        else if (HubBehaviour.allyAmourLvl == 5 && HubBehaviour.firetype)
        {
            companion.GetComponent<Skills>().Skill_List[2] = FireAmourLvl5Skill3;
            companion.GetComponent<Skills>().Skill_List[3] = FireAmourLvl5Skill4;
        }

        if (enemy != null)
        {
            if (enemy.GetComponent<CharScript>().elementType == CharScript.ElementType.Earth)
            {
                enemy.GetComponent<Skills>().Skill_List[0] = EarthEqLvl1Skill1;
                enemy.GetComponent<Skills>().Skill_List[1] = EarthEqLvl1Skill2;
                enemy.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl1Skill3;
                enemy.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl1Skill4;
            }
            else if (enemy.GetComponent<CharScript>().elementType == CharScript.ElementType.Fire)
            {
                enemy.GetComponent<Skills>().Skill_List[0] = FireEqLvl1Skill1;
                enemy.GetComponent<Skills>().Skill_List[1] = FireEqLvl1Skill2;
                enemy.GetComponent<Skills>().Skill_List[2] = FireAmourLvl1Skill3;
                enemy.GetComponent<Skills>().Skill_List[3] = FireAmourLvl1Skill4;
            }
            else if (enemy.GetComponent<CharScript>().elementType == CharScript.ElementType.Water)
            {
                enemy.GetComponent<Skills>().Skill_List[0] = WaterEqLvl1Skill1;
                enemy.GetComponent<Skills>().Skill_List[1] = WaterEqLvl1Skill2;
                enemy.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl1Skill3;
                enemy.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl1Skill4;
            }
        }

        if (enemy2 != null)
        {
            if (enemy2.GetComponent<CharScript>().elementType == CharScript.ElementType.Earth)
            {
                enemy2.GetComponent<Skills>().Skill_List[0] = EarthEqLvl1Skill1;
                enemy2.GetComponent<Skills>().Skill_List[1] = EarthEqLvl1Skill2;
                enemy2.GetComponent<Skills>().Skill_List[2] = EarthAmourLvl1Skill3;
                enemy2.GetComponent<Skills>().Skill_List[3] = EarthAmourLvl1Skill4;
            }
            else if (enemy2.GetComponent<CharScript>().elementType == CharScript.ElementType.Fire)
            {
                enemy2.GetComponent<Skills>().Skill_List[0] = FireEqLvl1Skill1;
                enemy2.GetComponent<Skills>().Skill_List[1] = FireEqLvl1Skill2;
                enemy2.GetComponent<Skills>().Skill_List[2] = FireAmourLvl1Skill3;
                enemy2.GetComponent<Skills>().Skill_List[3] = FireAmourLvl1Skill4;
            }
            else if (enemy2.GetComponent<CharScript>().elementType == CharScript.ElementType.Water)
            {
                enemy2.GetComponent<Skills>().Skill_List[0] = WaterEqLvl1Skill1;
                enemy2.GetComponent<Skills>().Skill_List[1] = WaterEqLvl1Skill2;
                enemy2.GetComponent<Skills>().Skill_List[2] = WaterAmourLvl1Skill3;
                enemy2.GetComponent<Skills>().Skill_List[3] = WaterAmourLvl1Skill4;
            }
        }

        HubBehaviour.p1 = player.GetComponent<Skills>().Skill_List[0].Name;
        HubBehaviour.p2 = player.GetComponent<Skills>().Skill_List[1].Name;
        HubBehaviour.p3 = player.GetComponent<Skills>().Skill_List[2].Name;
        HubBehaviour.p4 = player.GetComponent<Skills>().Skill_List[3].Name;

        HubBehaviour.c1 = companion.GetComponent<Skills>().Skill_List[0].Name;
        HubBehaviour.c2 = companion.GetComponent<Skills>().Skill_List[1].Name;
        HubBehaviour.c3 = companion.GetComponent<Skills>().Skill_List[2].Name;
        HubBehaviour.c4 = companion.GetComponent<Skills>().Skill_List[3].Name;

        
        Debug.Log("Player S1: " + HubBehaviour.p1);
        Debug.Log("Player S2: " + HubBehaviour.p2);
        Debug.Log("Player S3: " + HubBehaviour.p3);
        Debug.Log("Player S4: " + HubBehaviour.p4);

        Debug.Log("Ally S1: " + HubBehaviour.c1);
        Debug.Log("Ally S2: " + HubBehaviour.c2);
        Debug.Log("Ally S3: " + HubBehaviour.c3);
        Debug.Log("Ally S4: " + HubBehaviour.c4);

    }
}
