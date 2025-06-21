using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Arrow;
    public Transform FirePoint;
    public float Interval;
    public float Speed;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 0f, Interval);
    }

    void Shoot()
    {
        GameObject arrow = Instantiate(Arrow, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = FirePoint.right * Speed;
        }
    }
}
