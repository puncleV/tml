using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    GameState gameState;

    [SerializeField] int blocksCount = 0;
    [SerializeField] Text scoreText;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameState = FindObjectOfType<GameState>();

        scoreText.text = gameState.getScore().ToString();
    }
    
    public void blockInitialized()
    {
        blocksCount++;
    }

    public void onBlockDestroied(Block block)
    {
        changeScore(block.getPoints());
        gameState.increaseSpeed();
    
        if (--blocksCount == 0)
        {
            sceneLoader.loadNextScene();
        }
    }

    private void changeScore(int points)
    {
        gameState.addToScore(points);

        scoreText.text = gameState.getScore().ToString();
    }
}
