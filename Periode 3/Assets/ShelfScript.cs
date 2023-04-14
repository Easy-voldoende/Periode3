using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public Transform[] snapPositions;
    public MissionSystem missionSystem;
    public bool completed;
    public int i;
    public void Update()
    {
        if(i == snapPositions.Length && completed == true)
        {
            completed = false;
            i = 10;
            missionSystem.CompletedMissions();
        }
        
    }
}
