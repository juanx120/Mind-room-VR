using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class PressButtonEvent : XRSimpleInteractable
{
    public bool press;
    public Renderer Renderer_but;

    void Start()
    {
        press = false;
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        Renderer_but = transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>();
        press = true;
        Debug.Log("Botón presionado");
    }
}
