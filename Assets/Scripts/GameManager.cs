using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public HeroData selectedHero;
    [HideInInspector] public Transform player;
    public PlayerHealth playerHealth;

    public void PlayerRegister(Transform playerT) {
        this.player = playerT;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }
}