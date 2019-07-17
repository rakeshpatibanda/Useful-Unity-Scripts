using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{

    // VARIABLE TO DETERMINE THE SPEED OF THE ROTATION 
    public float rotationSpeed;
    private void OnMouseDrag() 
    {   
       // ASSGINING THE VALUE OF THE ROTATED X AXIS MULTIPLIED  BY THE SET ROTATIONSPEED TO A
       // TEMPORARY FLOAT X 
       float x = Input.GetAxis("Mouse X") * rotationSpeed;
       float y = Input.GetAxis("Mouse Y") * rotationSpeed;

       // ONCE WE GET THE X VALUE WE NEED TO ROTATE THE OBJECT ACCORDINGLY
       transform.Rotate(Vector3.up, -x);

       // ONCE WE GET THE Y VALUE WE NEED TO ROTATE THE OBJECT ACCORDINGLY
       transform.Rotate(Vector3.left, -y);
       

    }
}
