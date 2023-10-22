using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSave : MonoBehaviour
{
    private List<Vector3> pathPoints = new List<Vector3>(); // ������ ����� ����

    // ���������� ������� ������� ��������� � ������ ����� ����
    private void RecordPath()
    {
        pathPoints.Add(transform.position);
    }

    // ���������� ������ ����� ����
    public List<Vector3> GetPathPoints()
    {
        return pathPoints;
    }
}
