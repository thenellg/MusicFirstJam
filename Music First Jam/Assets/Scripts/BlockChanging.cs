using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockChanging : MonoBehaviour
{
    public float volume = 0.2f;
    public int showingGroup;
    public GameObject group1;
    public GameObject group2;
    public GameObject group3;
    public GameObject group4;
    public Sprite color1;
    public Sprite color2;
    public Sprite color3;
    public Sprite color4;
    public Image currentInstrument;

    // Start is called before the first frame update
    void Start()
    {
        showingGroup = 1;
    }

    // Update is called once per frame
    void Update()
    {

        if (showingGroup == 1)
        {
            group1.SetActive(true);
            group2.SetActive(false);
            group3.SetActive(false);
            group4.SetActive(false);
            UIChange(1);
        }
        else if (showingGroup == 2)
        {
            group1.SetActive(false);
            group2.SetActive(true);
            group3.SetActive(false);
            group4.SetActive(false);
            UIChange(2);
        }
        else if (showingGroup == 3)
        {
            group1.SetActive(false);
            group2.SetActive(false);
            group3.SetActive(true);
            group4.SetActive(false);
            UIChange(3);
        }
        else
        {
            group1.SetActive(false);
            group2.SetActive(false);
            group3.SetActive(false);
            group4.SetActive(true);
            UIChange(4);
        }

    }

    void UIChange(int imageSelect)
    {
        if (imageSelect == 1)
        {
            currentInstrument.sprite = color1;
        }
        else if (imageSelect == 2)
        {
            currentInstrument.sprite = color2;
        }
        else if (imageSelect == 3)
        {
            currentInstrument.sprite = color3;
        }
        else if (imageSelect == 4)
        {
            currentInstrument.sprite = color4;
        }
    }
}
