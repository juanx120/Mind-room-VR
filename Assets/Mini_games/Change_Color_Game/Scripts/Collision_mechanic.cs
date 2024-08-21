using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_mechanic : MonoBehaviour
{
    public Generate_buttons instance_generate_Buttons; // Referencia al script que genera los botones
    private GameObject mirrorScreen; // Objeto de la pantalla que cambia de color
    private Renderer mirrorScreenRenderer;
    private int Success; // Numero de aciertos
    private int mistakess; // Numero de equivocaciones
    private float timeWait; // Tiempo de espera para poder aprimir los botones

    // Start is called before the first frame update
    void Start()
    {
        mirrorScreen = GameObject.Find("Pantalla");
        mirrorScreenRenderer = mirrorScreen.GetComponent<Renderer>(); // Obtén el Renderer de la pantalla
        Success = 0;
        mistakess = 0;
        timeWait = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWait >= 1.0f)
        {
            StopAllCoroutines();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timeWait >= 1.0f)
        {
            if (collision.gameObject.CompareTag("Hand_VR"))
            {
                timeWait = 0.0f;
                Renderer renderer_button = gameObject.GetComponent<Renderer>(); // Renderer del botón que colisionó

                // Compara el color del botón con el color de la pantalla
                if (renderer_button.material.color == mirrorScreenRenderer.material.color)
                {
                    Success++;
                    mostrarsuma(); // Muestra la suma en la consola
                    StartCoroutine(wait_time());
                }
                else
                {
                    mistakess++;
                    mostrarresta();
                    StartCoroutine(wait_time());
                }
            }
        }
    }

    IEnumerator wait_time()
    {
        yield return new WaitForSeconds(1.0f);
        timeWait = 1.0f;
        Debug.Log("Puedes volver a presionar los botones");
    }

    public void mostrarsuma()
    {
        Debug.Log("El # de Aciertos es: " + Success);
    }
    public void mostrarresta()
    {
        Debug.Log("El # de equivocaiones es: " + mistakess);
    }
}

