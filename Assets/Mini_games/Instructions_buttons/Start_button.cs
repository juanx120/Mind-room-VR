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
            Debug.LogWarning("No se encontró una instancia de Generate_bottles o Generate_buttons en la escena.");
            return;
        }

        // Obtén el GameObject que está siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obtén el nombre del botón presionado
        string buttonName = pressedButton.name;
        bool activation = true;

        // Verifica si el botón pertenece a Generate_bottles
        if (instance_generate_bottles.button_start != null &&
            instance_generate_bottles.button_start.name.ToLower() == buttonName.ToLower())
        {
            instance_generate_bottles.activate_game(buttonName, activation);
        }
        // Verifica si el botón pertenece a Generate_buttons
        else if (instance_generate_buttons.button_start != null &&
                 instance_generate_buttons.button_start.name.ToLower() == buttonName.ToLower())
        {
            instance_generate_buttons.activation_gaming(buttonName);
        }
    }
}

