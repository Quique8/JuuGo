using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesInicio : MonoBehaviour
{
   public void Play()
   {
        Juego.movimientos = 0;
        Reloj.tiempoActual = 0;
        Juego.hueco = new Vector3(2.910205f, -3.93268f, 0);
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
