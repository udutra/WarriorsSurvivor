using System;
using UnityEngine;

[Serializable]
public struct PowerUpBonus
{
    [Range(1, 10)] public int maxLevel;
    public Unit unit;
    public float value;
    [TextArea(3,3)] public string description;
}