using System;
using UnityEngine;

public class LevelManager : SceneSingleton<LevelManager>
{
    public event Action OnLevelStart;

    [SerializeField] private int _maxPlayersToJoin = 2;

    private int _playersJoined;

    public void OnJoinPlayer()
    {
        _playersJoined++;
        if (_playersJoined == _maxPlayersToJoin) OnLevelStart?.Invoke();
    }
}