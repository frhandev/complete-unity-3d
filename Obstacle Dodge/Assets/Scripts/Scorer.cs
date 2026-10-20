using UnityEngine;

public class Scorer : MonoBehaviour
{
    int score = 0;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Hit")
        {
            score++;
            Debug.Log("You hit obstacles " + score.ToString() + " Times");
        }

    }
}
