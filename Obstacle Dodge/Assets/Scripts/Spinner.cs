using UnityEngine;

public class Spinner : MonoBehaviour
{

    [SerializeField] float xRotation = 0f;
    [SerializeField] float yRotation = 0f;
    [SerializeField] float zRotation = 0f;


    void Update()
    {
        transform.Rotate(xRotation, yRotation, zRotation);
    }
}
