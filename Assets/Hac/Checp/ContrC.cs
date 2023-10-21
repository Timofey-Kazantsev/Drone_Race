using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    private int g_sec = 0;
    private int g_min = 0;
    public int delta = 0;
    public int prevCheckpointIndex;
    public List<Checp> checkpoints = new List<Checp>(); // ������ ����������
    public int currentCheckpointIndex; // ������ �������� ���������
    public List<int> timesGo = new List<int>();
    public Material checkpointMaterial;

    void Start()
    {
        StartCoroutine(RaceTime());
    }
    // ����� ��� ��������� ��������� � ��������� ��������
    public void ActivateCheckpoint(int index)
    {
        if (index >= 0 && index <= checkpoints.Count - 1)
        {
            currentCheckpointIndex = index;
            delta = 1;
            prevCheckpointIndex = index - 1;
            timesGo.Add(g_sec);
            Debug.Log(timesGo[currentCheckpointIndex]);
            // �������� ��������� Renderer � �������� ���������
            Renderer checkpointRenderer = checkpoints[index + 1].GetComponent<Renderer>();

            if (checkpointRenderer != null && checkpointMaterial != null)
            {
                // ������������� ����� �������� ��� ���������
                checkpointRenderer.material = checkpointMaterial;
            }
        }
        else
        {
            timesGo.Add(g_sec);
            for (int i = 1; i < timesGo.Count; i++)
            {
                int time_passed = timesGo[i];
                // ����� �� ������ ��������� �������� � ��������� ���������� ����������, ��������:
                Debug.Log("������� �������� �� ��������: " + time_passed);
            }
            StopCoroutine(RaceTime());
            delta = 0;
        }
    }

    IEnumerator RaceTime()
    {
        while (true)
        {
            if (g_sec == 59)
            {
                g_min++;
                g_sec = -1;
                Debug.Log(g_sec);
                Debug.Log(g_min);
            }
            g_sec += delta;
            Debug.Log(g_sec);
            yield return new WaitForSeconds(1);

        }
    }
    // ����� Update, ��� ������� currentCheckpointIndex
    private void Update()
    {

    }
}
