using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bottles_mechanics : MonoBehaviour
{
    [HideInInspector]
    public Generate_bottles generate_Bottles;
    public List<GameObject> Platforms_mec_stay = new List<GameObject>(); // Variable para guardar las botellas de referencia
    public List<GameObject> Platforms_mec_Game = new List<GameObject>(); // Variable para guardar las botellas con las que el usuario interactuará
    public List<int> equal_colors = new List<int>(); // Variable para comparar los colores si son iguales
    //[HideInInspector]
    public int suma = 0;

    public TextMeshProUGUI Bottles_results;

    [HideInInspector]
    public Victory_games instance_victory_Games;

    [HideInInspector]
    public PuntajeParaGanar instance_PuntajeParaGanar;

    void Start()
    {
        generate_Bottles = FindObjectOfType<Generate_bottles>();
        instance_victory_Games = FindAnyObjectByType<Victory_games>();
        instance_PuntajeParaGanar = FindAnyObjectByType<PuntajeParaGanar>();
        Debug.Log($"Verificación variable botellas = {instance_PuntajeParaGanar.Bottles_game}");
    }
    void Awake()
    {
        SetupEqualColors();
    }

    public void SetupEqualColors()
    {
        if (generate_Bottles != null && generate_Bottles.Generate_number > 0)
        {
            for (int i = 0; i < generate_Bottles.Generate_number; i++)
            {
                equal_colors.Add(0); // Inicializa la lista con ceros
            }
        }
        else
        {
            Debug.LogError("Generate_number no está inicializado o es 0");
        }
    }

    void Update()
    {
        if (equal_colors.Count > 0)
        {
            Compare_colors();
            sumando();

            if (suma == instance_PuntajeParaGanar.Bottles_game) // Suma == 5
            {
                generate_Bottles.activate = false;
                Bottles_results.text = $"Felicidades, has ganado el juego de las botellas";
            }

            else/* if (suma != instance_PuntajeParaGanar.Bottles_game && generate_Bottles.activate == true) */// suma != 5
            {
                Bottles_results.text = $"Obten un total de {instance_PuntajeParaGanar.Bottles_game} aciertos para ganar\nNúmero de Aciertos = {suma}";
            }
        }
    }

    public void Compare_colors()
    {
        suma = 0; // Resetear suma antes de realizar la comparación

        for (int i = 0; i < equal_colors.Count; i++)
        {
            if (i < Platforms_mec_stay.Count && i < Platforms_mec_Game.Count) // Verifica que no te pases del tamaño de la lista
            {
                Renderer renderer_stay = Platforms_mec_stay[i].GetComponent<Renderer>();
                Renderer renderer_Game = Platforms_mec_Game[i].GetComponent<Renderer>();

                // Compara los materiales (colores) de las plataformas
                if (renderer_stay.material.color == renderer_Game.material.color)
                {
                    equal_colors[i] = 1;
                }
                else
                {
                    equal_colors[i] = 0;
                }
            }
        }
    }

    public void sumando()
    {
        suma = 0; // Asegúrate de resetear suma antes de sumar
        for (int i = 0; i < equal_colors.Count; i++)
        {
            suma += equal_colors[i]; // Suma los valores de equal_colors
        }
    }
}
