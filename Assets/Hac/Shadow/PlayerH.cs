using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerH : MonoBehaviour
{
    // —писок дл€ хранени€ истории позиций игрока
    private List<Vector3> playerPath = new List<Vector3>();

    // ѕеременна€ дл€ интервала записи позиции
    public float recordInterval = 0.1f;
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= recordInterval)
        {
            // «апись текущей позиции игрока в список
            playerPath.Add(transform.position);
            timer = 0f;
        }
    }

    // ћетод дл€ получени€ истории движени€ игрока
    public List<Vector3> GetPlayerPath()
    {
        return playerPath;
    }
}
