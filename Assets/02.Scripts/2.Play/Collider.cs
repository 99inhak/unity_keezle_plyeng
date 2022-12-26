using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{

    public GameObject left;
    public GameObject right;

    // Start is called before the first frame update
    void Start()
    {
        left.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.005f, 0.5f, 0.5f));
        right.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(0.995f, 0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
