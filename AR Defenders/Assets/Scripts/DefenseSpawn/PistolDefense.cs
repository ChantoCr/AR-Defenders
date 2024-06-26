using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolDefense : MonoBehaviour
{
    public GameObject pistolPrefab; // Prefab de la defensa pistola
    public int pistolCost = 20; // Costo de oro para colocar una defensa de pistola
    private GoldManager goldManager;
    public Vector3 spawnScale = new Vector3(0.1f, 0.1f, 0.1f); // Escala de los objetos instanciados

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>(); // Obtener referencia al GoldManager
    }

    public void PlacePistolDefense(Vector3 position)
    {
        if (goldManager.SpendGold(pistolCost))
        {
            GameObject newPistol = Instantiate(pistolPrefab, position, Quaternion.identity);
            newPistol.transform.localScale = spawnScale; // Ajustar la escala del objeto instanciado
        }
        else
        {
            Debug.Log("Not enough gold to place pistol defense!"); // Mensaje de depuración si no hay suficiente oro
        }
    }

    public void PlacePistolDefenseButton()
    {
        Vector3 position = GetPlacementPosition();
        PlacePistolDefense(position);
    }

    private Vector3 GetPlacementPosition()
    {
        // Aquí puedes implementar la lógica para obtener la posición deseada
        return new Vector3(0, 0, 0);
    }
}
