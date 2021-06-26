using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TapToPlace : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject joystickCanvas;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private ARRaycastManager raycastManager;

    private GameObject spawnedPrefab;

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        if(spawnedPrefab == null)
        {
            if(Input.touchCount > 0)
            {
                Vector2 touchPos = Input.GetTouch(0).position;
                
                if(raycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose hitPose = hits[0].pose;
                    spawnedPrefab = Instantiate(prefab, hitPose.position, Quaternion.identity);
                    joystickCanvas.SetActive(true);
                }
            }
        }
    }
}
