using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Victory_games : MonoBehaviour
{
    [HideInInspector]
    public Mathematic_mechanics instantiate_mathematic_Mechanics; // Recoge los valores del juego de las matemáticas
    [HideInInspector]
    public Bottles_mechanics instantiate_bottles_mechanics; // Recoge los valores del juego de las botellas
    [HideInInspector]
    public Collision_mechanic instantiate_collision_mechanics; // Recoge los valores del juego de la pantalla de colores
    public Toggle toggle_bottles;
    public Toggle toggle_Colores;
    public Toggle toggle_Matematics;
    
    private bool lastBottleToggleState;
    private bool lastColorToggleState;
    private bool lastMathToggleState;

    void Start()
    {
        instantiate_mathematic_Mechanics = FindObjectOfType<Mathematic_mechanics>();
        instantiate_bottles_mechanics = FindObjectOfType<Bottles_mechanics>();
        instantiate_collision_mechanics = FindObjectOfType<Collision_mechanic>();
        // Inicializa los estados anteriores de los toggles
        lastBottleToggleState = toggle_bottles.isOn;
        lastColorToggleState = toggle_Colores.isOn;
        lastMathToggleState = toggle_Matematics.isOn;
        //Debug.Log($"Las variables Toggle inicializan con = {lastBottleToggleState}, {lastColorToggleState}, {lastMathToggleState}");
    }

    void Update()
    {
        // Solo actualiza el estado del toggle si hay un cambio en el estado
        bool currentBottleToggleState = (instantiate_bottles_mechanics.suma == instantiate_bottles_mechanics.equal_colors.Count);
        bool currentColorToggleState = (instantiate_collision_mechanics.Success == 10); //30
        bool currentMathToggleState = (instantiate_mathematic_Mechanics.score == 5); //20

        if (currentBottleToggleState != lastBottleToggleState)
        {
            toggle_bottles.isOn = currentBottleToggleState;
            lastBottleToggleState = currentBottleToggleState;
        }

        if (currentColorToggleState != lastColorToggleState)
        {
            toggle_Colores.isOn = currentColorToggleState;
            lastColorToggleState = currentColorToggleState;
        }

        if (currentMathToggleState != lastMathToggleState)
        {
            toggle_Matematics.isOn = currentMathToggleState;
            lastMathToggleState = currentMathToggleState;
        }
    }
}

