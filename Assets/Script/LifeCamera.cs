using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCamera : MonoBehaviour
{
    public Transform target;
    private RectTransform rectTransform;
    private Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(target.position);
        rectTransform.position = screenPos;
    }
}

