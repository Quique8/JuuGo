using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pantalla : MonoBehaviour
{
    void Start()
    {
        // Establecer un aspecto fijo de 16:9
        float targetAspect = 16f / 9f;

        // Obtener la relación de aspecto de la pantalla actual
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Calcular el ajuste necesario
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = Camera.main;

        if (scaleHeight < 1.0f)
        {
            // Si la altura es la que se va a ajustar
            Rect rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;
            camera.rect = rect;
        }
        else
        {
            // Si la anchura es la que se va a ajustar
            float scaleWidth = 1.0f / scaleHeight;
            Rect rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;
            camera.rect = rect;
        }
    }

}
