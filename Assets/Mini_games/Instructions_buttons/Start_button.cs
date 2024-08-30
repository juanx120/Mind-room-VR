using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Start_button : XRSimpleInteractable
{
    private Generate_bottles instance_generate_bottles;
    private Generate_buttons instance_generate_buttons;

    void Start()
    {
        // Busca una instancia de Generate_bottles y Generate_buttons en toda la escena
        instance_generate_bottles = FindObjectOfType<Generate_bottles>();
        instance_generate_buttons = FindObjectOfType<Generate_buttons>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Verifica que las instancias no sean nulas
        if (instance_generate_bottles == null || instance_generate_buttons == null)
        {
            Debug.LogWarning("No se encontr� una instancia de Generate_bottles o Generate_buttons en la escena.");
            return;
        }

        // Obt�n el GameObject que est� siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obt�n el nombre del bot�n presionado
        string buttonName = pressedButton.name;
        bool activation = true;

        // Verifica si el bot�n pertenece a Generate_bottles
        if (instance_generate_bottles.button_start != null &&
            instance_generate_bottles.button_start.name.ToLower() == buttonName.ToLower())
        {
            instance_generate_bottles.activate_game(buttonName, activation);
        }
        // Verifica si el bot�n pertenece a Generate_buttons
        else if (instance_generate_buttons.button_start != null &&
                 instance_generate_buttons.button_start.name.ToLower() == buttonName.ToLower())
        {
            instance_generate_buttons.activation_gaming(buttonName);
        }
    }
}

