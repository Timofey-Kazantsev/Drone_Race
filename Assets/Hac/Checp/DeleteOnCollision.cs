using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // ���������, ����������� �� �� � ������� (�����������, ��� ����� ����� ��� "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // ������� ������� ������
            Destroy(gameObject);
        }
    }
}
