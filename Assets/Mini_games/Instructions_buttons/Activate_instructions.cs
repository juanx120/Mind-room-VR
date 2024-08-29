using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Activate_instructions : MonoBehaviour
{
    public List<GameObject> Monitors_Games; // Se agregan a la lista la cantidad de pantallas que tendrán las instrucciones
    [HideInInspector]
    public string[] names_monitors;
    public List<GameObject> buttons;
    [HideInInspector]
    public string[] names_buttons;
    public GameObject canvas_HUB; // Hub que se verá cuando el jugador presione alguno de los botones
    public VideoClip video_Mirror_broken; // Toma el video de la pantalla dañada inicial
    public VideoClip video_Doctor; // Toma el video del personaje explicando las mecánicas del juego

    // Start is called before the first frame update
    void Start()
    {
        names_monitors = new string[Monitors_Games.Count];
        names_buttons = new string[buttons.Count];
        for (int i = 0; i < Monitors_Games.Count; i++)
        {
            names_monitors[i] = Monitors_Games[i].name;
            names_buttons[i] = buttons[i].name;
        }
        Debug.Log($"Nombres: {buttons[0]}, {buttons[1]}, {buttons[2]}");
    }

    public void show_instructions(int op)
    {
        GameObject monitor_actual = Monitors_Games[op];
        VideoPlayer videoPlayer_actual = monitor_actual.transform.GetChild(3).GetComponent<VideoPlayer>();

        if (videoPlayer_actual == null)
        {
            Debug.LogWarning("No se encontró el Video player del monitor.");
        }
        else
        {
            Debug.Log("VideoPlayer Asignado correctamente.");
            videoPlayer_actual.clip = video_Doctor;
            videoPlayer_actual.Play();
            GameObject image_cientific = canvas_HUB.transform.GetChild(0).GetComponent<GameObject>(); // Accede al objeto imagen del canvas para activar la imagen del profesor en el HUB
            GameObject txt_instruction = canvas_HUB.transform.GetChild(op + 1).GetComponent<GameObject>(); // Accede al txt dependiendo del botón que se haya oprimido

            image_cientific.SetActive(true);
            txt_instruction.SetActive(true);

            // Iniciar la corrutina para cambiar el video después de 20 segundos
            StartCoroutine(ChangeVideoAfterDelay(videoPlayer_actual, 20, op + 1));
        }
        /*
        for (int i = 0; i < Monitors_Games.Count; i++)
        {
            if (names_buttons[i].ToLower() == Button_name.ToLower())
            {
                GameObject monitor_actual = Monitors_Games[op];
                VideoPlayer videoPlayer_actual = monitor_actual.transform.GetChild(3).GetComponent<VideoPlayer>();

                if (videoPlayer_actual == null)
                {
                    Debug.LogWarning("No se encontró el Video player del monitor.");
                }
                else
                {
                    Debug.Log("VideoPlayer Asignado correctamente.");
                    videoPlayer_actual.clip = video_Doctor;
                    videoPlayer_actual.Play();

                    // Iniciar la corrutina para cambiar el video después de 20 segundos
                    StartCoroutine(ChangeVideoAfterDelay(videoPlayer_actual, 20));
                }
            }
        }
        */
    }

    private void Stopped_corroutines()
    {
        StopAllCoroutines();
    }

    // Corrutina para cambiar el video después de un retraso
    private IEnumerator ChangeVideoAfterDelay(VideoPlayer videoPlayer, int delaySeconds, int Object_canvas)
    {
        yield return new WaitForSeconds(delaySeconds); // Aquí espera el tiempo determinado antes de cambiar al otro video nuevamente

        // Cambiar el video al 'video_Mirror_broken'
        videoPlayer.clip = video_Mirror_broken;
        videoPlayer.Play();
        canvas_HUB.transform.GetChild(0).GetComponent<GameObject>().SetActive(false); // Desaparece la imagen del cientifico
        canvas_HUB.transform.GetChild(Object_canvas).GetComponent<GameObject>().SetActive(false); // Desaparece el texto de las instrucciones
        Debug.Log("Video cambiado a video_Mirror_broken.");
        Stopped_corroutines();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

