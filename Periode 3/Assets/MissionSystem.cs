using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MissionSystem : MonoBehaviour
{
    public int missionIndex;
    public GameObject missionPaperSpawner;
    public GameObject prefab;
    public GameObject prefabSpawned, spawnPos,previousMissionPaper;
    public MachineScript machineScript;
    public bool ready, swappedMission;
    public string currentMissionColor;
    public string myColor;
    public float multiplier;
    public int i;
    public enum MissionState
    {
        PICKING,
        PICKED,
        FINISHED,

    }
    private void Start()
    {
        multiplier = 1;
    }
    public MissionState missionState;
    void Update()
    {
        
        if(ready == true)
        {
            ClickedOnStart();
            ready = false;
        }
        if(swappedMission == true && previousMissionPaper !=null)
        {
            previousMissionPaper.GetComponent<DestroyThisObject>().destroy = true;
        }
    }
    public void ClickedOnStart()
    {
        swappedMission = true;
        if(prefabSpawned != null)
        {
            previousMissionPaper = prefabSpawned;
        }        
        missionIndex = Random.Range(0, 15);
        
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
        if (missionIndex == 3)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Magenta";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Magenta";
            machineScript.missionColor = "Magenta";
        }
        if (missionIndex == 4)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Black";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Black";
            machineScript.missionColor = "Black";
        }
        if (missionIndex == 5)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Yellow";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Yellow";
            machineScript.missionColor = "Yellow";
        }
        if (missionIndex == 6)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Cyan";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Cyan";
            machineScript.missionColor = "Cyan";
        }
        if (missionIndex == 7)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Gray";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Gray";
            machineScript.missionColor = "Gray";
        }
        if (missionIndex == 8)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Orange";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Orange";
            machineScript.missionColor = "Orange";
        }
        if (missionIndex == 9)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Brown";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Brown";
            machineScript.missionColor = "Brown";
        }
        if (missionIndex == 10)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "White";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "White";
            machineScript.missionColor = "White";
        }
        if (missionIndex == 11)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Purple";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Purple";
            machineScript.missionColor = "Purple";
        }
        if (missionIndex == 12)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Olive";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Olive";
            machineScript.missionColor = "Olive";
        }
        if (missionIndex == 13)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Indigo";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Indigo";
            machineScript.missionColor = "Indigo";
        }
        if (missionIndex == 14)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Gold";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Gold";
            machineScript.missionColor = "Gold";
        }
        if (missionIndex == 15)
        {
            prefabSpawned.GetComponent<FindText>().colorText.GetComponent<TextMeshProUGUI>().text = "Silver";
            StartCoroutine(nameof(StopAnim));
            currentMissionColor = "Silver";
            machineScript.missionColor = "Silver";
        }

    }
    public IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(0.2f);
        prefabSpawned.GetComponent<Animator>().enabled = false;
    }
}
