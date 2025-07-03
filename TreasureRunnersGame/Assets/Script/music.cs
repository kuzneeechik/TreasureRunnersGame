using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    [SerializeField] private GameObject Object1;
    [SerializeField] private GameObject Object2; 
    [SerializeField] private Button Button;

    private void Start()
    {
        UpdateObjectsState();
        Button.onClick.AddListener(ToggleObjects);
    }

    private void UpdateObjectsState()
    {
        bool isMuted = Audio.Instance.IsMuted; 

        Object1.SetActive(!isMuted);
        Object2.SetActive(isMuted);
    }

    private void ToggleObjects()
    {
        bool newState = !Object1.activeSelf;

        Object1.SetActive(newState);
        Object2.SetActive(!newState);

        Audio.Instance.MuteMusic(!newState);
    }
}