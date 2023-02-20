using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public Transform handPosition;
    public float pickupDistance;
    public KeyCode pickupKey;
    public KeyCode dropKey;

    private GameObject carriedObject;
    private bool isCarrying;

    void Update()
    {
        if (!isCarrying)
        {
            // Check if there is an object in range to pick up
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickupDistance))
            {
                if (hit.collider.gameObject.CompareTag("Pickupable"))
                {
                    if (Input.GetKeyDown(pickupKey))
                    {
                        // Pick up the object
                        carriedObject = hit.collider.gameObject;
                        carriedObject.GetComponent<Rigidbody>().isKinematic = true;
                        carriedObject.transform.position = handPosition.position;
                        carriedObject.transform.parent = handPosition;
                        isCarrying = true;
                    }
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(dropKey))
            {
                // Drop the object
                carriedObject.GetComponent<Rigidbody>().isKinematic = false;
                carriedObject.transform.parent = null;
                carriedObject = null;
                isCarrying = false;
            }
        }
    }
}