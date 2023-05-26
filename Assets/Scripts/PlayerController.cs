using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isLookLeft;
    [SerializeField] private bool isWalk;
    [SerializeField] private float moveSpeed = 2.5f;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        Vector2 moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        isWalk = moveDirection.sqrMagnitude != 0;

        if (moveDirection.x > 0 && isLookLeft) {
            Flip();
        }

        else if (moveDirection.x < 0 && !isLookLeft) {
            Flip();
        }

        playerRb.velocity = moveDirection.normalized * moveSpeed;
        animator.SetBool("isWalk", isWalk);
    }

    private void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }
}
