using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonMathematic : XRSimpleInteractable
{
    private Mathematic_mechanics instantiate_mathematic_Mechanics;
    private Sonido instance_sonido;

    void Start()
    {
        // Busca una instancia de Mathematic_mechanics en toda la escena
        instantiate_mathematic_Mechanics = FindObjectOfType<Mathematic_mechanics>();
        instance_sonido = FindObjectOfType<Sonido>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obtén el GameObject que está siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obtén el nombre del botón presionado
        string buttonName = pressedButton.name;
        instance_sonido.reproduct_effect(0);

        for (int i = 0; i < instantiate_mathematic_Mechanics.names_buttons.Count; i++)
        {
            // Convertimos ambos nombres a minúsculas para evitar errores de comparación
            if (instantiate_mathematic_Mechanics.names_buttons[i].ToLower() == buttonName.ToLower())
            {
                instantiate_mathematic_Mechanics.activate_game(buttonName, i);
                break; // Salimos del bucle una vez que se encuentra el botón
            }
        }
    }
}
