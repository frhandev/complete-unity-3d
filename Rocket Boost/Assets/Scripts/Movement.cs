using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;

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
        }
    }

    private void ProcessedRotaion()
    {
        float rotationInput = rotation.ReadValue<float>();

        if (rotationInput > 0)
        {
            ApplyRotation(-rotationSpeed);
        }
        else if (rotationInput < 0)
        {
            ApplyRotation(rotationSpeed);
        }
    }

    private void ApplyRotation(float rotaion)
    {
        rigidbody.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotaion * Time.fixedDeltaTime);
        rigidbody.freezeRotation = false;
    }
}
