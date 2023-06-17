using UnityEngine;

public class Core : MonoBehaviour {
    
    public static Core Instance;
    public GameManager gameManager;
    public UpgradeManager upgradeManager;
    [HideInInspector] public WaveManager waveManager;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(Instance);
            return;
        }
        Instance = this;
    }
}