using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottles_mechanics : MonoBehaviour
{
    public Generate_bottles generate_Bottles;
    public List<GameObject> Platforms_mec_stay = new List<GameObject>();
    public List<GameObject> Platforms_mec_Game = new List<GameObject>();
    public List<int> equal_colors = new List<int>();
    [HideInInspector]
    public int suma = 0;

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
