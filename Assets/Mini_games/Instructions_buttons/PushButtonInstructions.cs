using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PushButtonInstructions : XRSimpleInteractable
{
    private Activate_instructions instance_activate_instructions;

    void Start()
    {
        // Busca una instancia de Mathematic_mechanics en toda la escena
        instance_activate_instructions = FindObjectOfType<Activate_instructions>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obtén el GameObject que está siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obtén el nombre del botón presionado
        string buttonName = pressedButton.name;
        //Debug.Log("Botón presionado: " + buttonName);

        for (int i = 0; i < instance_activate_instructions.buttons.Count; i++)
        {
            // Convertimos ambos nombres a minúsculas para evitar errores de comparación
            if (instance_activate_instructions.names_buttons[i].ToLower() == buttonName.ToLower())
            {
                instance_activate_instructions.show_instructions(i);
                break; // Salimos del bucle una vez que se encuentra el botón
            }
        }
    }
}
