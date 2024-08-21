using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Color_mirror : MonoBehaviour
{
    private Renderer mirror_renderer;
    public Color[] colours;
    public Generate_buttons generate_Buttons;
    public float timeToWait = 2.0f; // Tiempo de espera en segundos
    private int RadomColor;
    private int time_mirror; //Esta variable servirá para hacer que la pantalla cambie los colores más rápidos 

    // Start is called before the first frame update
    void Start()
    {
        mirror_renderer = GetComponent<Renderer>();
        colours = new Color[generate_Buttons.Generate_number];
        colours[0] = Color.red;
        colours[1] = Color.blue;
        colours[2] = Color.green;
        colours[3] = Color.yellow;
        colours[4] = Color.black;

        // Inicia la corrutina para cambiar el color cada dos segundos
        Initial_color();
        StartCoroutine(change_color());
        StartCoroutine(incrementTimeMirror());
    }

    // Corrutina para cambiar el color
    IEnumerator change_color()
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

    IEnumerator incrementTimeMirror()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.0f); // Espera 1 segundo
            time_mirror++; // Incrementa el cronómetro
            Debug.LogWarning($"Segundo: {time_mirror}");
        }
    }

    public void Initial_color() //Imprime un color inicial
    {
        RadomColor = Random.Range(0, colours.Length);
        mirror_renderer.material.color = colours[RadomColor];
    }

    void Update()
    {
        if (time_mirror == 20)
        {
            timeToWait = 1.5f;
        }
        if (time_mirror == 40)
        {
            timeToWait = 1.0f;
        }
        if (time_mirror == 60)
        {
            timeToWait = 0.5f;
        }
    }
}
