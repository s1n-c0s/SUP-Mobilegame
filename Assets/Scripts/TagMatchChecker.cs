using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TagMatchChecker : MonoBehaviour
{
    public string zoneTag; // the tag of the zone that this object needs to match
    public Text successText; // the text that will be displayed if the tags match

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(zoneTag))
        {
            successText.gameObject.SetActive(true); // display success text
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(zoneTag))
        {
            successText.gameObject.SetActive(false); // hide success text
        }
    }
}

