using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reloj : MonoBehaviour
{
    public TextMeshProUGUI minutero;
    public static float tiempoActual = 0;
    public static int minutos, segundos;
    
    private void Update()
    {
        if (!Juego.animMezclado)
        {
            tiempoActual += Time.deltaTime;
            ActualizarReloj();
        }
    }

    void ActualizarReloj()
    {
        minutos = Mathf.FloorToInt(tiempoActual / 60);
        segundos = Mathf.FloorToInt(tiempoActual % 60);
        minutero.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
