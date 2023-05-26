using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject projetilePrefab;
    public float delayAttack;
    public Transform slashPivot;
    private PlayerController player;

    private void Start() {
        player = GetComponentInParent<PlayerController>();
        StartCoroutine(nameof(IESwordSlash));
    }

    private IEnumerator IESwordSlash() {
        while (true) {
            yield return new WaitForSeconds(delayAttack);
            GameObject slash = Instantiate(projetilePrefab);
            Destroy(slash,0.5f);
            if (player.GetIsLookLeft()) {
                Flip(slash.transform);
            }
            slash.transform.position = slashPivot.position;
        }
    }

    private void Flip(Transform t) {
        t.localScale = new Vector3(t.localScale.x * -1, t.localScale.y, t.localScale.z);
    }
}