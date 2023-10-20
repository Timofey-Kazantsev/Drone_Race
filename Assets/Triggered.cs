using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // ���, ������� ���������� ��� ����� � �������
        // ������: ������� ���������, ����� ���-�� ������ � ����
        Debug.Log(other.name + " entered the trigger zone.");
    }

    private void OnTriggerExit(Collider other)
    {
        // ���, ������� ���������� ��� ������ �� ��������
        // ������: ������� ���������, ����� ���-�� ������� �� ����
        Debug.Log(other.name + " exited the trigger zone.");
    }
}