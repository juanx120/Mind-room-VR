using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_buttons : MonoBehaviour
{
    public GameObject Buttons_game; // Prefab para generar los objetos botella
    public Vector3 Initial_positions; // Se aginan las posiciones iniciales de los objetos
    [HideInInspector]
    public int Generate_number; // Numero de objetos a generar
    private Vector3[] positions_buttons; // Posiciones de las plataformas
    public Change_Color_mirror instance;
    // Start is called before the first frame update
    void Start()
    {
        Generate_number = 5;
        positions_buttons = new Vector3[Generate_number];
        positions_buttons[0] = new Vector3(Initial_positions.x, Initial_positions.y + Buttons_game.transform.localScale.y / 2, Initial_positions.z);
        Generate_Buttons_game();
    }

    public void Generate_Buttons_game()
    {
        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                positions_buttons[i + 1] = new Vector3(positions_buttons[i].x, positions_buttons[i].y, positions_buttons[i].z - 1.2f); // Asigna las posiciones de las plataformas restantes
            }

            GameObject newButton = Instantiate(Buttons_game, positions_buttons[i], Quaternion.identity); // Crea un objeto plataforma
            Renderer bottleRenderer = newButton.GetComponent<Renderer>(); // Toma el renderer del objeto generado

            bottleRenderer.material.color = instance.colours[i];
            newButton.name = "Button_" + (i + 1); // Asigna un nuevo nombre al objeto
        }
    }
}
