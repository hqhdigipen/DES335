using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SkillBehaviour : MonoBehaviour
{
    public GameObject[] mainWeaponSkills, mainArmorSkills, allyWeaponSkills, allyArmorSkills;
    public TextMeshProUGUI[] skillNames;
    public GameObject [] canvas;
    GameObject [] skillDialogue = new GameObject[4];
    GameObject[] weaponDialogue = new GameObject[4];
    GameObject[] armorDialogue = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Skill1Hover()
    {
        switch (skillNames[0].text)
        {
            case "Banshee Wall":
                //mainWeaponSkills[0].SetActive(true);
                skillDialogue[0] = Instantiate(mainWeaponSkills[0]) as GameObject;
                skillDialogue[1] = Instantiate(mainWeaponSkills[0]) as GameObject;
                skillDialogue[0].transform.SetParent(canvas[0].transform, false);
                skillDialogue[1].transform.SetParent(canvas[1].transform, false);
                Debug.Log("Hover");
                break;

        }
    }

    public void Skill1Exit()
    {
        switch (skillNames[0].text)
        {
            case "Banshee Wall":
                //mainWeaponSkills[0].SetActive(false);
                Destroy(skillDialogue[0].gameObject);
                Destroy(skillDialogue[1].gameObject);
                Debug.Log("Exit");
                break;

        }
    }


    public void Skill2Hover()
    {
        switch (skillNames[1].text)
        {
            case "Phantom Claw":
                mainWeaponSkills[1].SetActive(true);
                break;

        }
    }

    public void Skill2Exit()
    {
        switch (skillNames[1].text)
        {
            case "Phantom Claw":
                mainWeaponSkills[1].SetActive(false);
                break;

        }
    }

    public void Skill3Hover()
    {
        switch (skillNames[2].text)
        {
            case "Astral Plane":
                mainWeaponSkills[2].SetActive(true);
                break;

        }
    }

    public void Skill3Exit()
    {
        switch (skillNames[2].text)
        {
            case "Astral Plane":
                mainWeaponSkills[2].SetActive(false);
                break;

        }
    }

    public void Skill4Hover()
    {
        switch (skillNames[3].text)
        {
            case "Merciful Protection":
                mainWeaponSkills[3].SetActive(true);
                break;

        }
    }

    public void Skill4Exit()
    {
        switch (skillNames[3].text)
        {
            case "Merciful Protection":
                mainWeaponSkills[3].SetActive(false);
                break;

        }
    }

}
