using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScrpit : MonoBehaviour
{

    public GameObject creditPanel;

    public GameObject title;
    Animator titleAnimator;

    public GameObject ball;
    Animator ballAnimator;

    public GameObject play;
    Animator playAnimator;

    public GameObject credits;
    Animator creditsAnimator;

    public GameObject quit;
    Animator quitAnimator;

    void Start()
    {
        titleAnimator = title.GetComponent<Animator>();
        ballAnimator = ball.GetComponent<Animator>();
        playAnimator = play.GetComponent<Animator>();
        creditsAnimator = credits.GetComponent<Animator>();
        quitAnimator = quit.GetComponent<Animator>();
    }
    public void Play()
    {
        Debug.Log("Playing...");
        StartCoroutine("WaitAndLoad");
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void Credits()
    {
        Debug.Log("Showing Credits...");
        creditPanel.SetActive(true);
        //
    }

    public void Nice()
    {
        creditPanel.SetActive(false);
    }

    IEnumerator WaitAndLoad()
    {
        titleAnimator.SetBool("InMenu", false);
        ballAnimator.SetBool("InMenu", false);
        playAnimator.SetBool("InMenu", false);
        creditsAnimator.SetBool("InMenu", false);
        quitAnimator.SetBool("InMenu", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }
}
