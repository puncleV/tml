using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    [SerializeField] SceneLoader sceneLoader;

    List<Block> blocks;

    private void Start()
    {
        blocks = new List<Block>();
    }

    public void add(Block block)
    {
        blocks.Add(block);
    }

    public void delete (Block block)
    {
        blocks.Remove(block);

        if (blocks.Count == 0)
        {
            sceneLoader.loadNextScene();
        }
    }
}
