using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    public int g_sec = 0;
    public int g_min = 0;
    public int delta = 0;
    public int prevCheckpointIndex;
    public List<Checp> checkpoints = new List<Checp>(); // Список чекпоинтов
    public int currentCheckpointIndex; // Индекс текущего чекпоинта
    public List<int> timesGo = new List<int>();
    public Material checkpointMaterial;
    public string strD;
    public List<int> differences;
    public string allTime;

    void Start()
    {
        StartCoroutine(RaceTime());
    }
    // Метод для активации чекпоинта с указанным индексом
    public void ActivateCheckpoint(int index)
    {
        if (index >= 0 && index <= checkpoints.Count - 2)
        {
            currentCheckpointIndex = index;
            delta = 1;
            prevCheckpointIndex = index - 1;
            timesGo.Add(g_sec);
            Renderer checkpointRenderer = null;
            // Получаем компонент Renderer у текущего чекпоинта
            if (index != checkpoints.Count - 1)
            {
                checkpointRenderer = checkpoints[index + 1].GetComponent<Renderer>(); // Убрано лишнее объявление Renderer
            }

            if (checkpointRenderer != null && checkpointMaterial != null)
            {
                // Устанавливаем новый материал для чекпоинта
                checkpointRenderer.material = checkpointMaterial;
            }
        }
        else
        {
            timesGo.Add(g_sec);
            for (int i = 1; i < timesGo.Count - 1; i++)
            {
                int time_passed = timesGo[i];
                // Здесь вы можете выполнять действия с индексами пройденных чекпоинтов, например:
                Debug.Log("Пройден чекпоинт со временем: " + time_passed);
            }
            StopCoroutine(RaceTime());
            delta = 0;
            ///Times_pass(timesGo);
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
            yield return new WaitForSeconds(1);

        }
    }
    private void Update()
    {

    }
  /*  private void Times_pass(List<int> timesGo)
    {
        List<int> differences = new List<int>();
        for (int i = 0; i < timesGo.Count; i++)
        {
            if(i+1 < timesGo.Count)
            {
                int diff = timesGo[i + 1] - timesGo[i];
                differences.Add(diff); 
            }
            
        }
        for (int i = 0; i < differences.Count - 1; i++)
        {
            string strD = string.Format("{0} участок - {1} секунд\n", i, differences[i]);
            Debug.Log(strD);
        }
        string allTime = string.Format("Общее время - {0} минут {1} секунд", g_min, g_sec);
        Debug.Log(allTime);
    }*/
}
