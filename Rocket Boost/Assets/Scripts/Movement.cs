using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] AudioSource audioSource;
    [SerializeField] ParticleSystem boosterParticle;
    [SerializeField] ParticleSystem rightParticle;
    [SerializeField] ParticleSystem leftParticle;


    [SerializeField] float thrustStrength = 8f;
    [SerializeField] float rotationSpeed = 16f;


    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    void FixedUpdate()
    {
        ProcessThrust();

        ProcessedRotaion();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rigidbody.AddRelativeForce(Vector3.up * thrustStrength * Time.fixedDeltaTime);

            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(mainEngineSFX);
            }
            if (!boosterParticle.isPlaying)
            {
                boosterParticle.Play();
            }
        }
        else
        {
            audioSource.Stop();
            boosterParticle.Stop();
        }
    }

    private void ProcessedRotaion()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput > 0)
        {
            ApplyRotation(-rotationSpeed);
            if (!leftParticle.isPlaying)
            {
                rightParticle.Stop();
                leftParticle.Play();
            }
        }
        else if (rotationInput < 0)
        {
            ApplyRotation(rotationSpeed);
            if (!rightParticle.isPlaying)
            {
                leftParticle.Stop();
                rightParticle.Play();
            }
        }
        else
        {
            rightParticle.Stop();
            leftParticle.Stop();
        }
    }

    private void ApplyRotation(float rotaion)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotaion * Time.fixedDeltaTime);
        rigidbody.freezeRotation = false;
    }
}
