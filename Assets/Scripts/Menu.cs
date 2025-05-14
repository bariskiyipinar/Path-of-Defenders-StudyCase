using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
  
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
