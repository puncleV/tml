using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [Range(0.01f, 10f)][SerializeField] float gameSpeedScale = 1;
    [Range(0.01f, 1f)] [SerializeField] float speedChangeStep = 0.01f;

    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] bool autoplay = false;

    private void Awake()
    {
        int instancesCount = FindObjectsOfType<GameState>().Length;
        if(instancesCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = score.ToString();
        Time.timeScale = gameSpeedScale;
    }
       
    public void addToScore (int points)
    {
        score += points;
        scoreText.text = score.ToString();
    }

    public void increaseSpeed()
    {
        gameSpeedScale += speedChangeStep;
        Time.timeScale = gameSpeedScale;
    }

    public void reset()
    {
        Destroy(gameObject);
    }

    public bool isAutoPlay()
    {
        return autoplay;
    }
}
