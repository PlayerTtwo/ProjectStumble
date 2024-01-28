using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : SceneSingleton<LevelManager>
{
    public event Action OnLevelStart;
    public event Action<int> OnPlayerJoined;
    public event Action OnLevelFinish;

    [SerializeField] private int _maxPlayersToJoin = 2;

    public int _playersJoined;

    private List<PlayerBallMovementController> _players = new List<PlayerBallMovementController>();

    public int PlayersJoined { get => _playersJoined - 1; set => _playersJoined = value; }

    public List<PlayerBallMovementController> Players
    {
        get => _players;
        set => _players = value;
    }

    public void OnJoinPlayer(PlayerBallMovementController player)
    {
        _playersJoined++;
        OnPlayerJoined?.Invoke(_playersJoined);
        _players.Add(player);
        if (_playersJoined == _maxPlayersToJoin)
            StartCoroutine(StartLevel());
    }

    private IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(.5f);
        OnLevelStart?.Invoke();
    }

        public PlayerBallMovementController GetOpponent(PlayerBallMovementController player)
    {
        for(int i = 0; i < _players.Count; i++)
        {
            if (player != _players[i])
             return _players[i];
        }
        return null;
    }

    public void FinishLevel(PlayerBallMovementController player)
    {
        OnLevelFinish?.Invoke();
        PlayerBallMovementController opponent = GetOpponent(player);
        player.GetComponentInChildren<UILevelFinish>().DisplayGameWin();
        opponent.GetComponentInChildren<UILevelFinish>().DisplayGameLose();
    }
}