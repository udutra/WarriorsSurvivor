using System.Collections.Generic;
using UnityEngine;


public class UpgradeManager : MonoBehaviour {

    public PowerUpData powerUpTemp;
    public int level;
    public Dictionary<PowerUpData, int> passiveBonus = new();

    private void Start() {
        passiveBonus.Add(powerUpTemp, level);
    }

    public float GetPowerUpBonus(PowerUpData powerUp) {
        float bonus = 0;

        //Pegar o bonus da Loja
        if (powerUp.powerUpLevel > 0) {
            bonus = powerUp.powerUpLevel * powerUp.bonus.value;
        }

        //Pegar o bonus de upgrades da Gameplay
        if(passiveBonus.ContainsKey(powerUp)) {
            bonus += powerUp.passive.value * passiveBonus[powerUp];
        }

        //Pegar o bonus inerente ao Herois
        if (Core.Instance.gameManager.selectedHero.GetPowerUpBonus(powerUp) > 0) {
            bonus += Core.Instance.gameManager.selectedHero.GetPowerUpBonus(powerUp);
        }

        return bonus;
    }
}