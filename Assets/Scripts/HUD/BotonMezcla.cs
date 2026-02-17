using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BotonMezcla : MonoBehaviour
{
    public GameObject tapa, contfichas,caja,reloj,marco,botonpause,fondo,fondo1,chispas,audiovictoria, audiotapa;
    public GameObject[] fichas;
    public static Vector3[] posiciones, victoria;
    private Animator animator;
    public float delayInicio, delayFinal;
    private bool mezclado = false;
    public static bool ganar = false;
    Collider2D theCollider;
    public static int[] numeroFichas = new int[15];
    void Start()
    {
        animator = tapa.GetComponent<Animator>();
        posiciones = new Vector3[fichas.Length];
        victoria = new Vector3[fichas.Length];
        ganar = false;
        for (int i = 0; i < fichas.Length; i++)
        {
            victoria[i] = fichas[i].transform.position;
            print(fichas[i].transform.position);
        };
        for (int i = 0; i < numeroFichas.Length; i++)
        {
            numeroFichas[i] = i + 1;
        };
        Time.timeScale = 0;

    }
    private void Update()
    {
        if (mezclado && Victoria() && !ganar)
        {
            print("ganador");
            Instantiate(audiovictoria);
            ganar = true;
            chispas.SetActive(true);
            Invoke("CargarFinal", 2f);
        }
    }

    public void Click()
    {
        Time.timeScale = 1;
        for (int i = 0;i < numeroFichas.Length;i++)
        {
            Collider2D collider = fichas[i].GetComponent<Collider2D>();
            collider.enabled = true;
        }
        GetComponent<Image>().enabled = false;
        GetComponent<Button>().interactable = false;
        marco.SetActive(false);
        fondo.SetActive(false);
        fondo1.SetActive(true);
        Instantiate(audiotapa);
        theCollider = GetComponent<Collider2D>();
        theCollider.enabled = false;
        animator.SetBool("mezclar", true);
        Juego.animMezclado = true;
        StartCoroutine(tiempoDeEsperaInicio(delayInicio));
        StartCoroutine(tiempoDeEsperaFinal(delayFinal));
    }
    IEnumerator tiempoDeEsperaInicio(float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.SetBool("mezclar", false);
        contfichas.SetActive(false);
        caja.SetActive(false);
        mezclarFichas();
    }
    IEnumerator tiempoDeEsperaFinal(float delay)
    {
        yield return new WaitForSeconds(delay);
        contfichas.SetActive(true);
        caja.SetActive(true);
        Reloj.tiempoActual = 0;
        Juego.movimientos = 0;
        Juego.animMezclado = false;
        fondo.SetActive(true);
        fondo1.SetActive(false);
        botonpause.GetComponent<Button>().interactable = true;
        botonpause.GetComponent<EventTrigger>().enabled = true;
    }
    public void mezclarFichas()
    {
        int[] arr = new int[15];
        bool esta, esSoluble = false;
        

        for (int i = 0; i < fichas.Length; i++)
        {
            posiciones[i] = fichas[i].transform.position;
        }

        while (!esSoluble)
        {
            for (int i = 0; i < 15; i++)
            {
                esta = true;
                while (esta)
                {
                    int random = Random.Range(0, 15);

                    // Verificar si el número ya ha sido utilizado
                    bool numeroRepetido = false;
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] == random)
                        {
                            numeroRepetido = true;
                            break;
                        }
                    }

                    if (!numeroRepetido)
                    {
                        arr[i] = random;
                        esta = false;
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                fichas[i].transform.position = posiciones[arr[i]];
            }
            mezclado = true;
            esSoluble = EsSoluble(arr);
        }
    }

    public bool Victoria()
    {
        bool soniguales = true;
        for (int i = 0; i < 15; i++)
        {
            if (BotonMezcla.victoria[i] != fichas[i].transform.position)
            {
                soniguales = false;
            }
        }
        return soniguales;
    }

    private bool EsSoluble(int[] arr)
    {

        int inversiones = 0;

        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (numeroFichas[arr[i]] > numeroFichas[arr[j]])
                {
                    inversiones++;
                }
            }
        }
        return inversiones % 2 == 0;
    }

    private void CargarFinal()
    {
        SceneManager.LoadScene("Final");
        Time.timeScale = 0;
    }
}
