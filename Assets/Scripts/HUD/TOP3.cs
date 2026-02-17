using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TOP3 : MonoBehaviour
{
    public TextMeshProUGUI turnos1,turnos2, turnos3, tiempo1, tiempo2, tiempo3;
    string turnostxt = "Turnos", minutostxt = "Minutos", segundostxt = "Segundos", puntuaciontxt = "Puntuacion";
    private float[] turnos = new float[3];
    private float[] minutos = new float[3];
    private float[] segundos = new float[3];
    private float[] puntuacion = new float[3];
    private void Start()
    {
        for (int i = 0; i < turnos.Length; i++)
        {
            turnos[i] = CargarArray(turnostxt)[i];
            minutos[i] = CargarArray(minutostxt)[i];
            segundos[i] = CargarArray(segundostxt)[i];
            puntuacion[i] = CargarArray(puntuaciontxt)[i];
        }
        if (BotonMezcla.ganar)
        {
            GuardarPuntuaciones();
        }
        ImprimirTop3();
        //ResetearRanking();
    }
    void GuardarPuntuaciones()
    {
        float puntuacionPartida; 
        puntuacionPartida = 1 / (Reloj.tiempoActual + Juego.movimientos * 0.7f);
        if (puntuacionPartida > puntuacion[0])
        {
            turnos[2] = turnos[1];
            minutos[2] = minutos[1];
            segundos[2] = segundos[1];
            puntuacion[2] = puntuacion[1];
            turnos[1] = turnos[0];
            minutos[1] = minutos[0];
            segundos[1] = segundos[0];
            puntuacion[1] = puntuacion[0];
            turnos[0] = Juego.movimientos;
            minutos[0] = Reloj.minutos;
            segundos[0] = Reloj.segundos;
            puntuacion[0] = puntuacionPartida;
        }
        else if (puntuacionPartida > puntuacion[1])
        {
            turnos[2] = turnos[1];
            minutos[2] = minutos[1];
            segundos[2] = segundos[1];
            puntuacion[2] = puntuacion[1];
            turnos[1] = Juego.movimientos;
            minutos[1] = Reloj.minutos;
            segundos[1] = Reloj.segundos;
            puntuacion[1] = puntuacionPartida;
        }
        else if (puntuacionPartida > puntuacion[2])
        {
            turnos[2] = Juego.movimientos;
            minutos[2] = Reloj.minutos;
            segundos[2] = Reloj.segundos;
            puntuacion[2] = puntuacionPartida;
        }
        GuardarArray(turnostxt, turnos);
        GuardarArray(minutostxt, minutos);
        GuardarArray(segundostxt, segundos);
        GuardarArray(puntuaciontxt, puntuacion);
        PlayerPrefs.Save();
    }

    void GuardarArray(string clave, float[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            PlayerPrefs.SetFloat(clave + "_" + i, array[i]);
        }
    }

    float[] CargarArray(string clave)
    {
        float[] array = new float[3];
        for (int i = 0; i < 3; i++)
        {
            array[i] = PlayerPrefs.GetFloat(clave + "_" + i, 0);
        }
        return array;
    }

    void ImprimirTop3()
    {
        turnos1.text = turnos[0].ToString();
        tiempo1.text = string.Format("{0:00}:{1:00}", minutos[0], segundos[0]);
        turnos2.text = turnos[1].ToString();
        tiempo2.text = string.Format("{0:00}:{1:00}", minutos[1], segundos[1]);
        turnos3.text = turnos[2].ToString();
        tiempo3.text = string.Format("{0:00}:{1:00}", minutos[2], segundos[2]);
    }

    void ResetearRanking()
    {
        for (int i = 0; i < 3; i++)
        {
            PlayerPrefs.DeleteKey("Puntuacion_" + i);
            PlayerPrefs.DeleteKey("Turnos_" + i);
            PlayerPrefs.DeleteKey("Minutos_" + i);
            PlayerPrefs.DeleteKey("Segundos_" + i);
        }

        PlayerPrefs.Save();

        Debug.Log("Ranking reseteado correctamente.");
    }

}
