using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActualizarHUD : MonoBehaviour
{
    public TextMeshProUGUI turnos;

    private void Start()
    {
        Actualizar();
        Time.timeScale = 0f;
    }
    void Actualizar()
    {
        turnos.text = Juego.movimientos.ToString();
    }
}
