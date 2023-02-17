using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintLevel : MonoBehaviour
{
    public float refills;
    public GameObject canisterOnHolder;
    public float maxRefills;
    public float dif;
    public bool occupied;
    public string assignedColor;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canisterOnHolder != null)
        {
            dif = maxRefills - canisterOnHolder.GetComponent<SnapToHolder>().refills;
        }
    }
    
    

}
