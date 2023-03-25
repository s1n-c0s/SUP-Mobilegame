using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPlacementGame : MonoBehaviour
{
    public GameObject targetZone;
    public GameObject objectToPlace;
    public GameObject playerHand;
    public GameObject destroyedObject;

    private bool hasWon = false;
    private bool isPlaced = false;

    public CountdownTimer countdownTimer;

    void Start()
    {
        // Set the destroyed object to inactive initially
        destroyedObject.SetActive(false);
    }

    void Update()
    {
        if (isPlaced && !hasWon)
        {
            // Move the object to the center of the target zone
            objectToPlace.transform.position = targetZone.transform.position;

            // Set hasWon to true
            hasWon = true;

            Debug.Log("You win!");
            Destroy(objectToPlace);

            // Set the destroyed object to active after destroying the object to place
            destroyedObject.SetActive(true);

            countdownTimer.hasWon = true;
        }

        if (hasWon)
        {
            // Freeze the player
            playerHand.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectToPlace && !hasWon)
        {
            // Move the object to the player's hand and parent it to the hand
            objectToPlace.transform.position = playerHand.transform.position;
            objectToPlace.transform.parent = playerHand.transform;

            // Set isPlaced to true
            isPlaced = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectToPlace && !hasWon)
        {
            // Unparent the object from the player's hand and drop it
            objectToPlace.transform.parent = null;
            objectToPlace.GetComponent<Rigidbody>().isKinematic = false;

            // Set isPlaced to false
            isPlaced = false;
        }
    }
}
