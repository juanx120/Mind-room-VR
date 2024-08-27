using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonMathematic : XRSimpleInteractable
{
    private Mathematic_mechanics instantiate_mathematic_Mechanics;

    void Start()
    {
        // Busca una instancia de Collision_mechanic en toda la escena
        instantiate_mathematic_Mechanics = FindObjectOfType<Mathematic_mechanics>();

        if (instantiate_mathematic_Mechanics == null)
        {
            Debug.LogError("No se encontr� un objeto con el script Collision_mechanic en la escena.");
        }
        else
        {
            Debug.Log("Asignado la instancia con el objeto");
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obt�n el GameObject que est� siendo interactuado
        GameObject pressedButton = args.interactorObject.transform.gameObject;

        // Obt�n el nombre del bot�n presionado
        string buttonName = pressedButton.name;
        Debug.Log("Bot�n presionado: " + buttonName);

        for (int i = 0; i < instantiate_mathematic_Mechanics.names_buttons.Count - 1; i++)
        {
            if (instantiate_mathematic_Mechanics.names_buttons[i] == buttonName)
            {
                instantiate_mathematic_Mechanics.activate_game(buttonName, i);
            }
        }
    }
}
