using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScrpit : MonoBehaviour
{
    bool InMenu = true;
    bool InCredits = false;

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

    public GameObject credBalls;
    Animator credBallsAnimator;

    public GameObject madeBy;
    Animator madeByAnimator;

    public GameObject special;
    Animator specialAnimator;

    public GameObject nice;
    Animator niceAnimator;

    void Start()
    {
        titleAnimator = title.GetComponent<Animator>();
        ballAnimator = ball.GetComponent<Animator>();
        playAnimator = play.GetComponent<Animator>();
        creditsAnimator = credits.GetComponent<Animator>();
        quitAnimator = quit.GetComponent<Animator>();

        credBallsAnimator = credBalls.GetComponent<Animator>();
        madeByAnimator = madeBy.GetComponent<Animator>();
        specialAnimator = special.GetComponent<Animator>();
        niceAnimator = nice.GetComponent<Animator>();
    }
    public void Play()
    {
        //Debug.Log("Playing...");
        InMenu = false;
        StartCoroutine("WaitAndLoadGame");
    }

    public void Quit()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void Credits()
    {
        Debug.Log("Showing Credits...");
        InMenu = false;
        InCredits = true;
        StartCoroutine("WaitAndLoadCredits");
        //creditPanel.SetActive(true);
        //
    }

    public void Nice()
    {
        InCredits = false;
        InMenu = true;
        StartCoroutine("WaitAndLoadMenu");
        //creditPanel.SetActive(false);
    }

    void menuAnimationBools()
    {
        titleAnimator.SetBool("InMenu", InMenu);
        ballAnimator.SetBool("InMenu", InMenu);
        playAnimator.SetBool("InMenu", InMenu);
        creditsAnimator.SetBool("InMenu", InMenu);
        quitAnimator.SetBool("InMenu", InMenu);
    }
    void creditsAnimationBools()
    {
        credBallsAnimator.SetBool("InCredits", InCredits);
        madeByAnimator.SetBool("InCredits", InCredits);
        specialAnimator.SetBool("InCredits", InCredits);
        niceAnimator.SetBool("InCredits", InCredits);
    }

    IEnumerator WaitAndLoadGame()
    {
        menuAnimationBools();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameScene");
    }

    IEnumerator WaitAndLoadCredits()
    {
        menuAnimationBools();
        yield return new WaitForSeconds(1);
        creditPanel.SetActive(true);
        creditsAnimationBools();
    }

    IEnumerator WaitAndLoadMenu()
    {
        creditsAnimationBools();
        yield return new WaitForSeconds(1);
        creditPanel.SetActive(false);
        menuAnimationBools();
    }
}
