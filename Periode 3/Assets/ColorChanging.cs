using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ColorChanging : MonoBehaviour
{
    [Range(0f, 1f)]
    public float r;

    [Range(0f, 1f)]
    public float g;

    [Range(0f, 1f)]
    public float b;

    [Range(0f,1f)]
    public float a;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();     
    }

    // Update is called once per frame
    void Update()
    {
        Color color = new Color(r, g, b,a);
        rend.material.SetColor("_BaseColor", color);
    }
}
