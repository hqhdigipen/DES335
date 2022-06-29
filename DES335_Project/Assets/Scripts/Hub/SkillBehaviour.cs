using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SkillBehaviour : MonoBehaviour
{
    public GameObject[] mainWeaponSkill, mainArmorSkill, allyWeaponSkill, allyArmorSkill;
    public TextMeshProUGUI[] dialogueNames;
    public GameObject [] canvas;
    GameObject [] dialogue = new GameObject[4];

    Color someColorValue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountdownVisible(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        dialogue[0].SetActive(true);
        dialogue[1].SetActive(true);
        dialogue[2].SetActive(true);

        StopCoroutine(CountdownVisible(1));
    }

    public void Skill1Hover()
    {
        switch (dialogueNames[0].text)
        {
            case "Banshee Wall":
                Cursor.visible = false;
                dialogue[0] = Instantiate(mainWeaponSkill[0]) as GameObject;
                dialogue[1] = Instantiate(mainWeaponSkill[0]) as GameObject;
                dialogue[2] = Instantiate(mainWeaponSkill[0]) as GameObject;
                dialogue[0].transform.SetParent(canvas[0].transform, false);
                dialogue[1].transform.SetParent(canvas[1].transform, false);
                dialogue[2].transform.SetParent(canvas[2].transform, false);

                dialogue[0].SetActive(true);
                dialogue[1].SetActive(true);
                dialogue[2].SetActive(true);
                Debug.Log("Hover");
                break;

        }
    }

    public void Skill1Exit()
    {
        switch (dialogueNames[0].text)
        {
            case "Banshee Wall":
                Cursor.visible = true;
                Destroy(dialogue[0].gameObject);
                Destroy(dialogue[1].gameObject);
                Destroy(dialogue[2].gameObject);
                Debug.Log("Exit");
                break;

        }
    }


    public void Skill2Hover()
    {
        switch (dialogueNames[1].text)
        {
            case "Phantom Claw":
                Cursor.visible = false;
                dialogue[0] = Instantiate(mainWeaponSkill[1]) as GameObject;
                dialogue[1] = Instantiate(mainWeaponSkill[1]) as GameObject;
                dialogue[2] = Instantiate(mainWeaponSkill[1]) as GameObject;
                dialogue[0].transform.SetParent(canvas[0].transform, false);
                dialogue[1].transform.SetParent(canvas[1].transform, false);
                dialogue[2].transform.SetParent(canvas[2].transform, false);
                dialogue[0].SetActive(true);
                dialogue[1].SetActive(true);
                dialogue[2].SetActive(true);
                Debug.Log("Hover");
                break;

        }
    }

    public void Skill2Exit()
    {
        switch (dialogueNames[1].text)
        {
            case "Phantom Claw":
                Cursor.visible = true;
                Destroy(dialogue[0].gameObject);
                Destroy(dialogue[1].gameObject);
                Destroy(dialogue[2].gameObject);
                Debug.Log("Exit");
                break;

        }
    }

    public void Skill3Hover()
    {
        switch (dialogueNames[2].text)
        {
            case "Astral Plane":
                Cursor.visible = false;
                dialogue[0] = Instantiate(mainWeaponSkill[2]) as GameObject;
                dialogue[1] = Instantiate(mainWeaponSkill[2]) as GameObject;
                dialogue[2] = Instantiate(mainWeaponSkill[2]) as GameObject;
                dialogue[0].transform.SetParent(canvas[0].transform, false);
                dialogue[1].transform.SetParent(canvas[1].transform, false);
                dialogue[2].transform.SetParent(canvas[2].transform, false);
                dialogue[0].SetActive(true);
                dialogue[1].SetActive(true);
                dialogue[2].SetActive(true);
                Debug.Log("Hover");
                break;

        }
    }

    public void Skill3Exit()
    {
        switch (dialogueNames[2].text)
        {
            case "Astral Plane":
                Cursor.visible = true;
                Destroy(dialogue[0].gameObject);
                Destroy(dialogue[1].gameObject);
                Destroy(dialogue[2].gameObject);
                Debug.Log("Exit");
                break;

        }
    }

    public void Skill4Hover()
    {
        switch (dialogueNames[3].text)
        {
            case "Merciful Protection":
                Cursor.visible = false;
                dialogue[0] = Instantiate(mainWeaponSkill[3]) as GameObject;
                dialogue[1] = Instantiate(mainWeaponSkill[3]) as GameObject;
                dialogue[2] = Instantiate(mainWeaponSkill[3]) as GameObject;
                dialogue[0].transform.SetParent(canvas[0].transform, false);
                dialogue[1].transform.SetParent(canvas[1].transform, false);
                dialogue[2].transform.SetParent(canvas[2].transform, false);
                dialogue[0].SetActive(true);
                dialogue[1].SetActive(true);
                dialogue[2].SetActive(true);
                Debug.Log("Hover");
                break;

        }
    }

    public void Skill4Exit()
    {
        switch (dialogueNames[3].text)
        {
            case "Merciful Protection":
                Cursor.visible = true;
                Destroy(dialogue[0].gameObject);
                Destroy(dialogue[1].gameObject);
                Destroy(dialogue[2].gameObject);
                Debug.Log("Exit");
                break;

        }
    }

}
