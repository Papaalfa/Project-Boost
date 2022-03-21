using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        float cycles = Time.time * period; // constantly growing over time

        const float tau = Mathf.PI * 2f; // constant of 6.283
        float rawSin = Mathf.Sin(tau * cycles); // going from -1 to 1

        movementFactor = (rawSin + 1f) / 2f; // calculate to move from 0 to 1
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
