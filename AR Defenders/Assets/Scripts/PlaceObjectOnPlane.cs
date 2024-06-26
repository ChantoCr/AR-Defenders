using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceObjectOnPlane : MonoBehaviour
{
    public GameObject basePrefab; // Prefab de la base
    private ARRaycastManager arRaycastManager;
    private GameObject spawnedBase;
    private bool basePlaced = false;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if (!basePlaced && arRaycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes))
        {
            Pose hitPose = hits[0].pose;
            if (!basePlaced)
            {
                spawnedBase = Instantiate(basePrefab, hitPose.position, hitPose.rotation);
                basePlaced = true;
            }
        }

        if (basePlaced)
        {
            // Aquí puedes manejar la lógica adicional para cuando la base ya esté colocada
        }
    }
}
