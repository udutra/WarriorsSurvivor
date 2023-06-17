using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    public float GetPowerUpBonus(PowerUpData powerUp) {
        float bonus = 0;

        //Pegar o bonus da Loja
        if (powerUp.powerUpLevel > 0) {
            bonus = powerUp.powerUpLevel * powerUp.bonus.value;
        }

        //Pegar o bonus de upgrades da Gameplay


        //Pegar o bonus inerente ao Herois


        return bonus;
    }
}