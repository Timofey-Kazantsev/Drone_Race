using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionIndicator : MonoBehaviour
{
    public Transform target; // Цель (например, персонаж)
    public GameObject indicatorPrefab; // Префаб указателей (стрелочек)
    public Transform staticIndicator; // Публичная переменная для статической стрелочки

    private void Start()
    {
        // Создаем статическую стрелочку
        staticIndicator = Instantiate(indicatorPrefab, transform.position, Quaternion.identity).transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // Определяем вектор направления от объекта к цели
            Vector3 direction = target.position - transform.position;

            // Рассчитываем угол между текущим направлением объекта и целью
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Вращаем статическую стрелочку в соответствии с углом
            staticIndicator.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
