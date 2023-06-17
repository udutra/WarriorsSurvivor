using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    public Transform[] spawnPoints;
    public int idWave;
    public WaveController[] waves;
    public int maxEnimiesInScene;
    private List<EnemyData> enemiesInScene = new();
    
    private void Start() {
        Core.Instance.waveManager = this;
        StartCoroutine(nameof(Spawn));
    }

    private void EnemyRegister(EnemyData data) {
        enemiesInScene.Add(data);
    }

    public void EnemyUnregister(EnemyData data) {
        enemiesInScene.Remove(data);
    }

    private IEnumerator Spawn() {
        WaveController wave = waves[idWave];
        yield return new WaitForSeconds(2f);

        while (true) {

            yield return new WaitUntil(() => enemiesInScene.Count < maxEnimiesInScene);

            int idMob = Random.Range(0, wave.enemies.Length);
            EnemyData enemyData = wave.enemies[idMob].enemy;
            
            GameObject mob = Instantiate(enemyData.prefab);
            EnemyRegister(enemyData);
            
            int idSpawnPoint = Random.Range(0, spawnPoints.Length);
            mob.transform.position = spawnPoints[idSpawnPoint].position;
            yield return new WaitForSeconds(wave.intervalBetweenEnemies);
        }
    }
}
