using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Turnos : MonoBehaviour
{
    public TextMeshProUGUI turnos;
    private void Update()
    {
        if(Juego.movimientos > 999)
        {
            RectTransform rt = turnos.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(194.4f, -51.1f);
        }
    }
}
