using UnityEngine;
using System.Collections;
//using System.Linq;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] painSounds;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    [ContextMenu("Play Sound")]
    void playSnd()
    {
        int i = Random.Range(0, painSounds.Length);
        audioSource.PlayOneShot(painSounds[i], 0.7f);
    }
}