using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunDefense : MonoBehaviour
{
    public GameObject machineGunPrefab; // Prefab de la defensa ametralladora
    public int machineGunCost = 70; // Costo de oro para colocar una defensa de ametralladora
    private GoldManager goldManager;

    void Start()
    {
        goldManager = FindObjectOfType<GoldManager>(); // Obtener referencia al GoldManager
    }

    public void PlaceMachineGunDefense(Vector3 position)
    {
        if (goldManager.SpendGold(machineGunCost))
        {
            Instantiate(machineGunPrefab, position, Quaternion.identity); // Crear la defensa de ametralladora en la posición especificada
        }
        else
        {
            Debug.Log("Not enough gold to place machine gun defense!"); // Mensaje de depuración si no hay suficiente oro
        }
    }

    // Método sin parámetros para ser usado en el botón
    public void PlaceMachineGunDefenseButton()
    {
        Vector3 position = GetPlacementPosition(); // Obtén la posición deseada para la defensa
        PlaceMachineGunDefense(position);
    }

    // Método para obtener la posición de colocación (puedes personalizar esto según tus necesidades)
    private Vector3 GetPlacementPosition()
    {
        // Lógica para determinar la posición de colocación
        // Esto puede ser reemplazado por cualquier método que determine la posición en tu juego
        return new Vector3(0, 0, 0); // Ejemplo: posición (0, 0, 0)
    }
}
