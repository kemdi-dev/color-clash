using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasResize : MonoBehaviour
{
    Canvas canvas;
    float hCanvas;
    float wCanvas;

    Vector2 uiSize;
    float uiWidth;
    float uiHeight;
    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();
        hCanvas = canvas.GetComponent<RectTransform>().rect.height;
        wCanvas = canvas.GetComponent<RectTransform>().rect.width;
        /*uiWidth = this.GetComponent<RectTransform>().rect.width;
        uiHeight = this.GetComponent<RectTransform>().rect.height;*/
        uiSize = this.GetComponent<RectTransform>().sizeDelta;

        uiWidth = uiSize.x;
        uiHeight = uiSize.y;
    }

    // Update is called once per frame
    void Update()
    {
        //uiHeight = 200;
        if(uiHeight > hCanvas/2)
        {
            uiHeight = hCanvas / 2;
            uiSize = new Vector2(uiWidth, uiHeight);
            Debug.Log("the new hight is " + uiHeight);
        }
    }
}
