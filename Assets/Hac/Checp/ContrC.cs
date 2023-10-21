using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    private int sec = 0;
    private int min = 0;
    public int delta = 0;
    public List<Checp> checkpoints = new List<Checp>(); // Список чекпоинтов
    public int currentCheckpointIndex; // Индекс текущего чекпоинта

    void Start()
    {
        StartCoroutine(RaceTime());
    }
    // Метод для активации чекпоинта с указанным индексом
    public void ActivateCheckpoint(int index)
    {
        if (index >= 0 && index <= checkpoints.Count - 1)
        {
            currentCheckpointIndex = index;
            Debug.Log($"Активирован чекпоинт с индексом: {index}");
            delta = 1;
        }
        else
        {
            StopCoroutine(RaceTime());
            Debug.Log($" чекпоинт с индексом: {index}");
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
    // Метод Update, где выводим currentCheckpointIndex
    private void Update()
    {
        
    }
}
