using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checp : MonoBehaviour
{
    public int checkpointIndex; // Индекс чекпоинта
    public ContrC controllerC; // Ссылка на объект ContrC

    public void Activate()
    {
        // Ваши действия при активации чекпоинта (например, сохранение игры)
        Debug.Log($"Checkpoint {checkpointIndex} activated.");
    }

    private void OnTriggerEnter(Collider other)
    {
        controllerC.ActivateCheckpoint(checkpointIndex);
        Debug.Log("asd");
    }
}

