using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PowerupData", menuName = "ScriptableObjects/PowerupData", order = 1)]
public class PowerupData : ScriptableObject
{
    [SerializeField] private Sprite _iconSprite;
    [SerializeField] private PowerupType _powerUpType;

    public PowerupType PowerupType => _powerUpType;
    public Sprite IconSprite => _iconSprite;
}
