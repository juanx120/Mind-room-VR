using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonEvent : XRSimpleInteractable
{
    public Color colorbut;
    public Renderer Renderer_but;
    public Collision_mechanic instance_collision_Mechanic;

    void Start()
    {
        // Busca una instancia de Collision_mechanic en toda la escena
        instance_collision_Mechanic = FindObjectOfType<Collision_mechanic>();
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Renderer_but = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>();

        // Obtener el color del botón y asignarlo a colorbut
        colorbut = Renderer_but.material.color;
        instance_collision_Mechanic.hasInteracted = true;

        // Comparar el color inmediatamente después de presionar
        if (instance_collision_Mechanic.timeWait >= 1.0f && instance_collision_Mechanic.hasInteracted != false) // Revisa la bandera antes de ejecutar la función
        {
            instance_collision_Mechanic.CompareButtonColor(colorbut);
        }        
    }
}
