using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    private AudioSource AudioSource_effects; // Se recoge el audio source del objeto
    public AudioClip[] Sound_effects; // Se guardan todos los efectos de sonido
    // Start is called before the first frame update
    void Start()
    {
        AudioSource_effects = GetComponent<AudioSource>();
    }

    public void reproduct_effect(int op)
    {
        if (op >= 0 && op < Sound_effects.Length)
        {
            AudioSource_effects.clip = Sound_effects[op];
            AudioSource_effects.Play();
        }
        else
        {
            Debug.LogWarning("Índice fuera de rango");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
