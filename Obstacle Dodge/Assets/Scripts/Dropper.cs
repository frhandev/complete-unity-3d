using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float waitTime = 3f;

    MeshRenderer meshRenderer;
    Rigidbody rigidbody;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
        rigidbody.useGravity = false;
    }

    void Update()
    {
        if (Time.time > waitTime)
        {
            meshRenderer.enabled = true;
            rigidbody.useGravity = true;
        }
    }
}
