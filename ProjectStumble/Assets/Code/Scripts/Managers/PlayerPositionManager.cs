using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : SceneSingleton<PlayerPositionManager>
{
    private int _currPlayerIndex;

    [SerializeField] private Transform _player1Position;
    [SerializeField] private Transform _player2Position;


    public void UpdatePlayerPosition(Transform player)
    {
        _currPlayerIndex++;
        Rigidbody rigidbody = player.GetComponent<Rigidbody>();
        if (_currPlayerIndex == 1)
        {
            player.transform.position = _player1Position.position;
        } 
        else if (_currPlayerIndex == 2)
        {
            player.transform.position = _player2Position.position;

        }

        StartCoroutine(ApplyExtrapolation(rigidbody));
    }

    private IEnumerator ApplyExtrapolation(Rigidbody rigidbody)
    {
        yield return new WaitForSeconds(1f);
        rigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
    }
}
