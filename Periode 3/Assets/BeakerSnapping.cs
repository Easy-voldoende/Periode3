using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerSnapping : MonoBehaviour
{
    // Start is called before the first frame update
    public bool inHand;
    public bool snapped;
    public bool canisterIsFull;
    public string assignedRefillColor;
    public float refills;
    public GameObject myHolder;
    public float yOffset;
    public Color newColor;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "BeakerPlacement" && inHand == false && snapped == false)
        {
            if (collision.gameObject.GetComponent<PaintLevel>().assignedColor == assignedRefillColor)
            {
                myHolder = collision.gameObject;
                collision.gameObject.GetComponent<PaintLevel>().canisterOnHolder = gameObject;
                collision.gameObject.GetComponent<PaintLevel>().occupied = true;
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                yOffset = collision.gameObject.transform.localScale.y / 2;
                Quaternion desiredRot = new Quaternion(0, 0, 0, 0);
                gameObject.transform.rotation = desiredRot;
                Vector3 snapPos = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, collision.gameObject.transform.position.z);
                Vector3 offset = new Vector3(0, yOffset, 0);
                gameObject.transform.position = snapPos + offset;
                snapped = true;

            }

        }

    }
}
