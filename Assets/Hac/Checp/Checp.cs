using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checp : MonoBehaviour
{
    public int checkpointIndex; // Индекс чекпоинта
    public ContrC controllerC; // Ссылка на объект ContrC
    public Material newMaterial; // Укажите новый материал, который будет установлен при активации триггера

    public void Activate()
    {
        // Ваши действия при активации чекпоинта (например, сохранение игры)
        Debug.Log($"Checkpoint {checkpointIndex} activated.");
    }

    private void OnTriggerEnter(Collider other)
    {
        controllerC.ActivateCheckpoint(checkpointIndex);
        Renderer objectRenderer = GetComponent<Renderer>(); // Получаем компонент Renderer текущего объекта

        if (objectRenderer != null && newMaterial != null)
        {
            objectRenderer.material = newMaterial; // Устанавливаем новый материал
        }
    }
    private void Start()
    {
        // Получаем компонент Transform чекпоинта
        Transform checkpointTransform = transform;

        // Получаем позицию чекпоинта
        Vector3 checkpointPosition = checkpointTransform.position;

        // Теперь у вас есть координаты чекпоинта в переменной checkpointPosition
        Debug.Log("Координаты чекпоинта: " + checkpointPosition);
    }
}

