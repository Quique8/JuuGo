using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioVictoria : MonoBehaviour
{
    void Update()
    {
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            Destroy(gameObject);
        }
    }
}
