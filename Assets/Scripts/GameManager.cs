using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public bool isGameAcitve;
    private int score;
    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameAcitve)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameAcitve = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame(int difficulty)
    {
        isGameAcitve = true;
        score = 0;

        spawnRate /= difficulty;
        StartCoroutine(SpawnTarget());
        UpdateScore(score);

        titleScreen.gameObject.SetActive(false);
    }
}
