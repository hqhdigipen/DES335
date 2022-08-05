using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchImageScript : MonoBehaviour
{
    public SpriteRenderer boss;
    public List<Sprite> imageList;
    int currImage;
    // Start is called before the first frame update
    void Start()
    {
        currImage = 0;
        boss.sprite = imageList[currImage];
    }

    // Update is called once per frame
    void Update()
    {
        boss.sprite = imageList[currImage];

        if (Input.GetKeyDown(KeyCode.L))
        {
            ++currImage;

            if (currImage > 4)
            {
                currImage = 0;
            }
        }
    }
}
