using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour  
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
        bool isEffectsMuted = Audio.Instance.IsEffectsMuted;

        Object1.SetActive(!isEffectsMuted);
        Object2.SetActive(isEffectsMuted);
    }

    private void ToggleObjects()
    {
        bool newState = !Object1.activeSelf;

        Object1.SetActive(newState);
        Object2.SetActive(!newState);

        Audio.Instance.MuteEffects(!newState); 
    }
}