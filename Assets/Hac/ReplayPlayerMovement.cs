using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplayPlayerMovement : MonoBehaviour
{
    public PlayerMovementHistory playerHistory;
    public float replaySpeed = 1.0f;
    private List<Vector3> path;
    private int currentIndex = 0;

    private void Start()
    {
        path = playerHistory.GetPlayerPath();
    }

    private void Update()
    {
        if (currentIndex < path.Count)
        {
            transform.position = path[currentIndex];
            currentIndex++;
        }
    }
}
