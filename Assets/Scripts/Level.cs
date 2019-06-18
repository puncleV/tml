using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    GameState gameState;

    [SerializeField] int blocksCount = 0;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameState = FindObjectOfType<GameState>();
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

    }
}
