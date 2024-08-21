using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HanoiMechanics : MonoBehaviour
{
    public Generate_disks generateDisks; // Referencia al script Generate_disks
    public Button[] towerButtons; // Referencia a los botones
    private int selectedTower = -1;

    void Start()
    {
        if (generateDisks == null)
        {
            Debug.LogError("GenerateDisks no está asignado en el Inspector");
            return;
        }

        foreach (Button button in towerButtons)
        {
            button.onClick.AddListener(() => SelectTower(button));
        }
    }

    void SelectTower(Button button)
    {
        int towerIndex = System.Array.IndexOf(towerButtons, button);

        if (selectedTower == -1)
        {
            selectedTower = towerIndex;
        }
        else
        {
            MoveDisk(selectedTower, towerIndex);
            selectedTower = -1;
        }
    }

    void MoveDisk(int fromTower, int toTower)
    {
        Transform fromTowerTransform = generateDisks.tower_prefab.transform.GetChild(fromTower);
        Transform toTowerTransform = generateDisks.tower_prefab.transform.GetChild(toTower);

        if (fromTowerTransform.childCount > 0)
        {
            Transform disk = fromTowerTransform.GetChild(fromTowerTransform.childCount - 1);

            if (toTowerTransform.childCount == 0 ||
                toTowerTransform.GetChild(toTowerTransform.childCount - 1).localScale.x > disk.localScale.x)
            {
                disk.SetParent(toTowerTransform);
                disk.localPosition = new Vector3(0, 0.2f * toTowerTransform.childCount, 0);
            }
            else
            {
                disk.localPosition = new Vector3(0, 0.2f * fromTowerTransform.childCount, 0); // Volver a la posición original
            }
        }
    }
}
