using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockGeneratorMain : MonoBehaviour
{
    public GameObject theColorBlock;
    public Transform cbGenerationPoint;
    public float distanceBetweenColorBlocks;
    //private float colorBlockWidth = 0.2f; //actually ""depth" because of z
    private float[] colorBlockWidths;

    private float distanceBetweenMin = 6;
    private float distanceBetweenMax = 10;

    //public GameObject[] theColorBlocks;
    private int colorBlockSelector;


    public ObjectPooler[] theObjectPools;


    void Start()
    {
        //colorBlockWidth = theColorBlock.transform.position.z;

        colorBlockWidths = new float[theObjectPools.Length];

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            colorBlockWidths[i] = theObjectPools[i].pooledObject.transform.localScale.z;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < cbGenerationPoint.position.z)
        {
            distanceBetweenColorBlocks = Random.Range(distanceBetweenMin, distanceBetweenMax);
            colorBlockSelector = Random.Range(0, theObjectPools.Length);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + colorBlockWidths[colorBlockSelector] + distanceBetweenColorBlocks);
            
            //Instantiate(theColorBlocks[colorBlockSelector], transform.position, transform.rotation); //currently in use

            GameObject newPlatform = theObjectPools[colorBlockSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
