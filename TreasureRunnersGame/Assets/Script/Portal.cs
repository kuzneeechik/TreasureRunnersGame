using UnityEngine;

public class Portal : MonoBehaviour
{
    public Animator Animator;

    private void Start()
    {
        Animator = GetComponent<Animator>();
    }
}
