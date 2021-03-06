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

    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        PossessButton = GameObject.Find("PossessButton");

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

            player.GetComponent<Skills>().Skill_List[i].Name = Possessed_Skill_List[i].Name;
            player.GetComponent<Skills>().Skill_List[i].Damage = Possessed_Skill_List[i].Damage;
            player.GetComponent<Skills>().Skill_List[i].MP = Possessed_Skill_List[i].MP;
            player.GetComponent<Skills>().Skill_List[i].Skill_Element_Type = (Skills.SKILL_TYPE)Possessed_Skill_List[i].Skill_Element_Type;
            player.GetComponent<Skills>().Skill_List[i].Skill_Damage_Type = (Skills.DAMAGE_TYPE)Possessed_Skill_List[i].Skill_Damage_Type;

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
        if (enemy.GetComponent<CharScript>().currentHealth <= 0)
        {          
            target_remaining = (int)OPPONENT.ENEMY2;

            if(numOfEnemy == 2)
                numOfEnemy = 1;
            
           // Debug.Log("Enemy2 Left, Enemy Dead");
        }

        if (enemy2.GetComponent<CharScript>().currentHealth <= 0)
        {
            if (numOfEnemy == 2)
                numOfEnemy = 1;
            
            target_remaining = (int)OPPONENT.ENEMY;
            //Debug.Log("Enemy Left, Enemy2 Dead");
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
    }
}
