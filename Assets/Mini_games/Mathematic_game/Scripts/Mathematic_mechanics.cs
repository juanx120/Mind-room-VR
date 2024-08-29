using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;
using Unity.VisualScripting;

public class Mathematic_mechanics : MonoBehaviour
{
    public int correctPosition;
    public List<string> names_buttons = new List<string>();
    [SerializeField]
    private bool activate; // Activa el juego
    private int correctAnswer; // Almacena la respuesta correcta
    [HideInInspector]
    public int score; // Contador de respuestas correctas
    [HideInInspector]
    public int mistakes; // Contador de respuestas incorrectas
    public TextMeshProUGUI Questions; // Genera la pregunta en la pantalla
    public TextMeshProUGUI Mirror_results; // Texto que muestra los resultados
    public TextMeshProUGUI TimerText; // Texto del temporizador

    [HideInInspector]
    public Victory_games instance_victory_Games;

    // Start is called before the first frame update
    void Start()
    {
        instance_victory_Games = FindAnyObjectByType<Victory_games>();
        activate = false;
        score = 0;
        mistakes = 0;
    }

    // Activa el juego
    public void activate_game(string button_name, int op)
    {
        if (activate == false)
        {
            if (button_name == names_buttons[4]) // Cambiado a �ndice 4 para el bot�n de inicio
            {
                activate = true;
                Change_text();
            }
            else
            {
                Questions.text = "El juego a�n no se ha activado, aprieta bot�n verde para activar el juego";
            }
        }
        else if (activate == true && score != 5)
        {
            Asnwers_comparation(op);
        }
    }

    // Genera la pregunta que se ver� en la pantalla
    public void Questions_generate()
    {
        int Random_problem = Random.Range(1, 5); // Genera el orden de los problemas (1. Suma, 2. Resta, 3. Multiplicaci�n, 4. Divisi�n)
        List<int> options = new List<int>(); // Inicializamos como una lista vac�a

        int Number_1 = 0;
        int Number_2 = 0;

        // Configura los rangos de n�meros aleatorios basados en el tipo de problema matem�tico
        if (Random_problem == 1) // Suma
        {
            Number_1 = Random.Range(100, 1001); // Genera n�meros entre 100 y 1,000
            Number_2 = Random.Range(100, 1001);
            correctAnswer = Number_1 + Number_2;
        }
        else if (Random_problem == 2) // Resta
        {
            Number_1 = Random.Range(1000, 1001); // Genera n�meros entre 1,000 y 1,000
            Number_2 = Random.Range(100, Number_1); // Asegura que Number_2 sea menor o igual a Number_1 para evitar resultados negativos
            correctAnswer = Number_1 - Number_2;
        }
        else if (Random_problem == 3) // Multiplicaci�n
        {
            Number_1 = Random.Range(10, 101); // Genera n�meros entre 10 y 100
            Number_2 = Random.Range(1, 101); // Genera n�meros entre 1 y 100
            correctAnswer = Number_1 * Number_2;
        }
        else if (Random_problem == 4) // Divisi�n
        {
            Number_2 = Random.Range(1, 101); // Genera n�meros entre 1 y 100
            correctAnswer = Random.Range(1, 101); // La respuesta correcta tambi�n debe estar entre 1 y 100
            Number_1 = correctAnswer * Number_2; // Asegura que la divisi�n sea exacta
        }

        // Llena la lista de opciones con n�meros aleatorios
        for (int j = 0; j < names_buttons.Count - 1; j++)
        {
            options.Add(correctAnswer); // Inicializa todas las opciones con la respuesta correcta
        }

        // Reemplaza una de las opciones con una respuesta incorrecta cercana
        correctPosition = Random.Range(0, options.Count); // Escoge una posici�n aleatoria para la respuesta correcta
        options[correctPosition] = correctAnswer;

        // Llena las dem�s posiciones con valores cercanos al correctAnswer
        for (int j = 0; j < options.Count; j++)
        {
            if (j != correctPosition)
            {
                int offset = Random.Range(-10, 10); // N�mero aleatorio entre -10 y 10
                int wrongAnswer = correctAnswer + offset;

                // Aseg�rate de que la respuesta incorrecta no sea igual a la correcta
                while (wrongAnswer == correctAnswer)
                {
                    offset = Random.Range(-10, 10);
                    wrongAnswer = correctAnswer + offset;
                }

                options[j] = wrongAnswer;
            }
        }

        // Mezcla las opciones para que la respuesta correcta no siempre est� en la misma posici�n
        /*for (int j = 0; j < options.Count; j++)
        {
            int temp = options[j];
            int randomIndex = Random.Range(0, options.Count);
            options[j] = options[randomIndex];
            options[randomIndex] = temp;
        }*/

        // Configura el texto de la pregunta y opciones
        if (Random_problem == 1)
        {
            Questions.text = $"Realiza la siguiente operaci�n antes de que se acabe el tiempo\n\n{Number_1} + {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(15));
        }
        else if (Random_problem == 2)
        {
            Questions.text = $"Realiza la siguiente operaci�n antes de que se acabe el tiempo\n\n{Number_1} - {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(15));
        }
        else if (Random_problem == 3)
        {
            Questions.text = $"Realiza la siguiente operaci�n antes de que se acabe el tiempo\n\n{Number_1} * {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(40));
        }
        else if (Random_problem == 4)
        {
            Questions.text = $"Realiza la siguiente operaci�n antes de que se acabe el tiempo\n\n{Number_1} / {Number_2} = ???\n\nA. {options[0]}\nB. {options[1]}\nC. {options[2]}\nD. {options[3]}";
            StartCoroutine(StartTimer(60));
        }
    }

    // Compara la respuesta con las generadas en la pantalla
    public void Asnwers_comparation(int button_option)
    {
        Debug.Log("Respuesta:  " + correctPosition);
        Debug.Log("Boton R:  " + button_option);
        if (button_option == correctPosition)
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
        StopAllCoroutines();
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

        TimerText.text = "�Tiempo agotado!";
        mistakes++; // Incrementa los errores si el tiempo se agota
        Change_text(); // Genera una nueva pregunta al agotarse el tiempo
    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            Mirror_results.text = $"Obten un total de 5 aciertos para ganar\nN�mero de aciertos = {score}\nN�mero de fallos = {mistakes}";
        }
        if (score == 5)
        {
            activate = false;
            Questions.text = $"Has ganado, felicitaciones";
        }
    }
}
