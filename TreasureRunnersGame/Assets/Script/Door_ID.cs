using UnityEngine;

public class Door_ID : MonoBehaviour
{
    public string Id;
    public GameObject StoredObject;
    void Start()
    {
        StoredObject.SetActive(false);
    }
}
