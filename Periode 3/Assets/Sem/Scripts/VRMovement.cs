using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using Unity.VisualScripting;
using OVR;
using static UnityEngine.ParticleSystem;
using UnityEngine.UI;


public class VRMovement : MonoBehaviour
{
    Rigidbody rb;
    public bool isHardened;
    public InputMaster input;
    Vector2 inputAxis;
    CharacterController characterController;
    public XRNode inputSource;
    public XROrigin rig;
    public LayerMask ground;
    public float speed,maxSpeed;
    public float gravity, fallingspeed;
    public float cameraOffset;
    public float healResetTime;
    public GameObject cameraOrigin;
    public GameObject cam;
    public bool grabbedLeft;
    public bool grabbedRight;
    public GameObject rightObject;
    public GameObject leftObject;

    void Start()
    {
        
        
        rb = gameObject.GetComponent<Rigidbody>();
        characterController = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
        
    }
    
    
    public void Look(InputAction.CallbackContext context)
    {
        Debug.Log("Looking");

    }
    public void ResetHeight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            cam.transform.position = cameraOrigin.transform.position;
            Debug.Log("Resetting Cam");
        }
    }
    public void Movement(InputAction.CallbackContext context)
    {
        
        
        UnityEngine.XR.InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out inputAxis);
        speed += 5 * Time.deltaTime;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        if (context.canceled)
        {
            speed = 0;
        }
    }

    public void Update()
    {
        
    }
    private void FixedUpdate()
    {
        CapsuleFollowHeadset();

        Quaternion headDirection = Quaternion.Euler(x: 0, rig.Camera.transform.eulerAngles.y, z: 0);
        Vector3 direction = headDirection* new Vector3(inputAxis.x, y: 0, inputAxis.y);
        characterController.Move(direction * speed * Time.deltaTime);

        //bool grounded = CheckIfGrounded();

        
    }
    public bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(characterController.center);
        float rayLenth = characterController.center.y + cameraOffset + 0.001f;
        bool hasHit = Physics.SphereCast(rayStart, characterController.radius, Vector3.down, out RaycastHit hit, rayLenth, ground);
        return hasHit;
    }
    void CapsuleFollowHeadset()
    {
        float offset = 0.2f;
        GetComponent<CapsuleCollider>().height = rig.CameraInOriginSpaceHeight + offset;
        characterController.height = rig.CameraInOriginSpaceHeight+ offset;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.Camera.transform.position);
        characterController.center = new Vector3(capsuleCenter.x, characterController.height / 1.5f + characterController.skinWidth, capsuleCenter.z);
        GetComponent<CapsuleCollider>().center = new Vector3(capsuleCenter.x, characterController.height/1.5f+characterController.skinWidth, capsuleCenter.z);
    }
    
    public void GrabLeft(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grabbedLeft = true;
        }
    }

    public void GrabRight(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            grabbedRight = true;
        }
    }

}
