using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SkillBehaviour : MonoBehaviour
{
    public GameObject[] dialogueSkill;
    public TextMeshProUGUI[] weaponSkillList, armorSkillList;
    public GameObject [] canvas;
    List <GameObject> dialogue = new List<GameObject>();

    bool check;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void W1Hover()
    {
        check = true;
        foreach (TextMeshProUGUI t in weaponSkillList)
        {
            if (check)
            {
                switch (t.text)
                {
                    case "Banshee Wail":
                        Cursor.visible = false;

                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Banshee Wail"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Banshee Wail");
                        check = false;
                        break;
                    case "Bash":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Bash"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        check = false;
                        Debug.Log("Bash");
                        break;

                }
            }
        }
    }

    public void W2Hover()
    {
        check = true;
        foreach (TextMeshProUGUI t in weaponSkillList)
        {
            if (check)
            {
                switch (t.text)
                {
                    case "Phantom Claw":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Phantom Claw"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Phantom Claw");
                        check = false;
                        break;
                    case "Vine Whip":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Vine Whip"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Vine Whip");
                        check = false;
                        break;

                }
            }
        }
    }

    public void ExitHover()
    {
        Cursor.visible = true;
        
        foreach (GameObject d in dialogue) {
            Destroy(d.gameObject);
        }
        dialogue.Clear();
    }




    public void A1Hover()
    {
        check = true;
        foreach (TextMeshProUGUI t in armorSkillList)
        {
            if (check)
            {
                switch (t.text)
                {
                    case "Astral Plane":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Astral Plane"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Astral Plane");
                        check = false;
                        break;
                    case "Hibernation":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Hibernation"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Hibernation");
                        check = false;
                        break;

                }
            }
        }
    }

   

    public void A2Hover()
    {
        check = true;
        foreach (TextMeshProUGUI t in armorSkillList)
        {
            if (check)
            {
                switch (t.text)
                {
                    case "Merciful Protection":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Merciful Protection"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Merciful Protection");
                        check = false;
                        break;
                    case "Toughen":
                        Cursor.visible = false;
                        foreach (GameObject d in dialogueSkill)
                        {
                            if (d.name.Contains("Toughen"))
                            {
                                for (int i = 0; i < canvas.Length; i++)
                                {
                                    dialogue.Add(Instantiate(d) as GameObject);
                                    dialogue[i].transform.SetParent(canvas[i].transform, false);
                                    dialogue[i].SetActive(true);
                                }
                            }
                        }
                        Debug.Log("Toughen");
                        check = false;
                        break;
                }
            }
        }
    }

}
