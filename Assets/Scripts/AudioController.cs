using StarterAssets;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip movingClip;
    public AudioClip stoppedClip;
    private AudioSource audioSource;
    private StarterAssetsInputs input;

    private bool isMoving = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        input = GetComponent<StarterAssetsInputs>();
    }

    void Update()
    {
        if (input.move.magnitude > 0)
        {
            if (!isMoving)
            {
                // Start playing the "moving" audio clip
                audioSource.clip = movingClip;
                audioSource.Play();
                isMoving = true;
            }
        }
        else
        {
            if (isMoving)
            {
                // Start playing the "stopped" audio clip
                audioSource.clip = stoppedClip;
                audioSource.Play();
                isMoving = false;
            }
        }
    }
}
