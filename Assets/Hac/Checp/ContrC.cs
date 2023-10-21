using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrC : MonoBehaviour
{
    public List<Checp> checkpoints = new List<Checp>(); // Список чекпоинтов
    private int currentCheckpointIndex = 0; // Индекс текущего чекпоинта

    // Метод для активации чекпоинта с указанным индексом
    public void ActivateCheckpoint(int index)
    {
        if (index >= 0 && index <= checkpoints.Count)
        {
            Debug.Log("Гонка еще не окончена");
        }
        else
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
