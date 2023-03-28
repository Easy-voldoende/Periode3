using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class MachineScript : MonoBehaviour
{
    public GameObject objectToPaint;
    public GameObject objectToPaintPrefab;
    public Transform spawnPos;
    public GameObject missionDropoff;
    public GameObject[] paintCanisters;
    public GameObject missionSystem, startingPoint;
    public int refills;
    public Color finalColor;
    public bool painted;
    public string missionColor;
    public bool canMix;
    
    public int colorMatchup;
    public bool isMatching, missionCompleted;
    public int i;
    
    
    
    void Start()
    {
        painted = false;
        objectToPaint = Instantiate(objectToPaintPrefab, spawnPos.position, Quaternion.identity);
        
    }
    public void Update()
    {
        if(objectToPaint != null)
        {
            if (painted == false && objectToPaint.GetComponent<WaypointMover>().finished == true)
            {
                Renderer rend = objectToPaint.GetComponent<Renderer>();
                Color color = finalColor;
                rend.material.color = color;
                painted = true;
            }

            if (colorMatchup == missionSystem.GetComponent<MissionSystem>().missionIndex)
            {
                missionDropoff.GetComponent<CheckForMissionComplete>().canCheck = true;
                isMatching = true;
            }
            else
            {
                missionDropoff.GetComponent<CheckForMissionComplete>().canCheck = false;
                isMatching = false;
            }
        }
    }
    public void NewCanister()
    {
        Destroy(objectToPaint);
        objectToPaint = Instantiate(objectToPaintPrefab, spawnPos.position, Quaternion.identity);
    }
    public void ColorGreen()
    {
        if(objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 0;
            i = 0;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {
                    finalColor = Color.green;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                    
                }
            }
            else
            {

                finalColor = Color.white;
                canMix = false;
            }
        }
    }

    public void ColorRed()
    {
        if(objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 1;
            i = 1;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {
                    finalColor = Color.red;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }
            }
            else
            {
                finalColor = Color.white;
                canMix = false;

            }
        }
        
        
        
        
    }

    public void ColorBlue()
    {

        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 2;
            i = 2;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.blue;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {

                finalColor = Color.white;
                canMix = false;
            }
        }

        
        

    }


    public void ColorMagenta()
    {

        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 3;
            i = 3;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.magenta;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {
                finalColor = Color.white;
                canMix = false;

            }
        }
        

        
    }

    public void ColorBlack()
    {
        

        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 4;
            i = 4;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.black;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {
                finalColor = Color.white;
                canMix = false;
            }
        }
        
    }
    public void ColorYellow()
    {
        
        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 5;
            i = 5;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.yellow;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {
                finalColor = Color.white;
                canMix = false;

            }
        }
        
    }

    public void ColorCyan()
    {
        

        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 6;
            i = 6;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.cyan;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {
                finalColor = Color.white;
                canMix = false;

            }
        }
        
    }
    public void ColorGray()
    {
        
        if (objectToPaint.GetComponent<WaypointMover>().isMixing == false)
        {
            colorMatchup = 7;
            i = 7;
            if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder != null)
            {
                if (paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills > 0)
                {

                    finalColor = Color.gray;
                    objectToPaint.GetComponent<WaypointMover>().color = finalColor;
                    paintCanisters[i].GetComponent<PaintLevel>().canisterOnHolder.GetComponent<SnapToHolder>().refills -= 1;
                    canMix = true;
                }


            }
            else
            {
                finalColor = Color.white;
                canMix = false;

            }
        }
        
    }


    public void ActivateMachine()
    {
        
        if(canMix == true && Vector3.Distance(objectToPaint.transform.position, startingPoint.transform.position)<0.25f)
        {
            objectToPaint.GetComponent<WaypointMover>().started = true;
            objectToPaint.GetComponent<WaypointMover>().finished = false;
            painted = false;
            objectToPaint.GetComponent<WaypointMover>().isMixing = true;
            objectToPaint.GetComponent<WaypointMover>().checkPoints = 0;
            objectToPaint.GetComponent<WaypointMover>().currentWaypoint = startingPoint.transform;
        }

    }


    
    
}
