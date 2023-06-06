using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

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
    }

    private void Update() {
        _rigidbody.velocity = moveDirection.normalized * enemyData.moveSpeed * knokBackFactor;
    }

    private IEnumerator IETargetUpdate() {
        while (true) {
            yield return new WaitForSeconds(enemyData.targetUpdateDelay);
            target = Core.Instance.gameManager.player.position;
            moveDirection = target - transform.position;
        }
    }
}