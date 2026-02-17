using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonesPause : MonoBehaviour
{
    public GameObject panelPause, botonCheck, botonWrong;
    private void Start()
    {
        GetComponent<EventTrigger>().enabled = false;
        GetComponent<Button>().interactable = false;
        RectTransform rectTransform = botonCheck.GetComponent<RectTransform>();
    }
    public void Pausa()
    {
        Time.timeScale = 0;
        panelPause.SetActive(true);
        RectTransform rectTransform = botonCheck.GetComponent<RectTransform>();
        rectTransform.localScale = Vector3.one;
    }

    public void BotonCheck()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }
    public void BotonWrong()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        Juego.animMezclado = false;
        SceneManager.LoadScene(2);
    }
}
