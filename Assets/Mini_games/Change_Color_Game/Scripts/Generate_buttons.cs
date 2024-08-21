using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_buttons : MonoBehaviour
{
    public GameObject Buttons_game; // Prefab para generar los objetos botella
    public Vector3 Initial_positions; // Se aginan las posiciones iniciales de los objetos
    public Vector3 direction_generation; //Sirve para generar en una dirección los objetos dependiendo de la desición del usuario
    //[HideInInspector]
    public int Generate_number; // Numero de objetos a generar
    private Vector3[] positions_buttons; // Posiciones de las plataformas
    public Change_Color_mirror instance;
    // Start is called before the first frame update
    void Start()
    {
        Generate_number = 5;
        positions_buttons = new Vector3[Generate_number];
        positions_buttons[0] = new Vector3(Initial_positions.x, Initial_positions.y, Initial_positions.z);
        Generate_Buttons_game();
    }

    public void Generate_Buttons_game()
    {
        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                positions_buttons[i + 1] = new Vector3(positions_buttons[i].x + direction_generation.x, positions_buttons[i].y + direction_generation.y, positions_buttons[i].z + direction_generation.z); // Asigna las posiciones de las plataformas restantes
            }

            GameObject newButton = Instantiate(Buttons_game, positions_buttons[i], Quaternion.identity); // Crea un objeto plataforma
            Renderer buttonRenderer = newButton.GetComponent<Renderer>(); // Toma el renderer del objeto generado

            buttonRenderer.material.color = instance.colours[i];
            newButton.name = "Button_" + (i + 1); // Asigna un nuevo nombre al objeto
        }
    }
}
