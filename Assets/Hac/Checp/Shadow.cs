using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public LineRenderer lineRenderer; // ������ �� ��������� LineRenderer
    public float speed = 1.0f;
    public GameObject follower; // ������ �� ������, ������� ����� ��������� �� ����

    private int currentPointIndex = 0;
    private Vector3[] pathPoints;

    void Start()
    {
        // ��������� ����� ����� � ������
        int numPoints = lineRenderer.positionCount;
        pathPoints = new Vector3[numPoints];
        lineRenderer.GetPositions(pathPoints);
    }

    void Update()
    {
        if (currentPointIndex < pathPoints.Length)
        {
            float step = speed * Time.deltaTime;
            follower.transform.position = Vector3.MoveTowards(follower.transform.position, pathPoints[currentPointIndex], step);

            if (Vector3.Distance(follower.transform.position, pathPoints[currentPointIndex]) < 0.01f)
            {
                currentPointIndex++;
            }
        }
    }
}
