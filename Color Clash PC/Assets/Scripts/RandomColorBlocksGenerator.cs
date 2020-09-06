using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorBlocksGenerator : MonoBehaviour
{
    public GameObject theColorBlock;
    public Transform cbGenerationPoint;
    public float distanceBetweenColorBlocks;
    private float colorBlockWidth = 0.2f; //actually ""depth" because of z

    private float distanceBetweenMin = 6;
    private float distanceBetweenMax = 10;

    public GameObject[] theColorBlocks;
    private int colorBlockSelector;

    //private float[] colorBlockWidths;

    // Start is called before the first frame update
    void Start()
    {
        colorBlockWidth = theColorBlock.transform.position.z;

        //colorBlockWidth = theColorBlocks.GetComponent<Transform>().localScale.z;
        /*colorBlockWidths = new float[theColorBlocks.Length];

        for (int i = 0; i < theColorBlocks.Length; i++)
        {
            colorBlockWidths[i] = theColorBlocks[i].transform.position.z;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < cbGenerationPoint.position.z)
        {
            distanceBetweenColorBlocks = Random.Range(distanceBetweenMin, distanceBetweenMax);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + colorBlockWidth + distanceBetweenColorBlocks);
            colorBlockSelector = Random.Range(0, theColorBlocks.Length);
            //Instantiate(theColorBlock, transform.position, transform.rotation);
            Instantiate(theColorBlocks[colorBlockSelector], transform.position, transform.rotation);
        }
    }
}
