using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    private List<EnemyData> enemiesInScene = new();
    private Dictionary<EnemyData, int> enemyTypeAmount = new();
    public Transform[] spawnPoints;
    public int idWave;
    public WaveController[] waves;
    public int maxEnimiesInScene;
    
    private void Start() {
        Core.Instance.waveManager = this;
        StartCoroutine(nameof(Spawn));
    }

    private void EnemyRegister(EnemyData data) {
        enemiesInScene.Add(data);
        if (enemyTypeAmount.ContainsKey(data)) {
            enemyTypeAmount[data] += 1;
        }
        else {
            enemyTypeAmount.Add(data, 1);
        }
    }

    public void EnemyUnregister(EnemyData data) {
        enemiesInScene.Remove(data);
        if (enemyTypeAmount.ContainsKey(data)) {
            enemyTypeAmount[data] -= 1;
            if (enemyTypeAmount[data] <= 0) { 
                enemyTypeAmount.Remove(data);
            }
        }
    }

    private IEnumerator Spawn() {
        WaveController wave = waves[idWave];
        yield return new WaitForSeconds(2f);

        while (true) {

            yield return new WaitUntil(() => enemiesInScene.Count < maxEnimiesInScene);

            int idMob = Random.Range(0, wave.enemies.Length);
            EnemyData enemyData = wave.enemies[idMob].enemy;

            if (enemyTypeAmount.ContainsKey(enemyData)) {
                if (enemyTypeAmount[enemyData] < wave.enemies[idMob].amount) {
                    NewMob(enemyData);
                }
            }
            else {
                NewMob(enemyData);
            }
                        
            yield return new WaitForSeconds(wave.intervalBetweenEnemies);
        }
    }

    private void NewMob(EnemyData data) {
        EnemyRegister(data);
        GameObject mob = Instantiate(data.prefab);
        int idSpawnPoint = Random.Range(0, spawnPoints.Length);
        mob.transform.position = spawnPoints[idSpawnPoint].position;
    }
}
