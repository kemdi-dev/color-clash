using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColorPicker : MonoBehaviour
{
    Material ballMaterial;
    public Color[] colors = { new Color(0.88f, 0.23f, 0.23f, 1f), new Color(0.23f, 0.88f, 0.66f, 1f), new Color(0.11f, 0.38f, 0.66f, 1f) };
    // Start is called before the first frame update
    void Start()
    {
        ballMaterial = GetComponent<Renderer>().material;
        ballMaterial.color = colors[Random.Range(0, colors.Length)];
    }
}
