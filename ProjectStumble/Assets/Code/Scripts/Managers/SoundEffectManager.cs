using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : SceneSingleton<SoundEffectManager>
{
    private AudioSource _audioSource;

    [BoxGroup("Player"), SerializeField] private AudioClip _jumpSFX;
    [BoxGroup("Player"), SerializeField] private AudioClip _collideWithOppSFX;

    [BoxGroup("Level"), SerializeField] private AudioClip _levelStartSFX;
    [BoxGroup("Level"), SerializeField] private AudioClip _levelFinishSFX;
    [BoxGroup("Level"), SerializeField] private AudioClip[] _playerJoinSFX;

    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _speedBoostSFX;
    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _wetterSFX;
    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _invertControlsSFX;
    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _shrinkSFX;
    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _stunSFX;
    [BoxGroup("Player Abilities"), SerializeField] private AudioClip _gainPoweupSFX;


    public AudioClip JumpSFX => _jumpSFX;
    public AudioClip LevelStartSFX => _levelStartSFX;
    public AudioClip LevelFinishSFX { get => _levelFinishSFX; set => _levelFinishSFX = value; }
    public AudioClip[] PlayerJoinSFX => _playerJoinSFX;
    public AudioClip SpeedBoostSFX { get => _speedBoostSFX; set => _speedBoostSFX = value; }
    public AudioClip WetterSFX { get => _wetterSFX; set => _wetterSFX = value; }
    public AudioClip InvertControlsSFX { get => _invertControlsSFX; set => _invertControlsSFX = value; }
    public AudioClip ShrinkSFX { get => _shrinkSFX; set => _shrinkSFX = value; }
    public AudioClip StunSFX { get => _stunSFX; set => _stunSFX = value; }
    public AudioClip GainPoweupSFX { get => _gainPoweupSFX; set => _gainPoweupSFX = value; }
    public AudioClip CollideWithOppSFX { get => _collideWithOppSFX; set => _collideWithOppSFX = value; }

    private void Start() => _audioSource = GetComponent<AudioSource>();

    public void PlaySoundEffect(AudioClip clip, float volume = 1, float pitch = 1)
    {
        _audioSource.volume = volume;
        _audioSource.pitch = pitch;
        _audioSource.PlayOneShot(clip);
    }
}
