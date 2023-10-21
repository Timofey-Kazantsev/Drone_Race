using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    private int g_sec = 0;
    private int g_min = 0;
    public int delta = 0;
    public int prevCheckpointIndex;
    public List<Checp> checkpoints = new List<Checp>(); // Список чекпоинтов
    public int currentCheckpointIndex; // Индекс текущего чекпоинта
    public List<int> timesGo = new List<int>();
    public Material checkpointMaterial;

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
            delta = 1;
            prevCheckpointIndex = index - 1;
            timesGo.Add(g_sec);
            Debug.Log(timesGo[currentCheckpointIndex]);
            // Получаем компонент Renderer у текущего чекпоинта
            Renderer checkpointRenderer = checkpoints[index + 1].GetComponent<Renderer>();

            if (checkpointRenderer != null && checkpointMaterial != null)
            {
                // Устанавливаем новый материал для чекпоинта
                checkpointRenderer.material = checkpointMaterial;
            }
        }
        else
        {
            timesGo.Add(g_sec);
            for (int i = 1; i < timesGo.Count; i++)
            {
                int time_passed = timesGo[i];
                // Здесь вы можете выполнять действия с индексами пройденных чекпоинтов, например:
                Debug.Log("Пройден чекпоинт со временем: " + time_passed);
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
    // Метод Update, где выводим currentCheckpointIndex
    private void Update()
    {

    }
}
