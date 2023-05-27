using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikdeBall : MonoBehaviour {

    public float rotationSpeed;

    private void Start() {
        transform.parent = null;
    }

    private void Update() {
        transform.position = Core.Instance.gameManager.player.position;
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }

}