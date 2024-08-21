using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate_disks : MonoBehaviour
{
    public GameObject disks_prefab; // Objeto que recoge el prefab para generar los discos
    public GameObject tower_prefab; // Objeto que recoge el prefab para generar las torres
    public int disks_number; // Cantidad de discos generados
    public Vector3 Initial_positions; // Posición inicial para generar los discos y torres
    private Vector3[] positions_disks; // Posiciones para generar los discos
    private Vector3[] positions_towers; // Posiciones para generar las torres
    private Color[] Colors; // Se le asigna un color a los discos generados
    private Vector3[] Scaless; // Se le cambia la escala a los objetos generados

    void Start()
    {
        generate_disks();
        generate_towers();
    }

    // Esta función genera los discos para la torre de Hanoi
    public void generate_disks()
    {
        Colors = new Color[disks_number]; // Esta variable servirá para colocarle un color a cada uno de los discos
        positions_disks = new Vector3[disks_number]; // Esta variable servirá para colocar la cantidad de discos que se van a generar
        Scaless = new Vector3[disks_number];
        Scaless[0] = new Vector3(disks_prefab.transform.localScale.x, disks_prefab.transform.localScale.y, disks_prefab.transform.localScale.z); // Este Vector sirve como configurador de escalas
        positions_disks[0] = new Vector3(Initial_positions.x, Initial_positions.y + 0.2f, Initial_positions.z); // Posición inicial del primer disco

        for (int i = 0; i < positions_disks.Length; i++)
        {
            if (i < positions_disks.Length - 1) // Se guardan las posiciones y escalas faltantes
            {
                positions_disks[i + 1] = new Vector3(positions_disks[i].x, positions_disks[i].y + 0.2f, positions_disks[i].z);
                Scaless[i + 1] = new Vector3(Scaless[i].x - (Scaless[i].x / disks_number), Scaless[i].y, Scaless[i].z - (Scaless[i].z / disks_number));
            }
            Colors[i] = new Color(
                Random.Range(0f, 1f), // R 
                Random.Range(0f, 1f), // G
                Random.Range(0f, 1f)); // B

            GameObject newDisk = Instantiate(disks_prefab, positions_disks[i], Quaternion.identity); // Crea el objeto
            Renderer diskRenderer = newDisk.GetComponent<Renderer>(); // Obtiene el componente Renderer del objeto actual

            if (diskRenderer != null)
            {
                diskRenderer.material.color = Colors[i];
            }
            newDisk.name = "Disk_" + (i + 1); // Cambiar el nombre del objeto instanciado
            newDisk.transform.localScale = new Vector3(Scaless[i].x, Scaless[i].y, Scaless[i].z); // Cambia la escala del objeto generado
        }
    }

    public void generate_towers()
    {
        positions_towers = new Vector3[3]; // Se crearan tres torres en total
        positions_towers[0] = new Vector3(Initial_positions.x, Initial_positions.y + tower_prefab.transform.localScale.y, Initial_positions.z); // Posición inicial de la primera torre

        for (int i = 0; i < positions_towers.Length; i++)
        {
            if (i < positions_towers.Length - 1)
            {
                positions_towers[i + 1] = new Vector3(positions_towers[i].x, positions_towers[i].y, positions_towers[i].z - 3.0f);
            }
            GameObject newTower = Instantiate(tower_prefab, positions_towers[i], Quaternion.identity);
            Renderer towerRenderer = newTower.GetComponent<Renderer>();

            if (towerRenderer != null)
            {
                towerRenderer.material.color = Color.white;
            }
            newTower.name = "Tower" + (i + 1);
        }
    }

    void Update()
    {

    }
}
