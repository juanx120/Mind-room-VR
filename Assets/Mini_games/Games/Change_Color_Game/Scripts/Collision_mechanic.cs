using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collision_mechanic : MonoBehaviour
{
    [HideInInspector]
    public Generate_buttons instance_generate_Buttons;
    private Renderer mirrorScreenRenderer;
    [HideInInspector]
    public int Success; // Numero de aciertos
    private int mistakess; // Numero de equivocaciones
    [HideInInspector]
    public float timeWait; // Tiempo de espera para poder aprimir los botones
    [HideInInspector]
    public bool hasInteracted; // Bandera para controlar la ejecución de interaction_ButtonTOMirror

    public TextMeshProUGUI Mirror_results; // Tablero con los resultados de la partida

    [HideInInspector]
    public Victory_games instance_victory_Games;
    [HideInInspector]
    public PuntajeParaGanar instance_PuntajeParaGanar;

    // Start is called before the first frame update
    void Start()
    {
        instance_generate_Buttons = FindAnyObjectByType<Generate_buttons>();
        instance_victory_Games = FindAnyObjectByType<Victory_games>();
        instance_PuntajeParaGanar = FindAnyObjectByType<PuntajeParaGanar>();
        mirrorScreenRenderer = instance_generate_Buttons.mirror.GetComponent<Renderer>(); // Obtén el Renderer de la pantalla
        Success = 0;
        mistakess = 0;
        timeWait = 1.0f;
        hasInteracted = false; // Inicializa la bandera en falso
    }
    void Update()
    {
        if (Success != instance_PuntajeParaGanar.Color_game && instance_generate_Buttons.activate == true)
        {
            Mirror_results.text = $"Obten un total de {instance_PuntajeParaGanar.Color_game} aciertos para ganar\nNúmero de aciertos = {Success}\nNúmero de fallos = {mistakess}";
        }
        else if (Success == instance_PuntajeParaGanar.Color_game)
        {
            instance_generate_Buttons.activate = false;
            Mirror_results.text = $"Felicidades, has ganado el juego de las botellas";
        }
    }

    // Método para comparar el color del botón con el de la pantalla
    public void CompareButtonColor(Color colorbtn)
    {
        StopAllCoroutines();
        Color colorscreen = mirrorScreenRenderer.material.color;

        if (colorbtn == colorscreen)
        {
            Success++;
            hasInteracted = false; // Resetea la bandera después de la espera
            StartCoroutine(wait_time());
        }
        else
        {
            mistakess++;
            hasInteracted = false; // Resetea la bandera después de la espera
            StartCoroutine(wait_time());
        }
    }

    IEnumerator wait_time()
    {
        yield return new WaitForSeconds(1.0f);
        timeWait = 1.0f;
    }
}
