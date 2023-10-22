using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSave : MonoBehaviour
{
    private List<Vector3> pathPoints = new List<Vector3>(); // Список точек пути

    // Записывает текущую позицию персонажа в список точек пути
    private void RecordPath()
    {
        pathPoints.Add(transform.position);
    }

    // Возвращает список точек пути
    public List<Vector3> GetPathPoints()
    {
        return pathPoints;
    }
}
