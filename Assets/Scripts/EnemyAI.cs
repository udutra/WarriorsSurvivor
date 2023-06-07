using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable {

    private Vector3 target;
    private bool isLookLeft;
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;
    private float currentHealth;
    private float knokBackTime;
    private int knokBackFactor = 1;
    public GameObject hitArea;
    public EnemyData enemyData;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
        currentHealth = enemyData.maxHeath;
    }

    private void Update() {
        _rigidbody.velocity = enemyData.moveSpeed * knokBackFactor * moveDirection.normalized;
    }

    private IEnumerator IETargetUpdate() {
        while (true) {
            yield return new WaitForSeconds(enemyData.targetUpdateDelay);
            target = Core.Instance.gameManager.player.position;
            moveDirection = target - transform.position;
        }
    }

    public void TakeDamage(float value, float knockback) {
        currentHealth -= value;
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
}