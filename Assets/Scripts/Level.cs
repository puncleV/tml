using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] int blocksCount = 0;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    
    public void blockInitialized()
    {
        blocksCount++;
    }

    public void onBlockDestroied()
    {

        if(--blocksCount == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
