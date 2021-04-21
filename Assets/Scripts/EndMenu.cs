using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndMenu : MonoBehaviour
{
    public Text ScoreText;
    public GameObject statTrackerObject;
    public StatTracker statTracker;

    private void Start()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
