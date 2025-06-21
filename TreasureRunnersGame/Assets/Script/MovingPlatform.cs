using UnityEngine;
using UnityEngine.Rendering;

public class MovingPlatform : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2"))
        {
            var follower = collision.gameObject.GetComponent<FollowMoving>();

            if (follower != null)
            {
                follower.SetPlatform(transform);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") ||
            collision.gameObject.CompareTag("Player2"))
        {
            var follower = collision.gameObject.GetComponent<FollowMoving>();

            if (follower != null)
            {
                follower.ClearPlatform();
            }
        }
    }
}
