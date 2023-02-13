using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class aboutBuilds : MonoBehaviour
{
    public GameObject Build1; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Build1.gameObject.SetActive(true);
        //gameObject.SetActive(false); ?????????
    }

    private void OnTriggerExit(Collider other)
    {
        Build1.gameObject.SetActive(false);
    }
}
