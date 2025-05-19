using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject SettingsPanel;
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Settings()
    {
        SettingsPanel.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        SettingsPanel.SetActive(false);
    }
}
