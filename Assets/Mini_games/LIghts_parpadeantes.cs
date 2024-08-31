using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIghts_parpadeantes : MonoBehaviour
{
    public GameObject Objeto_lights; // Agarra el objeto con las luces que van a parpadear
    public List<Light> Luces_parpadeantes = new List<Light>(); // Luces que van a parpadear
    private bool Luces = true;

    // Start is called before the first frame update
    void Start()
    {
        // Cambia el bucle para usar Add()
        for (int i = 0; i < Objeto_lights.transform.childCount; i++)
        {
            Light luz = Objeto_lights.transform.GetChild(i).GetComponent<Light>();
            if (luz != null)
            {
                Luces_parpadeantes.Add(luz);
            }
        }
        StartCoroutine(Parpading());
    }

    IEnumerator Parpading()
    {
        bool bandera = false;
        while (!bandera)
        {
            yield return new WaitForSeconds(0.25f);
            for (int i = 0; i < Luces_parpadeantes.Count; i++)
            {
                // Cambia la visibilidad de cada luz en la lista
                if (Luces)
                {
                    Luces_parpadeantes[i].gameObject.SetActive(false);
                }
                else
                {
                    Luces_parpadeantes[i].gameObject.SetActive(true);
                }
            }
            Luces = !Luces; // Alterna el estado de Luces
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Opcional: agregar lógica adicional si es necesario
    }
}

