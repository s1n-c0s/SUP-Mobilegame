using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectPlacementGame : MonoBehaviour
{
    public GameObject targetZone;
    public GameObject objectToPlace;
    public GameObject playerHand;
    public TextMeshProUGUI destroyedText;

    private bool hasWon = false;
    private bool isPlaced = false;

    public CountdownTimer countdownTimer;

    void Start()
    {
        // Set the destroyed text to inactive initially
        destroyedText.gameObject.SetActive(false);
    }

    void Update()
    {
        /* if (objectToPlace.transform.position == targetZone.transform.position && !hasWon)
         {
             // Destroy the object
             Destroy(objectToPlace);

             // Set the destroyed text to active and update its text
             destroyedText.gameObject.SetActive(true);
             destroyedText.text = "SUCCESS!";

             Debug.Log("SUCCESS!");
         }
         else */
        if (isPlaced && !hasWon)
        {
            // Move the object to the center of the target zone
            objectToPlace.transform.position = targetZone.transform.position;

            // Set hasWon to true
            hasWon = true;

            Debug.Log("You win!");
            Destroy(objectToPlace);

            //Set the destroyed text to active and update its text
            destroyedText.gameObject.SetActive(true);
            destroyedText.text = "SUCCESS!";

            Debug.Log("SUCCESS!");
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