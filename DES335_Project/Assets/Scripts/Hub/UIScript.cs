using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{

    public Skills skill_Player, skill_Comp;

    [SerializeField]
    public List<TextMeshProUGUI> playerSkill1, playerSkill2, playerSkill3, playerSkill4, compSkill1, compSkill2, compSkill3, compSkill4;

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

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("CompSkill_1"))
        {

            compSkill1.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("CompSkill_2"))
        {

            compSkill2.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("CompSkill_3"))
        {

            compSkill3.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }

        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("CompSkill_4"))
        {

            compSkill4.Add(fooObj.GetComponentInChildren<TextMeshProUGUI>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (TextMeshProUGUI fooObj in playerSkill1)
        {
            fooObj.text = skill_Player.Skill_List[0].Name;
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

        foreach (TextMeshProUGUI fooObj in compSkill1)
        {
            fooObj.text = skill_Comp.Skill_List[0].Name;
        }

        foreach (TextMeshProUGUI fooObj in compSkill2)
        {
            fooObj.text = skill_Comp.Skill_List[1].Name;
        }

        foreach (TextMeshProUGUI fooObj in compSkill3)
        {
            fooObj.text = skill_Comp.Skill_List[2].Name;
        }

        foreach (TextMeshProUGUI fooObj in compSkill4)
        {
            fooObj.text = skill_Comp.Skill_List[3].Name;
        }
    }
}
