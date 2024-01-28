using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandbyCamera : MonoBehaviour
{
    private void Start()
    {
        LevelManager.Instance.OnPlayerJoined += LevelManager_OnJoinPlayer;
    }

    private void OnDisable()
    {
        LevelManager.Instance.OnPlayerJoined -= LevelManager_OnJoinPlayer;
    }

    private void LevelManager_OnJoinPlayer(int playerIndex)
    {
        gameObject.SetActive(false);
    }
}
