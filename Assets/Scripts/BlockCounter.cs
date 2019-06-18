using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    List<Block> blocks;

    private void add(Block block)
    {
        blocks.Add(block);
    }
    
    private void delete (Block block)
    {
        blocks.Remove(block);

        if (blocks.Count == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
