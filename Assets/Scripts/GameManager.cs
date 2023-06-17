using UnityEngine;

public class GameManager : MonoBehaviour {
    
    public HeroData selectedHero;
    [HideInInspector] public Transform player;
    public PlayerHealth playerHealth;
    public float xp;
    public float coins;

    public void PlayerRegister(Transform playerT) {
        this.player = playerT;
        playerHealth = player.gameObject.GetComponent<PlayerHealth>();
    }

    public void GetItemCollectible(ItemCollectible item) {
        switch (item.itemType) {
            case CollectibleType.XP: {
                    GetXp(item.value);
                    break;
                }
            case CollectibleType.Coin: {
                    coins += item.value;
                    break;
                }
            case CollectibleType.Recovery: {
                    playerHealth.SetHealth(item.value, true);
                    break;
                }
            default: {
                    Debug.LogWarning("Erro switch no script GameManager, método: GetItemCollectible()");
                    break;
                }
        }
    }

    private void GetXp(float amount) {
        xp += amount;
    }
}