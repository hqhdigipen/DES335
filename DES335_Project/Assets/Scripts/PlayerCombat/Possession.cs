using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum POSSESSED_CHARACTER_ELEMENTS
{
    Fire,
    Water,
    Earth
}
public class Possession : MonoBehaviour
{
   enum OPPONENT
    {
        ENEMY,
        ENEMY2
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

    public GameObject PossessButton;
    public GameObject companion, enemy, enemy2, player;
    private string currState;
    public static bool possessed = false;
    public static int EnemyElementType;

    int numOfEnemy = 2;
    static int target_remaining = 2;

    public static List <string> eName, eSkill;
    public static List<int> eDmg, eMp;
    public static List<string> eElementalType, eDmgType;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        PossessButton = GameObject.Find("PossessButton");
        companion = GameObject.FindGameObjectWithTag("Companion");


        if (PossessButton != null)
        {
            PossessButton.SetActive(false);
        }
    }
    public void PossessEnemy()
    {
        possessed = true; 

        for (int i = 0; i < 4; ++i)
        {
            if (target_remaining == (int)OPPONENT.ENEMY)
            {
                Possessed_Skill_List[i].Name = enemy.GetComponent<Skills>().Skill_List[i].Name;
                Possessed_Skill_List[i].Damage = enemy.GetComponent<Skills>().Skill_List[i].Damage;
                Possessed_Skill_List[i].MP = enemy.GetComponent<Skills>().Skill_List[i].MP;
                Possessed_Skill_List[i].Skill_Element_Type = (POSSESSED_SKILL_TYPE)(int)enemy.GetComponent<Skills>().Skill_List[i].Skill_Element_Type;
                Possessed_Skill_List[i].Skill_Damage_Type = (POSSESSED_DAMAGE_TYPE)(int)enemy.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type;

                enemy.GetComponent<CharScript>().currentHealth = 0;
            }
            else if(target_remaining == (int)OPPONENT.ENEMY2)
            {
                Possessed_Skill_List[i].Name = enemy2.GetComponent<Skills>().Skill_List[i].Name;
                Possessed_Skill_List[i].Damage = enemy2.GetComponent<Skills>().Skill_List[i].Damage;
                Possessed_Skill_List[i].MP = enemy2.GetComponent<Skills>().Skill_List[i].MP;
                Possessed_Skill_List[i].Skill_Element_Type = (POSSESSED_SKILL_TYPE)(int)enemy2.GetComponent<Skills>().Skill_List[i].Skill_Element_Type;
                Possessed_Skill_List[i].Skill_Damage_Type = (POSSESSED_DAMAGE_TYPE)(int)enemy2.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type;

                enemy2.GetComponent<CharScript>().currentHealth = 0;
            }

            switch(EnemyElementType)
            {
                case 0:
                    HubBehaviour.firetype_P = true;
                    HubBehaviour.watertype_P = false;
                    HubBehaviour.earthtype_P = false;
                    break;
                case 1:
                    HubBehaviour.firetype_P = false;
                    HubBehaviour.watertype_P = true;
                    HubBehaviour.earthtype_P = false;
                    break;
                case 2:
                    HubBehaviour.firetype_P = false;
                    HubBehaviour.watertype_P = false;
                    HubBehaviour.earthtype_P = true;
                    break;
            }

            /*
            eName.Add(Possessed_Skill_List[i].Name.ToString());
            eDmg.Add(Possessed_Skill_List[i].Damage);
            eMp.Add(Possessed_Skill_List[i].MP);
            eElementalType.Add(Possessed_Skill_List[i].Skill_Element_Type.ToString());
            eDmgType.Add(Possessed_Skill_List[i].Skill_Damage_Type.ToString());

            Debug.Log("Name: " + eName + " Dmg:"+eDmg+" MP:" +eMp+" Element Type: " +eElementalType+" DMG Type:" +eDmgType);
            */

            player.GetComponent<Skills>().Skill_List[i].Name = Possessed_Skill_List[i].Name;
            player.GetComponent<Skills>().Skill_List[i].Damage = Possessed_Skill_List[i].Damage;
            player.GetComponent<Skills>().Skill_List[i].MP = Possessed_Skill_List[i].MP;
            player.GetComponent<Skills>().Skill_List[i].Skill_Element_Type = (Skills.SKILL_TYPE)Possessed_Skill_List[i].Skill_Element_Type;
            player.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type = (Skills.DAMAGE_TYPE)Possessed_Skill_List[i].Skill_Damage_Type;

            HubBehaviour.s1 = Possessed_Skill_List[0].Name;
            HubBehaviour.s2 = Possessed_Skill_List[1].Name;
            HubBehaviour.s3 = Possessed_Skill_List[2].Name;
            HubBehaviour.s4 = Possessed_Skill_List[3].Name;

            /*
            Debug.Log("S1: " + HubBehaviour.s1);
            Debug.Log("S2: " + HubBehaviour.s2);
            Debug.Log("S3: " + HubBehaviour.s3);
            Debug.Log("S4: " + HubBehaviour.s4);
            */

            /*
           Debug.Log("PS: " + player.GetComponent<Skills>().Skill_List[i].Name
           + " Damage: " + player.GetComponent<Skills>().Skill_List[i].Damage
           + " MP: " + player.GetComponent<Skills>().Skill_List[i].MP
           + " Skill Type: " + player.GetComponent<Skills>().Skill_List[i].Skill_Element_Type
           + "Damage Type: " + player.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type);
            */
        }
    }

