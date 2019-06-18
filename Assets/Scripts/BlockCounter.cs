using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    int blocksCount;

    public void add()
    {
        blocksCount++;
    }

    public void delete ()
    {
        blocksCount--;

        if (blocksCount == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
