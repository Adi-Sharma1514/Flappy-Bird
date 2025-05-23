using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject gameStart;
    public Player player;

    private void Awake(){
        Application.targetFrameRate = 60;

        Pause();
        gameOver.SetActive(false);
        gameStart.SetActive(true);
    }

    public void IncreaseScore(){
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver(){
        Debug.Log("Game Over");
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void Play(){
        score = 0;
        scoreText.text = score.ToString();

        gameStart.SetActive(false);
        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++){
            Destroy(pipes[i].gameObject);
        }
    }

    private void Pause(){
        Time.timeScale = 0f;
        player.enabled = false;
    }
}
