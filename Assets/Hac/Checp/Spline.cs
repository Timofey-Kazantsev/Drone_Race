using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    // �������� ��������� ���� ��� ���������� LineRenderer
    public LineRenderer lineRenderer;

    public GameObject[] objectsToPlace;

    // �������� ������ ��� �������� ����������
    public Transform[] checkpoints;

    private void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("�� ������ ��������� LineRenderer. ����������, ���������� ��� � ����� �������.");
            return;
        }

        if (checkpoints.Length < 2)
        {
            Debug.LogError("����� ������� �����, ����� ������� ��� ������� ��� ���������.");
            return;
        }

        // ������������� ���������� ����� � LineRenderer ������ ���������� ����������
        lineRenderer.positionCount = checkpoints.Length;

        // ������ ����� ����� ��� ������� ����������
        for (int i = 0; i < checkpoints.Length; i++)
        {
            lineRenderer.SetPosition(i, checkpoints[i].position);

            // ���������, ���� �� ������� ��� ����������
            if (i < objectsToPlace.Length)
            {
                // ���� ���� �������, ��������� �� �� ����� � ������������ � �������� ���������
                GameObject objectToPlace = Instantiate(objectsToPlace[i], checkpoints[i].position, Quaternion.identity);
            }
        }
    }
}
