using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;

    [SerializeField] int blocksCount = 0;
    [SerializeField] int score = 0;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void blockInitialized()
    {
        blocksCount++;
    }

    public void onBlockDestroied(Block block)
    {
        score += block.getScore();

        if(--blocksCount == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
