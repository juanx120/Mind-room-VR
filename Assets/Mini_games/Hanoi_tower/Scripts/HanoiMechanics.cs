using System.Collections.Generic;
using UnityEngine;

public class HanoiMechanics : MonoBehaviour
{
    public List<GameObject> Disk_generates;

    void Start()
    {
        Disk_generates = new List<GameObject>();
        Get_colliders();
    }

    // Obtiene los colliders y asigna lógica a ellos
    public void Get_colliders()
    {
        for (int i = 0; i < Disk_generates.Count; i++)
        {
            BoxCollider[] colliders = Disk_generates[i].GetComponents<BoxCollider>();

            if (colliders.Length >= 6)
            {
                // Accede al quinto y al sexto BoxCollider (índices 4 y 5 respectivamente)
                BoxCollider UpCollider = colliders[4]; // Collider superior
                BoxCollider DownCollider = colliders[5]; // Collider Inferior

                // Asignar el callback para detectar colisiones
                UpCollider.isTrigger = true; // Asegúrate de que el collider sea un trigger
                DownCollider.isTrigger = true;

                // Añadir script de colisión si no existe
                if (Disk_generates[i].GetComponent<DiskCollisionHandler>() == null)
                {
                    DiskCollisionHandler handler = Disk_generates[i].AddComponent<DiskCollisionHandler>();
                    handler.Initialize(this, Disk_generates[i], i, UpCollider, DownCollider);
                }
            }
            else
            {
                Debug.LogError("El prefab no tiene suficientes BoxColliders.");
            }
        }
    }

    // Lógica para manejar las colisiones y verificar la mecánica
    public void HandleCollision(GameObject disk, int index, GameObject otherDisk)
    {
        int otherIndex = Disk_generates.IndexOf(otherDisk);

        if (otherIndex > index) // Verifica si el disco actual está abajo del otro disco en la lista
        {
            Debug.LogError("Error, disco pequeño abajo de disco grande: " + disk.name + " está debajo de " + otherDisk.name);
        }
    }
}

// Script separado para manejar colisiones
public class DiskCollisionHandler : MonoBehaviour
{
    private HanoiMechanics hanoiMechanics;
    private GameObject disk;
    private int index;
    private BoxCollider UpCollider;
    private BoxCollider DownCollider;

    public void Initialize(HanoiMechanics hanoiMechanics, GameObject disk, int index, BoxCollider UpCollider, BoxCollider DownCollider)
    {
        this.hanoiMechanics = hanoiMechanics;
        this.disk = disk;
        this.index = index;
        this.UpCollider = UpCollider;
        this.DownCollider = DownCollider;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Disk")) // Asumiendo que los discos tienen el tag "Disk"
        {
            hanoiMechanics.HandleCollision(disk, index, other.gameObject);
        }
    }
}

