using UnityEngine;
using System.Collections;

public class BubbleManager : MonoBehaviour
{
    public float speed = 2f; // Speed at which the bubbles float up
    public float amplitude = 2f; // Amplitude of the sine wave (left-right movement)
    public float frequency = 1f; // Frequency of the sine wave
    private Vector3 startPosition;
    private float randomOffset;
    private bool shouldMove = false; // To control movement start after delay
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Get the RectTransform of the bubble
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

        // Reset position if the bubble is fully off-screen
        if (rectTransform.position.y - rectTransform.rect.height / 2 > Screen.height)
        {
            ResetPosition();
        }
    }

    // Reset the bubble's position under the screen
    public void ResetPosition()
    {
        float x = Random.Range(0f, Screen.width); // Randomize the new starting x position
        transform.position = new Vector3(x, -rectTransform.rect.height, transform.position.z); // Start completely below the screen
    }

    // Coroutine to introduce a random start delay
    IEnumerator StartWithDelay()
    {
        float randomDelay = Random.Range(0f, 2f); // Random delay between 0 and 2 seconds
        yield return new WaitForSeconds(randomDelay);

        shouldMove = true; // Start movement after the delay
    }
}
