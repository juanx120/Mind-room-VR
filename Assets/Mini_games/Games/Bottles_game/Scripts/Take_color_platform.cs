using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_color_platform : MonoBehaviour
{
    private Renderer platformRenderer;
    private Color defaultColor = Color.gray; // Color por defecto (gris)

    void Start()
    {
        platformRenderer = GetComponent<Renderer>();
        platformRenderer.material.color = defaultColor; // Inicializa la plataforma con color gris
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottle_color"))
        {
            Renderer bottleRenderer = collision.gameObject.GetComponent<Renderer>();

            if (bottleRenderer != null)
            {
                // Cambia el color de la plataforma al color de la botella con la que colisiona
                platformRenderer.material.color = bottleRenderer.material.color;

            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bottle_color"))
        {
            // Cambia el color de la plataforma a gris cuando la botella deja de colisionar
            platformRenderer.material.color = defaultColor;
        }
    }
}

