using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevelFinish : MonoBehaviour
{
    [SerializeField] private GameObject _gameWin;
    [SerializeField] private GameObject _gameLose;

    public void DisplayGameWin()
    {
        _gameWin.SetActive(true);
    }

    public void DisplayGameLose()
    {
        _gameLose.SetActive(true);
    }
}
