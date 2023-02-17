using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using UnityEngine.XR;

public class LeftHand : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    public List<GameObject> controllerPrefabs;
    public Animator hand;

    public InputDevice targetDevice;
    private GameObject spawnedHand;
    private GameObject spawnedController;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        hand = GetComponent<Animator>();
        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        StartCoroutine(nameof(Setup));


    }
    public IEnumerator Setup()
    {
        yield return new WaitForSeconds(0.25f);
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
            
        }
    }
    // Update is called once per frame

    public void UpdateHandAnimation()
    {
        if (targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            hand.SetFloat("Trigger", triggerValue);
            

        }
        else
        {
            hand.SetFloat("Trigger", 0);
        }


        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            hand.SetFloat("Grip", gripValue);
        }
        else
        {
            hand.SetFloat("Grip", 0);
        }
    }
    void Update()
    {

        
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if (primaryButtonValue == true)
        {
            Debug.Log("Pressing Primary Button");
        }

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue);

        if (triggerButtonValue > .2f)
        {
            Debug.Log("Pressing Trigger Button");
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisButtonValue);

        if (axisButtonValue != Vector2.zero)
        {
            Debug.Log("Moving Stick");
        }
        UpdateHandAnimation();
    }

    

}
