using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockDestroyer : MonoBehaviour
{
    /*private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.z < (playerTransform.position.z - 4f))
        {
            //this.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }

    }*/

    public GameObject colorBlockDestructionPoint;

    private Transform playerTransform;

    private float noOfChildren;
    //private Transform childPosition;

    // Start is called before the first frame update
    void Start()
    {
        colorBlockDestructionPoint = GameObject.Find("cbDestructionPoint");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        noOfChildren = this.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < noOfChildren; i++) //for resetting the child back to true so that when the parent is reset to true, the child is visible.
        {
            if (transform.position.z < colorBlockDestructionPoint.transform.position.z)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            
        }

        /*for (int i = 0; i < noOfChildren; i++)
        {
            childPosition = this.transform.GetChild(i);
        }*/
    }
}
