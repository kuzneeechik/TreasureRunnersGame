using UnityEngine;

public class FollowMoving : MonoBehaviour
{
    private Transform CurrentPlatform;
    private Vector3 LastPlatformPosition;

    void LateUpdate()
    {
        if (CurrentPlatform != null)
        {
            Vector3 platformDelta = CurrentPlatform.position - LastPlatformPosition;
            transform.position += platformDelta;
            LastPlatformPosition = CurrentPlatform.position;
        }
    }

    public void SetPlatform(Transform platform)
    {
        CurrentPlatform = platform;
        LastPlatformPosition = platform.position;
    }

    public void ClearPlatform()
    {
        CurrentPlatform = null;
    }
}
