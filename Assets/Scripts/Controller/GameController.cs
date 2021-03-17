using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject bladeObject = null, spawnerObject = null, fruitMissedCollider = null;
    public Text scoreText, highScoreText;
    [SerializeField] private Text[] fruitsLifeIndicator = null;
    private int fruitLifeCounter;
    private SoundController soundController;

    private int score = 0;

    void Awake(){
        highScoreText.text = "Best: " + GetHighScore().ToString();
        fruitLifeCounter = 0;
        soundController = FindObjectOfType<SoundController>();
    }

    void FixedUpdate(){
        if(this.fruitLifeCounter == 3){
            StartCoroutine(EndGame());
        }
    }
    
    public void AddScore(int points){
        score += points;
        scoreText.text = "Hits: " + score.ToString(); 
        SetHighScore();
    }

    void SetHighScore(){
        if(score > GetHighScore()){
            PlayerPrefs.SetInt("PlayerHighScore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    int GetHighScore(){
        return PlayerPrefs.GetInt("PlayerHighScore");
    }

    public IEnumerator EndGame(){
        spawnerObject.SetActive(false);
        bladeObject.SetActive(false);
        fruitMissedCollider.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene ("GameOver");
    }

    public void RestartGame(){
        SceneManager.LoadScene("MainGame");
    }

    public void FruitMissed(){
        if(this.fruitLifeCounter < 3){
            soundController.fruitSFXController.PlayOneShot(soundController.fruitMissed);
            fruitsLifeIndicator[this.fruitLifeCounter].color = new Color(212f, 0f, 0f);
            this.fruitLifeCounter++;
        }
    }
}
