using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntajeParaGanar : MonoBehaviour
{
    // LAs siguientes variables sirven para agregar el puntaje necesario para ganar en cada juego
    [HideInInspector]
    public int Bottles_game;
    public int Color_game;
    public int Matematics_game;
    [HideInInspector]
    public Bottles_mechanics instantiate_bottles_mechanics;

    private void Start()
    {
        instantiate_bottles_mechanics = FindAnyObjectByType<Bottles_mechanics>();
        Bottles_game = instantiate_bottles_mechanics.equal_colors.Count;
    }
}
