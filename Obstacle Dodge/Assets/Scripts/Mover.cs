using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10f;

    void Start()
    {
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float yValue = 0f;

        transform.Translate(xValue, yValue, zValue);
    }
}
