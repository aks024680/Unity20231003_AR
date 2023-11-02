using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using System.Collections.Generic;

namespace AR
{
    /// <summary>
    /// 地板雷射互動控制器
    /// </summary>
    [RequireComponent(typeof(ARRaycastManager))]
    public class TapObjectSystem : MonoBehaviour
    {
        [SerializeField, Header("要生成的物件")]
        private GameObject prefabObject;

        private Vector2 pointMouse;
        private List<ARRaycastHit> hits = new List<ARRaycastHit>();
        private ARRaycastManager arRaycastManager;
        private void Awake()
        {
            arRaycastManager = GetComponent<ARRaycastManager>();
        }
        private void Update()
        {
            TapObject();
        }
        private void TapObject()
        {
            if(Input.GetKeyDown(KeyCode.Mouse0)) 
            {
                pointMouse = Input.mousePosition;

                if (arRaycastManager.Raycast(pointMouse, hits, TrackableType.PlaneWithinPolygon))
                {
                    Pose pose = hits[0].pose;
                    Instantiate(prefabObject,pose.position, Quaternion.identity);
                }
            }
        }
    }
}

