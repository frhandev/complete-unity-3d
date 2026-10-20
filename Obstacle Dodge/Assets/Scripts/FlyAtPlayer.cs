using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 8f;
    Vector3 playerPosition;

    void Start()
    {
        playerPosition = playerTransform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);

        DestroyWhenReached();
    }

    void DestroyWhenReached()
    {
        if (transform.position == playerPosition)
        {
            Destroy(gameObject);
        }
    }
}
