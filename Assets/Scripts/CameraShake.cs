using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // VARIABLE TO ACCESS THE TRANSFORM OF THE CAMERA
    Transform camTrans;

    // VARIABLE TO DECIDE HOW MUCH TIME THE CAMERA SHAKE SHOULD HAPPEN
    public float shakeTime;

    // VARIABLE TO DECIDE UPTO HOW MUCH RANGE WE WANT TO MOVE THE CAMERA I.E., IF THE RANGE IS SET TO 5
    // THE CAMERA CAN MOVE IN THE X, Y AND Z AXIS FOR 5 TIMES
    public float shakeRange;

    // ORIGINAL POSITION OF THE CAMERA
    Vector3 originalPositionOfCamera;

    // Start is called before the first frame update
    void Start()
    {
        // GETTING THE TRANSFORM ACCESS OF THE CAMERA AND ASSIGNING IT TO @camTrans
        camTrans = Camera.main.transform; 

        // GETTING THE POSITION VALUE OF THE CAMERA  
        originalPositionOfCamera = camTrans.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){

            // STARTING THE COROUTINE
            StartCoroutine(ShakeCamera());
        }
    }

    IEnumerator ShakeCamera(){

        float timeElapsed = 0;

        while(timeElapsed < shakeTime)
        {
            // CHANGING THE ORIGINAL POSITION OF THE CAMERA BY ADDING IT TO THE RANDOM SHAKE VECTOR3 VARIABLE
            // CREATED BY INSIDEUNITSPHERE MUTIPLIED BY SHAKERANGE
            Vector3 tempCamPos =  originalPositionOfCamera + Random.insideUnitSphere * shakeRange;

            // ASSIGNING TEMPCAMPPOS Z AXIS VALUE TO THE Z VALUE OF THE ORIGINAL CAM POSITION TO AVOID
            // SHAKING IT IN THE Z AXIS AND AVOID THE WEIRD ZOOM IN AND ZOOM OUT EFFECT
            tempCamPos.z = originalPositionOfCamera.z;

            // WE WILL THEN REASSIGN THE NEW VALUE OF TEMPCAMPPOS TO THE CAMTRANS POSITION
            camTrans.position = Vector3.Lerp(originalPositionOfCamera, tempCamPos, shakeTime);
            
            // INCREMENT THE TIME (ELSE IT WILL CONTINUOUSLY LOOP AND THE LOOP WILL NEVER END)
            timeElapsed += Time.deltaTime;

            // MOST IMPORTANT STATEMENT IN A COROUTINE FUNCTION - IT WILL HALT THE EXECUTION OF THE 
            // WHILE LOOP UNTIL THE END OF THE CURRENT FRAME
            yield return null;
        }

        camTrans.position = originalPositionOfCamera;

    }
}
