using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChildColorPicker : MonoBehaviour
{
    //private GameObject child;
    private int noOfChildren;
    private Renderer[] forColor;
    public Color[] colors = { new Color(0.88f, 0.23f, 0.23f, 1f), new Color(0.23f, 0.88f, 0.66f, 1f), new Color(0.11f, 0.38f, 0.66f, 1f) };

    Material child1;
    Material child2;
    Material child3;

    Color one;
    Color two;
    Color three;

    // Start is called before the first frame update
    void Start()
    {
        noOfChildren = this.transform.childCount;
        forColor = GetComponentsInChildren<Renderer>();
        
        child1 = forColor[0].material;
        one = colors[Random.Range(0, colors.Length)];
        two = colors[Random.Range(0, colors.Length)];
        three = colors[Random.Range(0, colors.Length)];

        while(one == two)
        {
            two = colors[Random.Range(0, colors.Length)];
            while (two == three)
            {
                three = colors[Random.Range(0, colors.Length)];
            }
        }
        while (two == three)
        {
            three = colors[Random.Range(0, colors.Length)];
        }

        child1.color = one;

        if (noOfChildren == 2)
        {
            child2 = forColor[1].material;
            child2.color = two;
        } else if (noOfChildren > 2)
        {
            child2 = forColor[1].material;
            child2.color = two;
            child3 = forColor[2].material;
            child3.color = three;
        }
        /*if (noOfChildren == 2)
        {
            child2 = forColor[1].material;
            
            while (child1 == child2)
            {
                child1.color = colors[Random.Range(0, colors.Length)];
            }
            Debug.Log("child 1 color " + child1);
            Debug.Log("child 2 color " + child2);
        } else if (noOfChildren == 3)
        {
            child2 = forColor[1].material;
            child2.color = colors[Random.Range(0, colors.Length)];
            child3 = forColor[2].material;
            
            while (child1 == child2)
            {
                child2.color = colors[Random.Range(0, colors.Length)];
                while (child2 == child3)
                {
                    child3.color = colors[Random.Range(0, colors.Length)];
                }
            }
            
        }*/
            /*GameObject child1 = this.gameObject.transform.GetChild(0).gameObject;
            foreach (Color clr in forColor)
            {
                if(noOfChildren == 2)
                {
                    Color color1 = child1.GetComponent<Renderer>;
                }
            }*/
            //child = this.gameObject.transform.GetChild(i).gameObject;


    }
}
