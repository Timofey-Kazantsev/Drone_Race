using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform target; // ���� (��������, ��������)
    public GameObject indicatorPrefab; // ������ ���������� (���������)
    public Transform staticIndicator; // ��������� ���������� ��� ����������� ���������

    private void Start()
    {
        // ������� ����������� ���������
        staticIndicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity).transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // ���������� ������ ����������� �� ������� � ����
            Vector3 direction = target.position - transform.position;

            // ������������ ���� ����� ������� ������������ ������� � �����
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // ������� ����������� ��������� � ������������ � �����
            staticIndicator.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
