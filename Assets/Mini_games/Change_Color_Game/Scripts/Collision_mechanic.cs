using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collision_mechanic : MonoBehaviour
{
    public Generate_buttons instance_generate_Buttons;
    private Renderer mirrorScreenRenderer;
    [HideInInspector]
    public int Success; // Numero de aciertos
    private int mistakess; // Numero de equivocaciones
    [HideInInspector]
    public float timeWait; // Tiempo de espera para poder aprimir los botones
    [HideInInspector]
    public bool hasInteracted; // Bandera para controlar la ejecuci�n de interaction_ButtonTOMirror

    public TextMeshProUGUI Mirror_results; // Tablero con los resultados de la partida

    // Start is called before the first frame update
    void Start()
    {
        mirrorScreenRenderer = instance_generate_Buttons.mirror.GetComponent<Renderer>(); // Obt�n el Renderer de la pantalla
        Success = 0;
        mistakess = 0;
        timeWait = 1.0f;
        hasInteracted = false; // Inicializa la bandera en falso
    }
    void Update()
    {
        // Actualiza el texto del Mirror_results
        Mirror_results.text = $"N�mero de aciertos = {Success}\nN�mero de fallos = {mistakess}";
    }

    // M�todo para comparar el color del bot�n con el de la pantalla
    public void CompareButtonColor(Color colorbtn)
    {
        Color colorscreen = mirrorScreenRenderer.material.color;
        Debug.Log("Color del bot�n: " + colorbtn.ToString() + " | Color de la pantalla: " + colorscreen.ToString());

        if (colorbtn == colorscreen)
        {
            Success++;
            mostrarsuma(); // Muestra la suma en la consola}
            hasInteracted = false; // Resetea la bandera despu�s de la espera
            StartCoroutine(wait_time());
        }
        else
        {
            mistakess++;
            mostrarresta();
            hasInteracted = false; // Resetea la bandera despu�s de la espera
            StartCoroutine(wait_time());
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
        Debug.Log("El # de equivocaciones es: " + mistakess);
    }
}
