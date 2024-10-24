using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour
{
    public float speed = 80f; // Speed at which the bubbles float up
    public float amplitude = 20f; // Amplitude of the sine wave (left-right movement)
    public float frequency = 5f; // Frequency of the sine wave
    private Vector3 startPosition;
    private float randomOffset;
    private bool shouldMove = false; // To control movement start after delay

    void Start()
    {
        startPosition = transform.position;
        randomOffset = Random.Range(0f, 2f * Mathf.PI); // Random phase offset for each bubble

        // Start the coroutine to delay the movement
        StartCoroutine(StartWithDelay());
    }

    void Update()
    {
        if (!shouldMove) return; // Only move the bubble after the delay

        // Move the bubble upwards along the y-axis
        float newY = transform.position.y + speed * Time.deltaTime;

        // Create the sine wave effect for the x-axis
        float newX = startPosition.x + Mathf.Sin(Time.time * frequency + randomOffset) * amplitude;

        // Apply the new position
        transform.position = new Vector3(newX, newY, transform.position.z);

        // Reset position if the bubble goes off-screen
        if (transform.position.y > Screen.height)
        {
            ResetPosition();
        }
    }

    // Reset the bubble's position under the screen
    public void ResetPosition()
    {
        float x = Random.Range(0f, Screen.width); // Randomize the new starting x position
        transform.position = new Vector3(x, -50f, transform.position.z); // Start under the screen
    }

    // Coroutine to introduce a random start delay
    IEnumerator StartWithDelay()
    {
        float randomDelay = Random.Range(0f, 2f); // Random delay between 0 and 2 seconds
        yield return new WaitForSeconds(randomDelay);

        shouldMove = true; // Start movement after the delay
    }
}