    public void PossessButtonPopUp()
    {
        if (enemy != null)
        {
            if (enemy.GetComponent<CharScript>().currentHealth <= 0)
            {
                target_remaining = (int)OPPONENT.ENEMY2;

                if (numOfEnemy == 2)
                    numOfEnemy = 1;

                // Debug.Log("Enemy2 Left, Enemy Dead");
            }
        }

        if (enemy2 != null)
        {
            if (enemy2.GetComponent<CharScript>().currentHealth <= 0)
            {
                if (numOfEnemy == 2)
                    numOfEnemy = 1;

                target_remaining = (int)OPPONENT.ENEMY;
                //Debug.Log("Enemy Left, Enemy2 Dead");
            }
        }

      //  Debug.Log("number of enemies left: " + numOfEnemy);

        if (numOfEnemy == 1)
        {
            if (target_remaining == (int)OPPONENT.ENEMY)
            {
                float hp = ((float)enemy.GetComponent<CharScript>().currentHealth / (float)enemy.GetComponent<CharScript>().maxHealth);
                hp *= 100;
               // Debug.Log("Enemy HP%: " + hp);

                if (hp < 25 && hp > 0)
                {
                    if (PossessButton != null)
                    {
                        PossessButton.SetActive(true);
                        EnemyElementType = (int)enemy.GetComponent<CharScript>().elementType;
                        Debug.Log("Possessed Enemy1 Type: " + EnemyElementType);
                    }
                }
            }
            else if (target_remaining == (int)OPPONENT.ENEMY2)
            {
                float hp = ((float)enemy2.GetComponent<CharScript>().currentHealth / (float)enemy2.GetComponent<CharScript>().maxHealth);
                hp *= 100;
              //  Debug.Log("Enemy2 HP%: " + hp);

                if (hp < 25 && hp >0)
                {
                    if (PossessButton != null)
                    {
                        PossessButton.SetActive(true);
                        EnemyElementType = (int)enemy2.GetComponent<CharScript>().elementType;
                        Debug.Log("Possessed Enemy2 Type: " + EnemyElementType);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfEnemy > 0)
            PossessButtonPopUp();
        else
            return;

        HubBehaviour.p1 = player.GetComponent<Skills>().Skill_List[0].Name;
        HubBehaviour.p2 = player.GetComponent<Skills>().Skill_List[1].Name;
        HubBehaviour.p3 = player.GetComponent<Skills>().Skill_List[2].Name;
        HubBehaviour.p4 = player.GetComponent<Skills>().Skill_List[3].Name;

        HubBehaviour.c1 = companion.GetComponent<Skills>().Skill_List[0].Name;
        HubBehaviour.c2 = companion.GetComponent<Skills>().Skill_List[1].Name;
        HubBehaviour.c3 = companion.GetComponent<Skills>().Skill_List[2].Name;
        HubBehaviour.c4 = companion.GetComponent<Skills>().Skill_List[3].Name;
    }
}
