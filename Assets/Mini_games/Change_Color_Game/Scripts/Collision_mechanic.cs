using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Collision_mechanic : MonoBehaviour
{
    public Generate_buttons instance_generate_Buttons;
    public PressButtonEvent instance_PressButtonEvent; // Referencia al script hace interactuable los botones
    //private GameObject mirrorScreen; // Objeto de la pantalla que cambia de color
    private Renderer mirrorScreenRenderer;
    [HideInInspector]
    public int Success; // Numero de aciertos
    private int mistakess; // Numero de equivocaciones
    private float timeWait; // Tiempo de espera para poder aprimir los botones
    [HideInInspector]
    public bool hasInteracted; // Bandera para controlar la ejecución de interaction_ButtonTOMirror

    public TextMeshProUGUI Mirror_results; // Tablero con los resultados de la partida (Asegúrate de que es TextMeshProUGUI para UI)

    // Start is called before the first frame update
    void Start()
    {
        mirrorScreenRenderer = instance_generate_Buttons.mirror.GetComponent<Renderer>(); // Obtén el Renderer de la pantalla
        Success = 0;
        mistakess = 0;
        timeWait = 1.0f;
        hasInteracted = false; // Inicializa la bandera en falso
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWait >= 1.0f && hasInteracted != false) // Revisa la bandera antes de ejecutar la función
        {
            interaction_ButtonTOMirror();
            //StopAllCoroutines(); // Frena todas las corutinas que se estén ejecutando
            /*
            if (instance_PressButtonEvent.press == true)
            {
                hasInteracted = false; // Marca que la interacción ya ocurrió
            }
            else if(instance_PressButtonEvent.press == false)
            {
                hasInteracted = true;
            }*/
        }

        // Actualiza el texto del Mirror_results
        Mirror_results.text = "Número de aciertos = " + Success + "\nNúmero de fallos = " + mistakess;
    }

    public void interaction_ButtonTOMirror()
    {
        instance_PressButtonEvent.press = true;
        if (instance_PressButtonEvent.press == true)
        {
            timeWait = 0.0f;
            Renderer renderer_button = instance_PressButtonEvent.Renderer_but; // Renderer del botón que fue oprimido
            Color colorbtn = instance_PressButtonEvent.colorbut;
            Color colorscreen = mirrorScreenRenderer.material.color;
            Debug.Log("Color boton " + colorbtn.ToString() + "color pantalla " + colorscreen.ToString());

            // Compara el color del botón con el color de la pantalla
            if (colorbtn == colorscreen)
            {
                Success++;
                mostrarsuma(); // Muestra la suma en la consola
                hasInteracted = false; // Resetea la bandera después de la espera
                instance_PressButtonEvent.press = false;
                StartCoroutine(wait_time());
            }
            else
            {
                mistakess++;
                mostrarresta();
                hasInteracted = false; // Resetea la bandera después de la espera
                instance_PressButtonEvent.press = false;
                StartCoroutine(wait_time());
            }
        }
    }

    IEnumerator wait_time()
    {
        yield return new WaitForSeconds(1.0f);
        timeWait = 1.0f;
        Debug.Log("Puedes volver a presionar los botones");
        StopAllCoroutines(); // Frena todas las corutinas que se estén ejecutando
    }

    public void mostrarsuma()
    {
        Debug.Log("El # de Aciertos es: " + Success);
    }
    public void mostrarresta()
    {
        Debug.Log("El # de equivocaciones es: " + mistakess);
    }
}