using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private Animation anim;
    [SerializeField] private Animator LevelAnimation;
    [SerializeField] private Animator OptionsAnimation;
    [SerializeField] private Animator ExitAnimation;

    public void QuitGame ()
    {
        Application.Quit();
    }

    public void MenuOnScreen()
    {
        LevelAnimation.SetBool("OnScreen", true);
        OptionsAnimation.SetBool("OnScreen", true);
        ExitAnimation.SetBool("OnScreen", true);
    }

    public void MenuOffScreen()
    {
        LevelAnimation.SetBool("OnScreen", false);
        OptionsAnimation.SetBool("OnScreen", false);
        ExitAnimation.SetBool("OnScreen", false);
    }
}