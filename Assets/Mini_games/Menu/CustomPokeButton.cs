using System.Collections;
using TMPro;
using Unity.VisualScripting;
using Unity.XR.CoreUtils.Bindings;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class CustomPokeButton : MonoBehaviour
{
    public GameObject menu_start; // Menú
    public GameObject TV_principal; // Este objeto sirve para mostrar el video en la pantalla grande
    public GameObject Canvas_HUB; // Servirá para acceder a objetos especificos del Hub
    public GameObject Puerta_principal; // La reja que se abrirá al iniciar el juego
    public GameObject tablero; // Para hacer aparecer el tablero de las estadísticas
    public Light[] Lights_games;
    public TextMeshProUGUI[] text_canvas;
    private bool activate_coroutine;

    private Animator anim_Door_left;
    private Animator anim_Door_right;
    [HideInInspector]
    public Sonido instance_sonido;

    void Start()
    {
        instance_sonido = FindObjectOfType<Sonido>();
        activate_coroutine = false;
        anim_Door_left = Puerta_principal.transform.GetChild(0).GetComponent<Animator>();
        anim_Door_right = Puerta_principal.transform.GetChild(1).GetComponent<Animator>();
        text_canvas = new TextMeshProUGUI[3];
        for (int i = 0; i < 3; i++)
        {
            text_canvas[i] = Canvas_HUB.transform.GetChild(i + 5).gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    public void Start_aplication()
    {
        instance_sonido.reproduct_effect(0);
        anim_Door_left.Play("animation_dooor_left");
        anim_Door_right.Play("animation_dooor_Right");
        menu_start.SetActive(false);
        instance_sonido.reproduct_effect(1);
        StartCoroutine(time_wait_TV(6));
    }

    IEnumerator time_wait_TV(int seconds)
    {
        int timeRemaining = seconds;
        while (timeRemaining > 0)
        {
            Debug.LogWarning("Tiempo restante: " + timeRemaining + " seconds");
            yield return new WaitForSeconds(1);
            timeRemaining--;
        }

        Debug.Log("¡Tiempo agotado!");

        RawImage Video_presentation_cientific = Canvas_HUB.transform.GetChild(4).GetComponent<RawImage>();
        //RawImage Video_TV_Cientific = TV_principal.transform.GetChild(1).GetComponent<RawImage>();
        Video_presentation_cientific.gameObject.SetActive(true);
        TV_principal.SetActive(true);
        instance_sonido.reproduct_effect(2);

        for (int i = 0; i < text_canvas.Length; i++)
        {
            if (i == 0)
            {
                text_canvas[i].gameObject.SetActive(true);
            }
            else
            {
                yield return new WaitForSeconds(10);
                text_canvas[i - 1].gameObject.SetActive(false);
                text_canvas[i].gameObject.SetActive(true);
            }
        }

        yield return new WaitForSeconds(10);
        text_canvas[2].gameObject.SetActive(false);
        Video_presentation_cientific.gameObject.SetActive(false);
        TV_principal.SetActive(false);
        tablero.SetActive(true);

        for (int i = 0; i < Lights_games.Length; i++)
        {
            if (i == 0)
            {
                yield return new WaitForSeconds(1);
                Lights_games[i].gameObject.SetActive(true); // Activa la luz inmediatamente
            }
            else
            {
                yield return new WaitForSeconds(1);
                Lights_games[i].gameObject.SetActive(true); // Activa la luz después de 1 segundo
            }
        }

        activate_coroutine = true;

    }

    public void Exit_aplication()
    {
        Application.Quit();
    }

    void Update()
    {
        if (activate_coroutine == true)
        {
            StopAllCoroutines();
        }
    }
}

