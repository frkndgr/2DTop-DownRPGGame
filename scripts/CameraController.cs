using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;
    public float smoothing;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);


        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    
    }
}
