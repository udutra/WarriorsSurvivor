using UnityEngine;

public class MobHitArea:MonoBehaviour {

    public EnemyData data;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Player")) { 
            Core.Instance.gameManager.playerHealth.SetHealth(data.damage);
        }
    }
}