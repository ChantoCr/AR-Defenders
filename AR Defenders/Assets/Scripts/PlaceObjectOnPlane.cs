using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject objectToPlace; // Objeto que se colocará en la escena AR

    private ARRaycastManager arRaycastManager; // Gestiona los rayos AR
    private List<ARRaycastHit> hits = new List<ARRaycastHit>(); // Lista de impactos de rayos AR

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>(); // Obtiene el ARRaycastManager del componente actual
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            PlaceObject(); // Llama a la función PlaceObject cuando se detecta un toque en la pantalla
        }
    }

    void PlaceObject()
    {
        // Lanza un rayo desde la posición del toque en la pantalla
        if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
        {
            // Obtiene la posición y rotación donde se colocará el objeto
            Pose hitPose = hits[0].pose;
            // Instancia el objeto en la posición y rotación obtenidas
            Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
        }
    }
}
