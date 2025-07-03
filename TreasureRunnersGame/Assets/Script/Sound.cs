using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour  
{
    [SerializeField] private GameObject object1; 
    [SerializeField] private GameObject object2;
    [SerializeField] private Button button;

    private void Start()
    {
        UpdateObjectsState(); 
        button.onClick.AddListener(ToggleObjects);
    }

    private void UpdateObjectsState()
    {
        bool isEffectsMuted = Audio.Instance.IsEffectsMuted;
        object1.SetActive(!isEffectsMuted);
        object2.SetActive(isEffectsMuted);
    }

    private void ToggleObjects()
    {
        bool newState = !object1.activeSelf;
        object1.SetActive(newState);
        object2.SetActive(!newState);
        Audio.Instance.MuteEffects(!newState); 
    }
}