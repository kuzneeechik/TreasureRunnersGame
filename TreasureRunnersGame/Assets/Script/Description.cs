using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] private GameObject targetObject; 

    private void OnMouseEnter()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(true); 
        }
    }

    private void OnMouseExit()
    {
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
}