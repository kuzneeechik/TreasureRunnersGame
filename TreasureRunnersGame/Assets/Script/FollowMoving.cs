using UnityEngine;

public class FollowMoving : MonoBehaviour
{
    private Transform currentPlatform;
    private Vector3 lastPlatformPosition;

    void LateUpdate()
    {
        if (currentPlatform != null)
        {
            Vector3 platformDelta = currentPlatform.position - lastPlatformPosition;
            transform.position += platformDelta;
            lastPlatformPosition = currentPlatform.position;
        }
    }

    public void SetPlatform(Transform platform)
    {
        currentPlatform = platform;
        lastPlatformPosition = platform.position;
    }

    public void ClearPlatform()
    {
        currentPlatform = null;
    }
}
