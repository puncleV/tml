using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    BlockCounter blockCounter;
    private void Start()
    {
        blockCounter = new BlockCounter();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void blockInitialized()
    {
        blockCounter.add();
    }

    public void onBlockDestroied()
    {
        blockCounter.delete();

        if(blockCounter.getCount() == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
