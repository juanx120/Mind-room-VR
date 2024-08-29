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
        // Busca una instancia de Mathematic_mechanics en toda la escena
        instance_generate_bottles = FindObjectOfType<Generate_bottles>();
        instance_generate_buttons = FindObjectOfType<Generate_buttons>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obt�n el GameObject que est� siendo interactuado
        GameObject pressedButton = args.interactableObject.transform.gameObject;

        // Obt�n el nombre del bot�n presionado
        string buttonName = pressedButton.name;
        bool activation = true;
        //Debug.Log("Bot�n presionado: " + buttonName);

        if (instance_generate_bottles.button_start.GetComponent<GameObject>().name.ToLower() == buttonName.ToLower())
        {
            instance_generate_bottles.activate_game(buttonName, activation);
        }

        else if (instance_generate_buttons.button_start.GetComponent<GameObject>().name.ToLower() == buttonName.ToLower())
        {
            instance_generate_buttons.activation_gaming(buttonName);
        }
    }
}
