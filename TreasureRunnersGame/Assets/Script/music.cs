using UnityEngine;
using UnityEngine.UI; 

public class music : MonoBehaviour
{
    [SerializeField] private GameObject object1; 
    [SerializeField] private GameObject object2; 
    [SerializeField] private Button button; 

    private void Start()
    {
        object1.SetActive(true);
        object2.SetActive(false);

        button.onClick.AddListener(ToggleObjects);
    }

    private void ToggleObjects()
    {
        object1.SetActive(!object1.activeSelf);
        object2.SetActive(!object2.activeSelf);
    }
}