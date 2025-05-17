using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
   public static SoundManager instance;
    [SerializeField] private AudioSource bgSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            if (bgSound != null)
            {
                bgSound.Play();
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
