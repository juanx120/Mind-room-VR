using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class Mathematic_mechanics : MonoBehaviour
{
    public List<string> names_buttons = new List<string>();
    private List<int> operations_matematics;
    private bool activate; // Activa el juego
    private int correctAnswer; // Almacena la respuesta correcta
    private int score; // Contador de respuestas correctas
    private int mistakes; // Contador de respuestas incorrectas
    public TextMeshProUGUI Questions; // Genera la pregunta en la pantalla
    public TextMeshProUGUI Mirror_results; // Texto que muestra los resultados
    public TextMeshProUGUI TimerText; // Texto del temporizador

    // Start is called before the first frame update
    void Start()
    {
        activate = false;
        score = 0;
        mistakes = 0;
        for (int i = 0; i < names_buttons.Count - 1; i++)
        {
            operations_matematics[i] = i + 1;
        }
    }

    // Activa el juego
    public void activate_game(string button_name, int op)
    {
        if (activate == false)
        {
            if (button_name == names_buttons[4]) // Cambiado a índice 4 para el botón de inicio
            {
                activate = true;
                Change_text();
            }
            else
            {
                Debug.Log("El juego aún no se ha activado, aprieta botón start para activar el juego");
            }
        }
        else
        {
            Asnwers_comparation(op);
        }
    }

    // Genera la pregunta que se verá en la pantalla
    public void Questions_generate()
    {
        int Random_problem = Random.Range(1, 5); // Genera el orden de los problemas (1. Suma, 2. Resta, 3. Multiplicación, 4. División)
        List<int> options = new List<int>(names_buttons.Count - 1); // Genera opciones para ser impresas para los botones

        int Number_1 = 0;
        int Number_2 = 0;

        // Configura los rangos de números aleatorios basados en el tipo de problema matemático
        if (Random_problem == 1) // Suma
        {
            Number_1 = Random.Range(100, 10001); // Genera números entre 100 y 10,000
            Number_2 = Random.Range(100, 10001);
            correctAnswer = Number_1 + Number_2;
        }
        else if (Random_problem == 2) // Resta
        {
            Number_1 = Random.Range(1000, 10001); // Genera números entre 1,000 y 10,000
            Number_2 = Random.Range(100, Number_1); // Asegura que Number_2 sea menor o igual a Number_1 para evitar resultados negativos
            correctAnswer = Number_1 - Number_2;
        }
        else if (Random_problem == 3) // Multiplicación
        {
            Number_1 = Random.Range(10, 101); // Genera números entre 10 y 100
            Number_2 = Random.Range(1, 101); // Genera números entre 1 y 100
            correctAnswer = Number_1 * Number_2;
        }
        else if (Random_problem == 4) // División
        {
            Number_2 = Random.Range(1, 101); // Genera números entre 1 y 100
            correctAnswer = Random.Range(1, 101); // La respuesta correcta también debe estar entre 1 y 100
            Number_1 = correctAnswer * Number_2; // Asegura que la división sea exacta
        }

        // Llena la lista de opciones con números aleatorios
        for (int j = 0; j < options.Count; j++)
        {
            options.Add(correctAnswer); // Inicializa todas las opciones con la respuesta correcta
        }

        // Reemplaza una de las opciones con una respuesta incorrecta cercana
        int correctPosition = Random.Range(0, options.Count); // Escoge una posición aleatoria para la respuesta correcta
        options[correctPosition] = correctAnswer;

        // Llena las demás posiciones con valores cercanos al correctAnswer
        for (int j = 0; j < options.Count; j++)
        {
            if (j != correctPosition)
            {
                int offset = Random.Range(-10, 10); // Número aleatorio entre -10 y 10
                int wrongAnswer = correctAnswer + offset;

                // Asegúrate de que la respuesta incorrecta no sea igual a la correcta
                while (wrongAnswer == correctAnswer)
                {
                    offset = Random.Range(-10, 10);
                    wrongAnswer = correctAnswer + offset;
                }

                options[j] = wrongAnswer;
            }
        }

        // Mezcla las opciones para que la respuesta correcta no siempre esté en la misma posición
        for (int j = 0; j < options.Count; j++)
        {
            int temp = options[j];
            int randomIndex = Random.Range(0, options.Count);
            options[j] = options[randomIndex];
            options[randomIndex] = temp;
        }

        // Configura el texto de la pregunta y opciones
        if (Random_problem == 1)
        {
            Questions.text = $"Realiza la siguiente operación antes de que se acabe el tiempo\n\n{Number_1} + {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(10));
        }
        else if (Random_problem == 2)
        {
            Questions.text = $"Realiza la siguiente operación antes de que se acabe el tiempo\n\n{Number_1} - {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(10));
        }
        else if (Random_problem == 3)
        {
            Questions.text = $"Realiza la siguiente operación antes de que se acabe el tiempo\n\n{Number_1} * {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(30));
        }
        else if (Random_problem == 4)
        {
            Questions.text = $"Realiza la siguiente operación antes de que se acabe el tiempo\n\n{Number_1} / {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(40));
        }
    }

    // Compara la respuesta con las generadas en la pantalla
    public void Asnwers_comparation(int button_option)
    {
        if (button_option == correctAnswer)
        {
            score++;
            Debug.Log("Respuesta correcta!");
        }
        else
        {
            mistakes++;
            Debug.Log("Respuesta incorrecta.");
        }

        Change_text(); // Genera una nueva pregunta
    }

    public void Change_text()
    {
        Questions_generate(); // Genera una nueva pregunta
    }

    // Corrutina para el temporizador de 10 segundos
    IEnumerator StartTimer(int seconds)
    {
        int timeRemaining = seconds;
        while (timeRemaining > 0)
        {
            TimerText.text = "Tiempo restante: " + timeRemaining + "seconds";
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        TimerText.text = "¡Tiempo agotado!";
        mistakes++; // Incrementa los errores si el tiempo se agota
        Change_text(); // Genera una nueva pregunta al agotarse el tiempo
    }

    // Update is called once per frame
    void Update()
    {
        Mirror_results.text = $"Número de aciertos = {score}\nNúmero de fallos = {mistakes}";
    }
}

