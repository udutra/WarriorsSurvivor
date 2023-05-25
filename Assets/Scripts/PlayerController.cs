using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D playerRb;
    public float moveSpeed = 2.5f;

    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        Vector2 moveDirection = new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerRb.velocity = moveDirection.normalized * moveSpeed; ;
    }
}
