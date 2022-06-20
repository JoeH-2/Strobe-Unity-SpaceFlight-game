using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelMenu : MonoBehaviour
{
    public int num = -1;
    public TextMeshProUGUI textMesh;
    public GameObject MainMenu;
    public GameObject Self;
    [SerializeField] private Animator SystemAnimation;
    [SerializeField] private Animator ImageAnimation;
    public int level;
    public RawImage image;
    public GameObject Parentimage;
    public Texture[] images = new Texture[10];
    public string LevelName;
    public bool isChanging;

    void Start()
    {
        GameObject gamemanager = GameObject.Find("GameManager");
        level = gamemanager.GetComponent<GameManager>().Level;
        Parentimage.SetActive(true);
    }

    public void NextSystem ()
    {
        if (isChanging == false)
        {
            num = num + 1;
        }
    }

    public void PreviousSystem ()
    {
        if (isChanging == false)
        {
            if (num >= 0)
            {
                num = num - 1;
            }
        }
    }

    void Update ()
    {
        if (num == -1)
        {
            MainMenu.GetComponent<Menu>().MenuOnScreen();
            SystemTextOff();
            StartCoroutine(ChangeImage());
        }

        if (num == 0)
        {
            StartCoroutine(ChangeImage());
            SystemTextOn();
            if (level >= 1)
            {
                Self.SetActive(true);
                LevelName = "Horizontal Training";
            }
            else
            {
                LevelName = "Locked";
            }
        }

        if (num == 1)
        {
            StartCoroutine(ChangeImage());
            if (level >= 2)
            {
                Self.SetActive(true);
                LevelName = "Vertical Training";
                
            }
            else
            {
                LevelName = "Locked";
            }
        }

        if (num == 2)
        {
            StartCoroutine(ChangeImage());
            if (level >= 3)
            {
                Self.SetActive(true);
                LevelName = "Diagonal Training";
            }
            else
            {
                LevelName = "Locked";
            }
        }
    }
    
    IEnumerator ChangeImage()
    {
        isChanging = true;
        if (num == 0)
        {
            ImageAnimation.SetBool("OnScreen", false);
            isChanging = false;
        }
        if (num == -1)
        {
            ImageAnimation.SetBool("OnScreen", false);
            isChanging = false;
        }
        else
        {
            ImageAnimation.SetBool("OnScreen", false);
            yield return new WaitForSeconds(0.5f);
            image.texture = images[num+1];
            textMesh.text = LevelName;
            ImageAnimation.SetBool("OnScreen", true);
            isChanging = false;
        }
    }

    public void SystemTextOn()
    {
        SystemAnimation.SetBool("OnScreen", true);
    }

    public void SystemTextOff()
    {
        SystemAnimation.SetBool("OnScreen", false);
    }
}