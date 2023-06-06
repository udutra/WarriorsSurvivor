using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable/Enemy", order = 2)]
public class EnemyData : ScriptableObject {

    public float targetUpdateDelay;
    public float moveSpeed;


}