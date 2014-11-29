using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText scoreText;
    public GameObject hazard;
    public Vector3 spawnValues;

    private bool gameOver;
    private bool restart;
    private int score;
    public int hazardCount;
    public float startWait;
    public float spawnWait;
    public float waveWait;

    // Use this for initialization
    void Start()
    {
        score = 0;
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";

        StartCoroutine(SpawnWaves());
        UpdateScore();
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
}
