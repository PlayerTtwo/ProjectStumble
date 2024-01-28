using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRandomizer : MonoBehaviour
{
    [SerializeField] GameObject _player1tospawn;
    [SerializeField] GameObject _player2tospawn;

    private void Start()
    {
        _player2tospawn.SetActive(false);
        _player1tospawn.SetActive(false);
        PlayerbBallSpawned();
    }
    
    private void PlayerbBallSpawned()
     {
        if (LevelManager.Instance._playersJoined == 1)
        {
            _player1tospawn.SetActive(true);
            _player2tospawn.SetActive(false);

        }
        else if (LevelManager.Instance._playersJoined == 2)
        {
            _player2tospawn.SetActive(true);
            _player1tospawn.SetActive(false);

        }
    }

}
