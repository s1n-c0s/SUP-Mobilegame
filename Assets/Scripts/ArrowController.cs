using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform npcTransform;
    public float arrowDistance = 5f;

    private void Update()
    {
        // Calculate the direction from the player to the NPC
        Vector3 direction = npcTransform.position - playerTransform.position;
        direction.y = 0f;
        direction.Normalize();

        // Move the arrow to a position behind the player
        Vector3 arrowPosition = playerTransform.position - (direction * arrowDistance);
        arrowPosition.y = playerTransform.position.y;
        transform.position = arrowPosition;

        // Rotate the arrow to point towards the NPC
        transform.rotation = Quaternion.LookRotation(direction);
    }
}