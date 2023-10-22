using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public VectorSave characterPathRecorder; // Ссылка на скрипт CharacterPathRecorder
    private List<Vector3> pathPoints; // Список точек пути
    private int currentPointIndex = 0; // Текущий индекс точки пути

    private void Start()
    {
        pathPoints = characterPathRecorder.GetPathPoints();
        if (pathPoints.Count > 0)
        {
            MoveToNextPoint();
        }
    }

    private void Update()
    {
        if (currentPointIndex < pathPoints.Count)
        {
            Vector3 targetPosition = pathPoints[currentPointIndex];
            float distance = Vector3.Distance(transform.position, targetPosition);

            if (distance < 0.1f)
            {
                currentPointIndex++;
                if (currentPointIndex < pathPoints.Count)
                {
                    MoveToNextPoint();
                }
            }
        }
    }

    private void MoveToNextPoint()
    {
        Vector3 targetPosition = pathPoints[currentPointIndex];
        transform.position = targetPosition;
    }
}
