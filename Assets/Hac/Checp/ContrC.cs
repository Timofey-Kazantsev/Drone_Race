using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    public List<Checp> checkpoints = new List<Checp>(); // ������ ����������
    private int currentCheckpointIndex = 0; // ������ �������� ���������

    // ����� ��� ��������� ��������� � ��������� ��������
    public void ActivateCheckpoint(int index)
    {
        if (index >= 0 && index <= checkpoints.Count)
        {
            Debug.Log("����� ��� �� ��������");
        }
        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
