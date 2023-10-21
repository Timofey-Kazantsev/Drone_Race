using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    public int delta = 0;
    public List<Checp> checkpoints = new List<Checp>(); // ������ ����������
    public int currentCheckpointIndex; // ������ �������� ���������

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
            Debug.Log($"����������� �������� � ��������: {index}");
            delta = 1;
        }
        else
        {
            StopCoroutine(RaceTime());
            Debug.Log($" �������� � ��������: {index}");
            delta = 0;
        }
    }

    IEnumerator RaceTime() 
    {
        while (true)
        {
            if (sec == 59)
            {
                min++;
                sec = -1;
                Debug.Log(sec);
                Debug.Log(min);
            }
            sec += delta;
            Debug.Log(sec);
            yield return new WaitForSeconds(1);
            
        }
    }
    // ����� Update, ��� ������� currentCheckpointIndex
    private void Update()
    {
        
    }
}
