using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checp : MonoBehaviour
{
    public int checkpointIndex; // ������ ���������
    ContrC controllerC = new ContrC();
    public void Activate()
    {
        // ���� �������� ��� ��������� ��������� (��������, ���������� ����)
        Debug.Log($"Checkpoint {checkpointIndex} activated.");
    }

    private void OnTriggerEnter(Collider other)
    {
        controllerC.ActivateCheckpoint(checkpointIndex);
        Debug.Log("asd");
    }
}
