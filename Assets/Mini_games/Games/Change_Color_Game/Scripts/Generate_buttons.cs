using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_buttons : MonoBehaviour
{
    public Collision_mechanic instance_collision_Mechanic; // Referencia al Script
    public GameObject Buttons_game; // Prefab para generar los objetos botella
    public Vector3 Initial_positions; // Se aginan las posiciones iniciales de los objetos
    public Vector3 direction_generation; //Sirve para generar en una dirección los objetos dependiendo de la desición del usuario
    [HideInInspector]
    public int Generate_number; // Numero de objetos a generar
    private Vector3[] positions_buttons; // Posiciones de las plataformas

    public GameObject mirror;
    private Renderer mirror_renderer; // Toma el renderer de la pantalla
    private Color[] colours; // Crea los colores que serán utilizados
    public float timeToWait = 2.0f; // Tiempo de espera inicial del cambio de color en segundos
    private int RadomColor; // Esta variable especifica el color inicial con el que empezará el juego
    private int time_mirror; //Esta variable servirá para hacer que la pantalla cambie los colores más rápidos 

    // Start is called before the first frame update
    void Start()
    {
        Initiate_variables();
        Generate_Buttons_game();
        // Inicia la corrutina para cambiar el color cada dos segundos
        Initial_color();
        StartCoroutine(change_color());
        StartCoroutine(incrementTimeMirror());
    }

    public void Initiate_variables() // Inicializa todas las variables necesarias para el juego
    {
        // Variables de generación de botones
        Generate_number = 5;
        positions_buttons = new Vector3[Generate_number];
        positions_buttons[0] = new Vector3(Initial_positions.x, Initial_positions.y, Initial_positions.z);

        // Variables para la pantalla
        mirror_renderer = mirror.GetComponent<Renderer>();
        colours = new Color[Generate_number];
        colours[0] = Color.red;
        colours[1] = Color.blue;
        colours[2] = Color.green;
        colours[3] = Color.yellow;
        colours[4] = Color.magenta;
    }

    public void Generate_Buttons_game() // Genera los botones
    {
        for (int i = 0; i < Generate_number; i++)
        {
            if (i < Generate_number - 1)
            {
                positions_buttons[i + 1] = new Vector3(positions_buttons[i].x + direction_generation.x, positions_buttons[i].y + direction_generation.y, positions_buttons[i].z + direction_generation.z); // Asigna las posiciones de las plataformas restantes
            }

            GameObject newButton = Instantiate(Buttons_game, positions_buttons[i], Quaternion.identity); // Crea un objeto plataforma
            Transform transform_button = newButton.transform;
            Renderer buttonRenderer = transform_button.GetChild(1).GetChild(1).GetChild(0).GetComponent<Renderer>(); // Toma el renderer del objeto generado

            buttonRenderer.material.color = colours[i];
            newButton.name = "Button_" + (i + 1); // Asigna un nuevo nombre al objeto
        }
    }

    // Corrutina para cambiar el color
    IEnumerator change_color() // Cambia el color de la pantalla
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait); // Espera los segundos especificados

            // Cambia el color del objeto utilizando un color aleatorio del arreglo
            int random_color;
            do
            {
                random_color = Random.Range(0, colours.Length); // Genera un valor aleatorio
            } while (random_color == RadomColor); // Compara si el valor random es igual al color actual
            mirror_renderer.material.color = colours[random_color]; // Cambioa el color del objeto al material actual
            RadomColor = random_color; // Actualizo la variave RadomColor
        }
    }

    IEnumerator incrementTimeMirror() // Incrementa el tiempo en segundos
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // Espera 1 segundo
            time_mirror++; // Incrementa el cronómetro
        }
    }

    public void Initial_color() //Imprime un color inicial
    {
        RadomColor = Random.Range(0, colours.Length);
        mirror_renderer.material.color = colours[RadomColor];
    }

    void Update()
    {
        if (instance_collision_Mechanic.Success == 5)
        {
            timeToWait = 1.5f;
        }
        if (instance_collision_Mechanic.Success == 10)
        {
            timeToWait = 1.0f;
        }
        if (instance_collision_Mechanic.Success == 15)
        {
            timeToWait = 0.5f;
        }
    }
}
