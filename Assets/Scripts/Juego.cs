using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public static Vector3 hueco = new Vector3(2.910205f, -3.93268f, 0); // Posición del hueco.
    private static GameObject fichaEnMovimiento = null; // Referencia a la ficha en movimiento.
    public GameObject audioMov;
    public static int movimientos;
    public static bool animMezclado = false;

    private void Start()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false;
    }
    private void Update()
    {
        Turnos turnos = FindObjectOfType<Turnos>();
        turnos.turnos.text = movimientos.ToString();
    }
    private void OnMouseDown()
    {
        if (fichaEnMovimiento != null) return;

        if (!animMezclado)
        {
            if (EsAdyacenteAlHueco())
            {
                fichaEnMovimiento = gameObject;
                StartCoroutine(MoverFicha(transform.position, hueco));
                Instantiate(audioMov);
                movimientos++;
            }
        }
    }

    private bool EsAdyacenteAlHueco()
    {
        float posicionX = transform.position.x;
        float posicionY = transform.position.y;
        float diffX = Mathf.Abs(transform.position.x - hueco.x);
        float diffY = Mathf.Abs(transform.position.y - hueco.y);
        return ((posicionX == hueco.x && diffY <= 3) || (posicionY == hueco.y && diffX <= 3));
    }

    private System.Collections.IEnumerator MoverFicha(Vector3 start, Vector3 end)
    {
        float duration = 0.5f; // Duración de la animación en segundos.
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Cambiar entre la posición inicial y final.
            transform.position = Vector3.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null; // Esperar al siguiente frame.
        }
        transform.position = end;
        hueco = start;
        fichaEnMovimiento = null;
    }
}
