using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Animator AnimatorAbout;

    private void Start()
    {
        AnimatorAbout.SetBool("IsOpen", false);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCreator()
    {
        AnimatorAbout.SetBool("IsOpen", !AnimatorAbout.GetBool("IsOpen"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}
