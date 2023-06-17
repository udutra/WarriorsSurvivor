using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Vector2 moveDirection;
    private HeroData hero;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator animator;
    [SerializeField] private bool isWalk;
    [SerializeField] private bool isLookLeft;
    public PowerUpData moveSpeed;

    private void Start() {
        Core.Instance.gameManager.PlayerRegister(this.transform);
        playerRb = GetComponent<Rigidbody2D>();
        hero = Core.Instance.gameManager.selectedHero;
        GameObject myHero = Instantiate(hero.heroPrefab, this.transform);
        animator = myHero.GetComponent<Animator>();
        Instantiate(hero.startWeapon.prefab, this.transform);
    }

    private void Update() {
        moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        isWalk = moveDirection.sqrMagnitude != 0;

        if (moveDirection.x > 0 && isLookLeft) {
            Flip();
        }

        else if (moveDirection.x < 0 && !isLookLeft) {
            Flip();
        }

        playerRb.velocity = moveDirection.normalized * CalculateMoveSpeed();
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

    public Vector2 GetMoveDirection() {
        return moveDirection;
    }

    private float CalculateMoveSpeed() {
        float moveBase = hero.moveSpeed;
        float bonus = Core.Instance.upgradeManager.GetPowerUpBonus(moveSpeed);
        float newMoveSpeed = 0;
        switch (moveSpeed.bonusType) {

            case Unit.Sum: {
                    newMoveSpeed = moveBase + bonus;
                    break;
                }
            case Unit.Percentage: {
                    newMoveSpeed = moveBase + (moveBase * (bonus / 100));
                    break;
                }
            default: {
                    Debug.LogWarning("Erro switch no script WeaponAreaEffect, método: CalculateDamage()");
                    break;
                }

        }
        Debug.Log(newMoveSpeed);

        return newMoveSpeed;
    }
}