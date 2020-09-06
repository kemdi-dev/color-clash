using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float offset;
    // Start is called before the first frame update
    void LateUpdate()
    {
        
        if(target != null)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z + offset);
        }
    }
}
