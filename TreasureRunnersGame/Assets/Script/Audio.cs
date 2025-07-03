using UnityEngine;

public class Audio : MonoBehaviour
{
    public static Audio Instance;

    public AudioClip Background;
    public AudioClip Death;
    public AudioClip Artefact;
    public AudioClip Door;
    public AudioClip Portal;
    public AudioClip End;

    private AudioSource BackgroundPlayer;
    private AudioSource EffectsPlayer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            BackgroundPlayer = gameObject.AddComponent<AudioSource>();
            EffectsPlayer = gameObject.AddComponent<AudioSource>();

            BackgroundPlayer.clip = Background;
            BackgroundPlayer.loop = true;
            BackgroundPlayer.volume = 0.5f;
            BackgroundPlayer.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayDeath()
    {
        EffectsPlayer.PlayOneShot(Death);
    }

    public void PlayArtefact()
    {
        EffectsPlayer.PlayOneShot(Artefact);
    }

    public void PlayEnd()
    {
        EffectsPlayer.PlayOneShot(End);
    }

    public void PlayDoor()
    {
        EffectsPlayer.PlayOneShot(Door);
    }

    public void PlayPortal()
    {
        EffectsPlayer.PlayOneShot(Portal);
    }

    public void MuteMusic(bool isMute)
    {
        BackgroundPlayer.mute = isMute;
    }

    public void MuteEffects(bool isMute)
    {
        EffectsPlayer.mute = isMute;
    }
    public bool IsMuted => BackgroundPlayer.mute;
    public bool IsEffectsMuted => EffectsPlayer.mute;
}
