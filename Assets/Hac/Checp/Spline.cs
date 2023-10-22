using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spline : MonoBehaviour
{
    // Создайте публичное поле для компонента LineRenderer
    public LineRenderer lineRenderer;

    public GameObject[] objectsToPlace;

    // Создайте массив для хранения чекпоинтов
    public Transform[] checkpoints;

    private void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("Не указан компонент LineRenderer. Пожалуйста, прикрепите его к этому объекту.");
            return;
        }

        if (checkpoints.Length < 2)
        {
            Debug.LogError("Чтобы создать линию, нужно указать как минимум два чекпоинта.");
            return;
        }

        // Устанавливаем количество точек в LineRenderer равным количеству чекпоинтов
        lineRenderer.positionCount = checkpoints.Length;

        // Задаем точки линии как позиции чекпоинтов
        for (int i = 0; i < checkpoints.Length; i++)
        {
            lineRenderer.SetPosition(i, checkpoints[i].position);

            // Проверяем, есть ли объекты для размещения
            if (i < objectsToPlace.Length)
            {
                // Если есть объекты, размещаем их на линии в соответствии с позицией чекпоинта
                GameObject objectToPlace = Instantiate(objectsToPlace[i], checkpoints[i].position, Quaternion.identity);
            }
        }
    }
}
