using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [Range(0.01f, 10f)][SerializeField] float gameSpeedScale = 1;
    [Range(0.01f, 1f)] [SerializeField] float speedChangeStep = 0.01f;

    private void Start()
    {
        Time.timeScale = gameSpeedScale;
    }

    public void onBlockDestroied()
    {
        increaseSpeed();
    }

    private void increaseSpeed()
    {
        gameSpeedScale += speedChangeStep;
        Time.timeScale = gameSpeedScale;
    }
}
