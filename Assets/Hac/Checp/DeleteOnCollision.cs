using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулись ли мы с игроком (предположим, что игрок имеет тег "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Удаляем текущий объект
            Destroy(gameObject);
        }
    }
}
