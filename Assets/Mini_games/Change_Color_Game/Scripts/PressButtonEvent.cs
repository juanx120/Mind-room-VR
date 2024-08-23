using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonEvent : XRSimpleInteractable
{
    public bool press;
    public Color colorbut;
    public Renderer Renderer_but;
    public Collision_mechanic instance_collision_Mechanic;

    void Start()
    {
        // Busca una instancia de Collision_mechanic en toda la escena
        instance_collision_Mechanic = FindObjectOfType<Collision_mechanic>(); // Busca un objeto por toda la escena que tenga el Script Collision_mechanic

        if (instance_collision_Mechanic == null)
        {
            Debug.LogError("No se encontró un objeto con el script Collision_mechanic en la escena.");
        }
        else
        {
            Debug.Log("Asignado la instancia con el objeto");
        }

        press = false;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Renderer_but = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>();
        //press = true;
        instance_collision_Mechanic.hasInteracted = true;
        colorbut = Renderer_but.material.color;
        Debug.Log("Botón presionado" + colorbut.ToString());
    }
}