using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Код, который выполнится при входе в триггер
        // Пример: выводим сообщение, когда что-то входит в зону
        Debug.Log(other.name + " entered the trigger zone.");
    }

    private void OnTriggerExit(Collider other)
    {
        // Код, который выполнится при выходе из триггера
        // Пример: выводим сообщение, когда что-то выходит из зоны
        Debug.Log(other.name + " exited the trigger zone.");
    }
}