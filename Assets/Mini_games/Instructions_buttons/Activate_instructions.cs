using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Activate_instructions : MonoBehaviour
{
    public GameObject[] Monitors_Games; // Se agregan a la lista la cantidad de pantallas que tendrán las instrucciones
    [HideInInspector]
    public string[] names_monitors;
    public GameObject[] buttons;
    [HideInInspector]
    public string[] names_buttons;
    public GameObject canvas_HUB; // Hub que se verá cuando el jugador presione alguno de los botones
    public VideoClip video_Mirror_broken; // Toma el video de la pantalla dañada inicial
    public VideoClip video_Doctor; // Toma el video del personaje explicando las mecánicas del juego

    // Start is called before the first frame update
    void Start()
    {
        names_monitors = new string[Monitors_Games.Length];
        names_buttons = new string[buttons.Length];
        for (int i = 0; i < Monitors_Games.Length; i++)
        {
            names_monitors[i] = Monitors_Games[i].name;
            names_buttons[i] = buttons[i].name;
        }
        Debug.Log($"Nombres: {buttons[0]}, {buttons[1]}, {buttons[2]}");
    }

    public void show_instructions(int op)
    {
        Stopped_corroutines();
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

            // Accede al objeto imagen del canvas para activar la imagen del profesor en el HUB
            RawImage image_cientific = canvas_HUB.transform.GetChild(0).GetComponent<RawImage>();
            // Accede al txt dependiendo del botón que se haya oprimido
            TextMeshProUGUI txt_instruction = canvas_HUB.transform.GetChild(op + 1).GetComponent<TextMeshProUGUI>();

            // Activar o desactivar el GameObject que contiene el componente
            image_cientific.gameObject.SetActive(true);
            txt_instruction.gameObject.SetActive(true);

            // Iniciar la corrutina para cambiar el video después de 20 segundos
            StartCoroutine(ChangeVideoAfterDelay(videoPlayer_actual, 10, op + 1));
        }
    }

    private void Stopped_corroutines()
    {
        StopAllCoroutines();
    }

    // Corrutina para cambiar el video después de un retraso
    private IEnumerator ChangeVideoAfterDelay(VideoPlayer videoPlayer, int delaySeconds, int Object_canvas)
    {
        yield return new WaitForSeconds(delaySeconds); // Espera el tiempo determinado antes de cambiar al otro video

        // Cambiar el video al 'video_Mirror_broken'
        videoPlayer.clip = video_Mirror_broken;
        videoPlayer.Play();

        // Desactivar los GameObjects de los componentes
        canvas_HUB.transform.GetChild(0).gameObject.SetActive(false); // Desaparece la imagen del cientifico
        canvas_HUB.transform.GetChild(Object_canvas).gameObject.SetActive(false); // Desaparece el texto de las instrucciones

        Debug.Log("Video cambiado a video_Mirror_broken.");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
