using UnityEngine;

[CreateAssetMenu(fileName = "New Hero", menuName = "Scriptable/Hero", order = 0)]
public class HeroData : ScriptableObject {
    public GameObject heroPrefab;
    public float moveSpeed;
    public WeaponData startWeapon;
}