using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueBtn : MonoBehaviour
{
    public GameObject[] dialogueCanvas;
    public GameObject[] dialogueParent;
    List<GameObject> dialoguePrefab = new List<GameObject>();

    GameObject prefabMsg;

    GameObject cBtn;

    Transform pos;

    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        cBtn = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ExitDialogue()
    {
        if (prefabMsg != null)
        {
            Cursor.visible = true;
            Destroy(prefabMsg.gameObject);
        }
    }


    public void DialoguePopUp()
    {
    
                switch (cBtn.GetComponentInChildren<TextMeshProUGUI>().text)
                {
                    case "Banshee Wail":

                        foreach (GameObject d in dialogueCanvas)
                        {
                            if (d.name.Contains("Banshee Wail"))
                            {
                                prefabMsg =Instantiate(d) as GameObject;
                                prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                                prefabMsg.transform.position = Input.mousePosition;
                                prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                                prefabMsg.SetActive(true);
                            }
                        }
                        Debug.Log("Banshee Wail");
                        break;
                    case "Bash":

                        foreach (GameObject d in dialogueCanvas)
                        {
                            if (d.name.Contains("Bash"))
                            {
                                prefabMsg = Instantiate(d) as GameObject;
                                prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                                prefabMsg.transform.position = Input.mousePosition;
                                prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                                prefabMsg.SetActive(true);

                            }
                        }
                        Debug.Log("Bash");
                        break;

            case "Hibernation":

                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Hibernation"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Hibernation");
                break;

                case "Vine Whip":

                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Vine Whip"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Vine Whip");
                break;

                case "Phantom Claw":
                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Phantom Claw"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Phantom Claw");
                break;

                case "Astral Plane":

                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Astral Plane"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Astral Plane");
                break;

                case "Merciful Protection":

                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Merciful Protection"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Merciful Protection");
                break;

                case "Earth Cloak":

                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Earth Cloak"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Earth Cloak");
                break;

                case "Earth Orb":
                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Earth Orb"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Earth Orb");
                break;

            case "Toughen":
                foreach (GameObject d in dialogueCanvas)
                {
                    if (d.name.Contains("Toughen"))
                    {
                        prefabMsg = Instantiate(d) as GameObject;
                        prefabMsg.transform.SetParent(cBtn.transform.parent.gameObject.transform, false);
                        prefabMsg.transform.position = Input.mousePosition;
                        prefabMsg.transform.position = new Vector3(prefabMsg.transform.position.x, prefabMsg.transform.position.y + 100);
                        prefabMsg.SetActive(true);

                    }
                }
                Debug.Log("Toughen");
                break;
        }

    }

}
