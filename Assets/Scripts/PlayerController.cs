using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private HeroData hero;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isWalk;
    [SerializeField] private bool isLookLeft;

    private void Start() {
        playerRb = GetComponent<Rigidbody2D>();
        hero = Core.Instance.gameManager.selectedHero;
        GameObject myHero = Instantiate(hero.heroPrefab, this.transform);
        animator = myHero.GetComponent<Animator>();
        Instantiate(hero.startWeapon.prefab, this.transform);
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

        playerRb.velocity = moveDirection.normalized * hero.moveSpeed;
        animator.SetBool("isWalk", isWalk);
    }

    private void Flip() {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
    }

    public bool GetIsLookLeft() {
        return isLookLeft;
    }
}