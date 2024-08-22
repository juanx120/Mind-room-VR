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
    private bool hasInteracted; // Bandera para controlar la ejecuci�n de interaction_ButtonTOMirror

    public TextMeshProUGUI Mirror_results; // Tablero con los resultados de la partida (Aseg�rate de que es TextMeshProUGUI para UI)

    // Start is called before the first frame update
    void Start()
    {
        //mirrorScreen = GameObject.Find("Pantalla");
        mirrorScreenRenderer = instance_generate_Buttons.mirror.GetComponent<Renderer>(); // Obt�n el Renderer de la pantalla
        Success = 0;
        mistakess = 0;
        timeWait = 1.0f;
        hasInteracted = false; // Inicializa la bandera en falso
    }

    // Update is called once per frame
    void Update()
    {
        if (timeWait >= 1.0f && !hasInteracted) // Revisa la bandera antes de ejecutar la funci�n
        {
            interaction_ButtonTOMirror();
            StopAllCoroutines(); // Frena todas las corutinas que se est�n ejecutando
            if (instance_PressButtonEvent.press == true)
            {
                hasInteracted = true; // Marca que la interacci�n ya ocurri�
            }
            else
            {
                hasInteracted = false;
            }
        }

        // Actualiza el texto del Mirror_results
        Mirror_results.text = "N�mero de aciertos = " + Success + "\nN�mero de fallos = " + mistakess;
    }

    public void interaction_ButtonTOMirror()
    {
        if (instance_PressButtonEvent.press == true)
        {
            timeWait = 0.0f;
            Renderer renderer_button = instance_PressButtonEvent.Renderer_but; // Renderer del bot�n que fue oprimido

            // Compara el color del bot�n con el color de la pantalla
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

    IEnumerator wait_time()
    {
        yield return new WaitForSeconds(1.0f);
        timeWait = 1.0f;
        hasInteracted = false; // Resetea la bandera despu�s de la espera
        instance_PressButtonEvent.press = false;
        Debug.Log("Puedes volver a presionar los botones");
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
