using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunDefense : MonoBehaviour
{
    public GameObject shotgunPrefab; // Prefab de la defensa escopeta
    public int shotgunCost = 50; // Costo de oro para colocar una defensa de escopeta
    private GoldManager goldManager;

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>(); // Obtener referencia al GoldManager
    }

    public void PlaceShotgunDefense(Vector3 position)
    {
        if (goldManager.SpendGold(shotgunCost))
        {
            Instantiate(shotgunPrefab, position, Quaternion.identity); // Crear la defensa de escopeta en la posición especificada
        }
        else
        {
            Debug.Log("Not enough gold to place shotgun defense!"); // Mensaje de depuración si no hay suficiente oro
        }
    }

    // Método sin parámetros para ser usado en el botón
    public void PlaceShotgunDefenseButton()
    {
        Vector3 position = GetPlacementPosition(); // Obtén la posición deseada para la defensa
        PlaceShotgunDefense(position);
    }

    // Método para obtener la posición de colocación (puedes personalizar esto según tus necesidades)
    private Vector3 GetPlacementPosition()
    {
        // Lógica para determinar la posición de colocación
        // Esto puede ser reemplazado por cualquier método que determine la posición en tu juego
        return new Vector3(0, 0, 0);
    }
}
