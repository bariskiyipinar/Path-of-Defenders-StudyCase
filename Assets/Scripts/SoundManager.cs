using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;
    [SerializeField] private AudioSource bgSound;
    [SerializeField] private Toggle SoundToggle;


 
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (bgSound != null && SoundToggle != null)
            {
                bgSound.Play();

                if (SoundToggle.isOn)
                    bgSound.Play(); 
                else
                    bgSound.Stop();

                SoundToggle.onValueChanged.AddListener(OnToggleChanged);
            }
         
       
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnToggleChanged(bool isOn)
    {
        if (isOn)
            bgSound.Play();
        else
            bgSound.Pause(); 
    }

}
