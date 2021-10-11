using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadMoodScene()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadTeamScene()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadGameScene()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadWinScene()
    {
        SceneManager.LoadScene(4);
    }
}
