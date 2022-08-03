using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{

    public Skills skill_Player, skill_Comp;

    [SerializeField]
    public List<TextMeshProUGUI> playerSkill1, playerSkill2, playerSkill3, playerSkill4, CompSkill1, CompSkill2, CompSkill3, CompSkill4;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("PlayerSkill_1"))
        {

            playerSkill1.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("PlayerSkill_2"))
        {

            playerSkill2.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("PlayerSkill_3"))
        {

            playerSkill3.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("PlayerSkill_4"))
        {

            playerSkill4.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSkill1.Count != 0)
        {
            foreach (TextMeshProUGUI fooObj in playerSkill1)
            {
                fooObj.text = skill_Player.Skill_List[0].Name;
            }
        }

        foreach (TextMeshProUGUI fooObj in playerSkill2)
        {
            fooObj.text = skill_Player.Skill_List[1].Name;
        }

        foreach (TextMeshProUGUI fooObj in playerSkill3)
        {
            fooObj.text = skill_Player.Skill_List[2].Name;
        }

        foreach (TextMeshProUGUI fooObj in playerSkill4)
        {
            fooObj.text = skill_Player.Skill_List[3].Name;
        }
    }
}
