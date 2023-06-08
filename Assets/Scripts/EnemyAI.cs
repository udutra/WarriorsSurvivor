using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour, IDamageable {

    private Vector3 target;
    private Rigidbody2D _rigidbody;
    private Vector2 moveDirection;
    private float currentHealth;
    private float knokBackTime;
    private float knokBackFactor = 1f;
    public GameObject hitArea;
    public EnemyData enemyData;
    public bool isLookLeft;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(nameof(IETargetUpdate));
        currentHealth = enemyData.maxHeath;
    }

    private void Update() {

        if (knokBackTime > 0) {
            knokBackFactor = enemyData.knockbackWeakness;
            knokBackTime -= Time.deltaTime;
        }
        else {
            knokBackFactor = 1;
        }

        if (moveDirection.x > 0 && isLookLeft) {
            Flip();
        }

        else if (moveDirection.x < 0 && !isLookLeft) {
            Flip();
        }

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

        knokBackTime = knockback;
        if (currentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }

    private void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}