using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] private float currentHealth;

    private void Start() {
        currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
    }

    public void SetHealth(float value, bool recovery = false) {
        if (!recovery) { 
            currentHealth -= value;
            if (currentHealth <= 0) {
                print("Você morreu!");
            }
        }
        else {
            currentHealth += value;
            if (currentHealth > Core.Instance.gameManager.selectedHero.maxHealth) {
                currentHealth = Core.Instance.gameManager.selectedHero.maxHealth;
            }
        }
    }
}