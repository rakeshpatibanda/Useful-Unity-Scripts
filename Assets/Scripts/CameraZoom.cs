using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{   
    // VARIABLES FOR MIN AND MAX ZOOM FOR 2D CAMERA
    public float minZoom2D, maxZoom2D;

    // VARIABLES FOR MIN AND MAX ZOOM FOR 3D CAMERA
    public float minZoom3D, maxZoom3D;

    // VARIABLE TO SET ZOOM SPEED FOR 2D CAMERA
    public float zoomSpeed2D;

    // VARIABLE TO SET ZOOM SPEED FOR 3D CAMERA
    public float zoomSpeed3D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // CHECK FOR 2D CAMERA SCROLL MOVEMENT
        if(Camera.main.orthographic)
        {
            CameraZoom2D();
        }else
        {
            CameraZoom3D();
        }
        
    }

    // 2D CAMERA ZOOM FUNCTION
    void CameraZoom2D(){
        // CHECK IF THE SCROLL WHEEL IS MOVING UPWARDS
            if(Input.GetAxis("Mouse ScrollWheel") > 0){
                // ZOOM IN
                Camera.main.orthographicSize -= zoomSpeed2D * Time.deltaTime;
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                // ZOOM OUT
                Camera.main.orthographicSize += zoomSpeed2D * Time.deltaTime;
            } 

            // RESTRICTING THE MIN AND MAX ZOOM VALUE WHEN 2D CAMERA
            Camera.main.orthographicSize =  Mathf.Clamp(Camera.main.orthographicSize, minZoom2D, maxZoom2D);
    }

    // 3D CAMERA ZOOM FUNCTION
    void CameraZoom3D(){
        if(Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            // ZOOM IN
            Camera.main.fieldOfView -= zoomSpeed3D * Time.deltaTime;
        } 
        else if(Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            // ZOOM OUT
            Camera.main.fieldOfView += zoomSpeed3D * Time.deltaTime;
        }

        // RESTRICTING THE MIN AND MAX ZOOM VALUE WHEN 3D CAMERA
        Camera.main.fieldOfView =  Mathf.Clamp(Camera.main.fieldOfView, minZoom3D, maxZoom3D);
    }
}
