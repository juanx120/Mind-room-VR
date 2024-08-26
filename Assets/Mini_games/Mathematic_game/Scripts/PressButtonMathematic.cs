using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonMathematic : XRSimpleInteractable
{
    private Mathematic_mechanics instantiate_mathematic_Mechanics;
    public string name_object; // Nombre del objeto

    void Start()
    {
        // Busca una instancia de Collision_mechanic en toda la escena
        instantiate_mathematic_Mechanics = FindObjectOfType<Mathematic_mechanics>();

        if (instantiate_mathematic_Mechanics == null)
        {
            Debug.LogError("No se encontró un objeto con el script Collision_mechanic en la escena.");
        }
        else
        {
            Debug.Log("Asignado la instancia con el objeto");
        }
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        // Obtén el GameObject que está siendo interactuado
        GameObject pressedButton = args.interactorObject.transform.gameObject;

        // Obtén el nombre del botón presionado
        string buttonName = pressedButton.name;
        Debug.Log("Botón presionado: " + buttonName);

        // Si necesitas asignar el nombre a `name_object`
        name_object = buttonName;

        instantiate_mathematic_Mechanics.activate_game(name_object);






        /*
        base.OnSelectEntered(args);
        Renderer_but = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>();

        // Obtener el color del botón y asignarlo a colorbut
        colorbut = Renderer_but.material.color;
        Debug.Log("Botón presionado, color del botón: " + colorbut.ToString());
        instance_collision_Mechanic.hasInteracted = true;

        // Comparar el color inmediatamente después de presionar
        if (instance_collision_Mechanic.timeWait >= 1.0f && instance_collision_Mechanic.hasInteracted != false) // Revisa la bandera antes de ejecutar la función
        {
            instance_collision_Mechanic.CompareButtonColor(colorbut);
        }*/
    }
}
