using System;
using System.Collections;
using UnityEngine;

public class LevelManager : SceneSingleton<LevelManager>
{
    public event Action OnLevelStart;

    [SerializeField] private int _maxPlayersToJoin = 2;

    private int _playersJoined;

    public int PlayersJoined { get => _playersJoined - 1; set => _playersJoined = value; }

    public void OnJoinPlayer()
    {
        _playersJoined++;
        if (_playersJoined == _maxPlayersToJoin)
            StartCoroutine(StartLevel());
    }

    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(3f);
        OnLevelStart?.Invoke();
    }
}