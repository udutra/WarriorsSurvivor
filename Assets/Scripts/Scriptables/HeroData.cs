using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Scriptable/Hero", order = 0)]
public class HeroData : ScriptableObject {
    public GameObject heroPrefab;
    public float moveSpeed;
    public float maxHealth;
    public WeaponData startWeapon;

    public HeroPowerUpBonus[] abilities; 

    public float GetPowerUpBonus(PowerUpData powerUp) {
        float bonus = 0;

        foreach (var abilitie in abilities) {
            if (abilitie.powerUp == powerUp) {
                bonus = abilitie.value;
            }
        }

        return bonus;
    }
}