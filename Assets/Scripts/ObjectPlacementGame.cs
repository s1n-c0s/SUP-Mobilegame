using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacementGame : MonoBehaviour
{
    public GameObject targetZone;
    public GameObject objectToPlace;
    public GameObject playerHand;
    public Text destroyedText;

    private bool hasWon = false;
    private bool isPlaced = false;

    void Start()
    {
        // Set the destroyed text to inactive initially
        destroyedText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (objectToPlace.transform.position == targetZone.transform.position && !hasWon)
        {
            // Destroy the object
            Destroy(objectToPlace);

            // Set the destroyed text to active and update its text
            destroyedText.gameObject.SetActive(true);
            destroyedText.text = "SUCCESS!";

            Debug.Log("SUCCESS!");
        }
        else
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


























/*using UnityEngine;

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
}*/

/*using UnityEngine;

public class ObjectPlacementGame : MonoBehaviour
{
    public GameObject targetZone;
    public GameObject objectToPlace;
    public GameObject playerHand;

    private bool hasWon = false;
    private bool isPlaced = false;

    void Update()
    {
        if (isPlaced && !hasWon)
        {
            // Move the object to the center of the target zone
            objectToPlace.transform.position = targetZone.transform.position;

            // Set hasWon to true
            hasWon = true;

            Debug.Log("You win!");
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
*/