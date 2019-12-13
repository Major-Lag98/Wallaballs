using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScrpit : MonoBehaviour
{

    public GameObject creditPanel;
    public void Play()
    {
        Debug.Log("Playing...");
        SceneManager.LoadScene("GameScene");
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


}
