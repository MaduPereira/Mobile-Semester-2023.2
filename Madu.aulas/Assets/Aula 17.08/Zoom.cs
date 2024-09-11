using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zoom : MonoBehaviour
{
    Camera mainCamera;
    float touchPrevdiference, touchCursordiference, zoomModifier;
    Vector2 firstPrevdiference, secondPrevdiference;
    public float zoomSpeed = 0.1f;
    public Text texto;
    void Start()
    {
        mainCamera= GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.touchCount == 2)
        {
            Touch first = Input.GetTouch(0);
            Touch second = Input.GetTouch(1);

            firstPrevdiference = first.position - first.deltaPosition;
            secondPrevdiference= second.position - second.deltaPosition;

            touchPrevdiference = (firstPrevdiference - secondPrevdiference).magnitude;
            touchCursordiference = (first.position - second.position).magnitude;

            zoomModifier = (first.deltaPosition - second.deltaPosition).magnitude * zoomModifier;

            if(touchPrevdiference > touchCursordiference)
            {
                mainCamera.orthographicSize += zoomModifier;
            }

            if(touchPrevdiference < touchCursordiference)
            {
                mainCamera.orthographicSize -= zoomModifier;
            }
        }

        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 10f);
        texto.text = "Camera size " + mainCamera.orthographicSize;
    }
}
