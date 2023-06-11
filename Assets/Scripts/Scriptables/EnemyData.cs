using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy", order = 2)]
public class EnemyData : ScriptableObject {

    public string enemyName;
    public Sprite enemyPortrait;
    public GameObject prefab;
    public float targetUpdateDelay;
    public float moveSpeed;
    public float maxHeath;
    public float damage;
    public float timeBetweenAttacks;
    public int xp;
    public float knockbackWeakness;
}