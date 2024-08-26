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

        if (instance_collision_Mechanic == null)
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
        base.OnSelectEntered(args);
        Renderer_but = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>();

        // Obtener el color del bot�n y asignarlo a colorbut
        colorbut = Renderer_but.material.color;
        Debug.Log("Bot�n presionado, color del bot�n: " + colorbut.ToString());
        instance_collision_Mechanic.hasInteracted = true;

        // Comparar el color inmediatamente despu�s de presionar
        if (instance_collision_Mechanic.timeWait >= 1.0f && instance_collision_Mechanic.hasInteracted != false) // Revisa la bandera antes de ejecutar la funci�n
        {
            instance_collision_Mechanic.CompareButtonColor(colorbut);
        }        
    }
}
