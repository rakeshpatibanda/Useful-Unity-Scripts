using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundScroll : MonoBehaviour
{
    // GET ACCESS TO THE MATERIAL OF THIS PARTICULAR OBJECT
    Material material;

    // NEW VECTOR2 VARIABLE TO SET OFFSET VALUE
    Vector2 offset;

    // INT VARIBALES FOR SETTING THE VALUES OF THE MAINTEXTUREOFFSET OF THIS OBJECT
    public int xVelocity;
    public int yVelocity;


    public void Awake() {
        // WHEN UNITY STARTS ASSIGN THE MATERIAL VALUE TO THE MATERIAL VALUE OF THIS FOREGROUND OBJECT
        material = GetComponent<Renderer>().material;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Setting the new offset value to time
        offset = new Vector2(xVelocity, yVelocity);
    }

    // Update is called once per frame
    void Update()
    {
        material.mainTextureOffset += offset * Time.deltaTime;
    }
}
