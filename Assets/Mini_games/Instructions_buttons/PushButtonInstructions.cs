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
        // Obt�n el GameObject que est� siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obt�n el nombre del bot�n presionado
        string buttonName = pressedButton.name;
        //Debug.Log("Bot�n presionado: " + buttonName);

        for (int i = 0; i < instance_activate_instructions.buttons.Count; i++)
        {
            // Convertimos ambos nombres a min�sculas para evitar errores de comparaci�n
            if (instance_activate_instructions.names_buttons[i].ToLower() == buttonName.ToLower())
            {
                instance_activate_instructions.show_instructions(i);
                break; // Salimos del bucle una vez que se encuentra el bot�n
            }
        }
    }
}
