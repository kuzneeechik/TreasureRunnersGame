using UnityEngine;

public class Description : MonoBehaviour
{
    [SerializeField] private GameObject TargetObject; 

    private void OnMouseEnter()
    {
        if (TargetObject != null)
        {
            TargetObject.SetActive(true); 
        }
    }

    private void OnMouseExit()
    {
        if (TargetObject != null)
        {
            TargetObject.SetActive(false);
        }
    }
}