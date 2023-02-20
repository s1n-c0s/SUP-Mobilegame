using UnityEngine;

public class ObjectPlacementGame : MonoBehaviour
{
    public GameObject targetZone;
    public GameObject objectToPlace;

    private bool hasWon = false;

    void Start()
    {
        // Disable the collider on the target zone
        targetZone.GetComponent<Collider>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToPlace && !hasWon)
        {
            // Enable the collider on the target zone
            targetZone.GetComponent<Collider>().enabled = true;
            
            // Move the object to the center of the target zone
            objectToPlace.transform.position = targetZone.transform.position;

            // Set hasWon to true
            hasWon = true;

            Debug.Log("You win!");
        }
    }
}