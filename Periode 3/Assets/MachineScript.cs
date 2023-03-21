using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    public GameObject[] paintCanisters;
    public int refills;
    bool refilled;
    public Color finalColor;
    public bool painted;
    
    void Start()
    {
        painted = false;
    }
    public void Update()
    {
        if(painted == false && objectToPaint.GetComponent<WaypointMover>().finished == true)
        {
            Renderer rend = objectToPaint.GetComponent<Renderer>();
            Color color = finalColor;
            rend.material.color = color;
            painted = true;
        }
    }
    public void ColorGreen()
    {
        if (paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                finalColor = Color.green;   
                paintCanisters[0].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }
        }
        else
        {
            
            finalColor = Color.white;
            
        }
    }

    public void ColorRed()
    {
        if (paintCanisters[1].GetComponent<PaintLevel>().refills! > 0)
        {
            return;
        }
        if (paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                finalColor = Color.red;                
                paintCanisters[1].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }
        }
        else
        {
            finalColor = Color.white;
            
        }

    }

    public void ColorBlue()
    {
        if(paintCanisters[2].GetComponent<PaintLevel>().refills !> 0)
        {
            return;
        }
        if (paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                
                finalColor = Color.blue;
                
                paintCanisters[2].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }


        }
        else
        {
            
            finalColor = Color.white;
            
        }
    }


    public void ColorMagenta()
    {
        if (paintCanisters[3].GetComponent<PaintLevel>().refills! > 0)
        {
            return;
        }
        if (paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder != null)
        {
            if (paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
            {
                
                finalColor = Color.magenta;
                
                paintCanisters[3].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
            }


        }
        else
        {
            finalColor = Color.white;
            
        }
    }

    public void ActivateMachine()
    {
        
        objectToPaint.GetComponent<WaypointMover>().started = true;
        objectToPaint.GetComponent<WaypointMover>().finished = false;
        painted = false;
    }


    public void GoToOrders()
    {

    }
}
