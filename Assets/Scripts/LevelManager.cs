using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void FirstLevel()
    {
        SceneManager.LoadScene("1");
    }

    public void SecondLevel()
    {

    }

    public void ThirdLevel()
    {

    }

    public void ReturnFromGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
