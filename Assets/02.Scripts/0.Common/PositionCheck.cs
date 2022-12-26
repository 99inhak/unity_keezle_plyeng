using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;
        Debug.Log("my name is " + transform.name + " x is " + pos.x + "  y is   " + pos.y + "  z is " + pos.z);
        // Debug.Log("my name is " + transform.name +  " z is " +transform.position.z ) ; 
    }
}
