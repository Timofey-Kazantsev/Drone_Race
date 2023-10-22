using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerH : MonoBehaviour
{
    // ������ ��� �������� ������� ������� ������
    private List<Vector3> playerPath = new List<Vector3>();

    // ���������� ��� ��������� ������ �������
    public float recordInterval = 0.1f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            // ������ ������� ������� ������ � ������
            playerPath.Add(transform.position);
            timer = 0f;
        }
    }

    // ����� ��� ��������� ������� �������� ������
    public List<Vector3> GetPlayerPath()
    {
        return playerPath;
    }
}
