using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float thrustForce = 100f;
    [SerializeField] float rotateSpeed = 100f;
    [SerializeField] AudioClip engingeThrust;
    [SerializeField] ParticleSystem leftBoosterParticles;
    [SerializeField] ParticleSystem rightBoosterParticles;
    [SerializeField] ParticleSystem mainBoosterParticles;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            LeftRotationStart();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RightRotationStart();
        }
        else
        {
            RotationStop();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * thrustForce * Time.deltaTime);
        if (!audioSource.isPlaying) audioSource.PlayOneShot(engingeThrust);
        if (!mainBoosterParticles.isPlaying) mainBoosterParticles.Play();
    }

    private void StopThrusting()
    {
        audioSource.Stop();
        mainBoosterParticles.Stop();
    }

    void RightRotationStart()
    {
        ApplyRotation(-rotateSpeed);
        if (!leftBoosterParticles.isPlaying) leftBoosterParticles.Play();
    }

    void LeftRotationStart()
    {
        ApplyRotation(rotateSpeed);
        if (!rightBoosterParticles.isPlaying) rightBoosterParticles.Play();
    }

    void RotationStop()
    {
        leftBoosterParticles.Stop();
        rightBoosterParticles.Stop();
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}