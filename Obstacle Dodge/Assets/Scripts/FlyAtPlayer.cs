using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 8f;
    Vector3 playerPosition;

    void Start()
    {

    }

    void Update()
    {
        playerPosition = playerTransform.position;

        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }
}
