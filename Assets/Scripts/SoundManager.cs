
using UnityEngine;

[System.Serializable]
public class Sound
{
    
    public string Name;
    public AudioClip Clip;

    private AudioSource Source;


    public void SetSource(AudioSource source)
    {
        Source = source;
        source.clip = Clip;
    }

}
public class SoundManager : MonoBehaviour
{
    public AudioClip Start;
    public AudioClip Lose;
    public AudioClip Win;
    public AudioClip PickCapivara;

    public AudioSource sourceForTheClips;

    public static SoundManager instance;

    private void Awake()
    {
        instance = this;
    }
}


