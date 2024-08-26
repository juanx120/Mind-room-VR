using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;


public class Mathematic_mechanics : MonoBehaviour
{
    public List<string> names_buttons = new List<string>();
    private bool activate; // Activa el juego
    public TextMeshProUGUI Questions; // Genera la pregunta en la pantalla
    // Start is called before the first frame update
    void Start()
    {
        activate = false;
    }

    //Activa el juego
    public void activate_game(string button_name)
    {
        if (activate == false)
        {
            if (button_name == names_buttons[5])
            {
                activate = true;
            }
            else
            {
                Debug.Log("El juego aún no se ha activado, aprieta botón start para activar el juego");
            }
        }
        else if (activate == true)
        {
            Asnwers_comparation(button_name);
        }
    }
    //Genera la pregunta que se vera en la pantalla
    /*
    public void Questions_generate()
    {
        int Random_problem = Random.Range(1, 4); // Genera el orden de los problemas 1.Suma, 2.Resta, 3.Multiplicación, 4.División
        if (Random_problem == 1) //Se escoge la suma
        {
            int Number_1 = Random.Range(0, names_buttons.Count);
            int Number_2 = Random.Range(0, names_buttons.Count);
        }



        int Asnwer;


    }*/

    //Compara la respuesta con las generadas en la pantalla
    public void Asnwers_comparation(string button_name)
    {
        for (int i = 0; i < names_buttons.Count; i++)
        {
            if (button_name == "holas")
            {

            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
