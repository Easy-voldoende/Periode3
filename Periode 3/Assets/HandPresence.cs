using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public GameObject handModelPrefab;
    public List<GameObject> controllerPrefabs;
    public Animator leftHand, righthand;

    private InputDevice targetDevice;
    private GameObject spawnedHand;
    private GameObject spawnedController;
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }
        StartCoroutine(nameof(Setup));

            
    }
    public IEnumerator Setup()
    {
        yield return new WaitForSeconds(1);        
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];

            if (controllerPrefabs[0] != null)
            {
                spawnedHand = Instantiate(controllerPrefabs[0], transform);
            }
            else
            {
                Debug.LogError("Did not find controller model");
                spawnedHand = Instantiate(controllerPrefabs[0], transform);
            }
        }
    }
    // Update is called once per frame

    public void UpdateHandAnimation()
    {
        
    }
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primaryButtonValue);

        if(primaryButtonValue == true)
        {
            Debug.Log("Pressing Primary Button");
        }

        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue);

        if (triggerButtonValue >.2f)
        {
            Debug.Log("Pressing Trigger Button");
        }

        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 axisButtonValue);

        if (axisButtonValue != Vector2.zero)
        {
            Debug.Log("Moving Stick");
        }
    }
}
