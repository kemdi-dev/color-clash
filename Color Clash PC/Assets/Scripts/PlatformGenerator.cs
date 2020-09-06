using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween = 80;
    private float platformWidth;

    public ObjectPooler theObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        platformWidth = thePlatform.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.z < generationPoint.position.z) //this is for when not using object pooling...
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth + distanceBetween);
            Instantiate(thePlatform, transform.position, transform.rotation);
        }*/

        if (transform.position.z < generationPoint.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + platformWidth + distanceBetween);

            GameObject newPlatform = theObjectPool.GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }


    }
}
