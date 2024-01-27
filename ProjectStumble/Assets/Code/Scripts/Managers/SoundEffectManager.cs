using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : SceneSingleton<SoundEffectManager>
{
    private AudioSource _audioSource;

    [SerializeField] private AudioClip _jumpSFX;
    [SerializeField] private AudioClip _levelStartSFX;
    [SerializeField] private AudioClip[] _playerJoinSFX;

    public AudioClip JumpSFX => _jumpSFX;
    public AudioClip LevelStartSFX => _levelStartSFX;
    public AudioClip[] PlayerJoinSFX => _playerJoinSFX; 

    private void Start() => _audioSource = GetComponent<AudioSource>();

    public void PlaySoundEffect(AudioClip clip, float volume = 1, float pitch = 1)
    {
        _audioSource.volume = volume;
        _audioSource.pitch = pitch;
        _audioSource.PlayOneShot(clip);
    }
}
