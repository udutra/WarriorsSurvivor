using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp Data", menuName = "Scriptable/PowerUpData", order = 3)]
public class PowerUpData : ScriptableObject
{
    public string powerUpName;
    public int powerUpLevel;
    public Sprite powerUpIcon;
    public int initialCost;
    public PowerUpBonus bonus;
    public PowerUpBonus passive;
}