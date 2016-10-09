using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazerdCount;
    public float wait;

    public Text scoreText;
    public Text gameOverText;
    public Text restartText;

    private bool gameOver;
    private bool restart;
    private int score;

    void Start() {
        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        score = 0;
        ScoreUpdate();
        StartCoroutine(SpawnWaves());
    }

    void Update() {
        if(restart) {
            if(Input.GetKeyDown(KeyCode.R)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(1f);
        while(true) {
            for(int i = 0; i < hazerdCount; i++) {
                Vector3 spawnPos = new Vector3(Random.Range(-spawnValues.x,spawnValues.x),spawnValues.y,spawnValues.z);
                Quaternion spawnQua = Quaternion.identity;
                Instantiate(hazard,spawnPos,spawnQua);
                yield return new WaitForSeconds(wait);
            }
            if(gameOver) {
                restartText.text = "Press 'R' for restart.";
                restart = true;
                break;
            }
        }
    }

    public void GameOver() {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }

    public void AddScore(int newScoreValue) {
        score += newScoreValue;
        ScoreUpdate();
    }

    void ScoreUpdate() {
        scoreText.text = "Score: " + score.ToString();
    }
}
