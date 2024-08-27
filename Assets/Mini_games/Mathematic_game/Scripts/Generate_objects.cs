using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Generate_objects : MonoBehaviour
{
    public Mathematic_mechanics instantiate_mathematic_Mechanics;
    public GameObject Buttons_generate; // Prefab para generar los objetos botella
    public Vector3 Initial_positions; // Se asignan las posiciones iniciales de los objetos
    public Vector3 direction_generation; // Sirve para generar en una dirección los objetos dependiendo de la decisión del usuario
    [HideInInspector]
    public int Generate_number; // Número de objetos a generar
    private Vector3[] positions_buttons; // Posiciones de las plataformas
    public Vector3 Rotate_buttons; // Rotar los botones
    public Vector3 button_start_position; // Posición del botón start

    // Start is called before the first frame update
    void Start()
    {
        Initiate_variables();
        Generate_Buttons_generate();
        Generate_button_start();
    }

    public void Initiate_variables() // Inicializa todas las variables necesarias para el juego
    {
        // Variables de generación de botones
        Generate_number = 4;
        positions_buttons = new Vector3[Generate_number];
        positions_buttons[0] = new Vector3(Initial_positions.x, Initial_positions.y, Initial_positions.z);
    }

    public void Generate_Buttons_generate() // Genera los botones
    {
        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                positions_buttons[i + 1] = new Vector3(positions_buttons[i].x + direction_generation.x, positions_buttons[i].y + direction_generation.y, positions_buttons[i].z + direction_generation.z); // Asigna las posiciones de las plataformas restantes
            }

            GameObject newButton = Instantiate(Buttons_generate, positions_buttons[i], Quaternion.identity); // Crea un objeto plataforma
            Transform transform_button = newButton.transform;
            Renderer buttonRenderer = transform_button.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>(); // Toma el renderer del objeto generado

            buttonRenderer.material.color = Color.yellow;
            transform_button.rotation = Quaternion.Euler(Rotate_buttons);
            newButton.name = "Button_Option_" + (i + 1); // Asigna un nuevo nombre al objeto

            // Verifica que instantiate_mathematic_Mechanics no sea nulo
            if (instantiate_mathematic_Mechanics != null)
            {
                instantiate_mathematic_Mechanics.names_buttons.Add(newButton.name);
            }
            else
            {
                Debug.LogError("instantiate_mathematic_Mechanics es nulo. Asegúrate de que está asignado en el inspector.");
            }
        }
    }

    public void Generate_button_start()
    {
        GameObject newButton = Instantiate(Buttons_generate, button_start_position, Quaternion.identity); // Crea un objeto plataforma
        Transform transform_button = newButton.transform;
        Renderer buttonRenderer = transform_button.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>(); // Toma el renderer del objeto generado

        buttonRenderer.material.color = Color.green;
        transform_button.rotation = Quaternion.Euler(Rotate_buttons);
        newButton.name = "Button_Start"; // Asigna un nuevo nombre al objeto

        // Verifica que instantiate_mathematic_Mechanics no sea nulo
        if (instantiate_mathematic_Mechanics != null)
        {
            instantiate_mathematic_Mechanics.names_buttons.Add(newButton.name);
        }
        else
        {
            Debug.LogError("instantiate_mathematic_Mechanics es nulo. Asegúrate de que está asignado en el inspector.");
        }
    }

    void Update()
    {

    }
}
