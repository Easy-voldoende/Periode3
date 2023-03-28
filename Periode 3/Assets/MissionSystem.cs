using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public int missionIndex;
    public GameObject missionPaperSpawner;
    public GameObject prefab;
    public GameObject prefabSpawned, spawnPos;
    public MachineScript machineScript;
    public bool ready;
    public string currentMissionColor;
    public string myColor;
    public enum MissionState
    {
        PICKING,
        PICKED,
        FINISHED,

    }

    public MissionState missionState;
    // Start is call
    private void Start()
    {
        
    }
    void Update()
    {
        
        if(ready == true)
        {
            ClickedOnStart();
            ready = false;
        }
    }
    public void ClickedOnStart()
    {
        missionIndex = Random.Range(0, 3);
        missionState = MissionState.PICKED;
        prefabSpawned = Instantiate(prefab,spawnPos.transform.position,Quaternion.identity);
        GetNextMission();
        
    }
    public void GetNextMission()
    {
        if(missionIndex == 0)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Green";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Green";
            machineScript.missionColor = "Green";
        }

        if (missionIndex == 1)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Red";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Red";
            machineScript.missionColor = "Red";
        }
            
        if (missionIndex == 2)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Blue";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Blue";
            machineScript.missionColor = "Blue";
        }
    }
    public IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.2f);
        prefabSpawned.GetComponent<Animator>().enabled = false;
    }
}
