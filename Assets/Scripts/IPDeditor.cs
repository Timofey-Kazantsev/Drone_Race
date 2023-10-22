using System;
using System.Collections;
using System.Collections.Generic;
using Vrs.Internal;
using UnityEngine;

public class IPDeditor : MonoBehaviour
{
    // Start is called before the first frame update

    private TextMesh ipdText;
    private TextMesh timeText;
    private float ipd = 64;
    public ContrC contrC;

    public void incIPD()
    {
        if (ipd+1f > 70) return;
        ipd += 1f;
        applyIPD();
    }

    public void decIPD()
    {
        if (ipd-1f <= 50) return;
        ipd -= 1f;
        applyIPD();
    }

    private void applyIPD()
    {
        PlayerPrefs.SetFloat("ipd", ipd);
        ipdText.text = String.Format("Межзрачковое расстояние: {0} мм", ipd);
        var dist = ipd / 1000.0f;
        VrsViewer.Instance.SetIpd(dist);
    }

    void Start()
    {
        // Найдите и получите ссылку на экземпляр класса ContrC
        contrC = GameObject.FindObjectOfType<ContrC>();

        // Проверьте, что ссылка не равна null, прежде чем обращаться к полю timesGo
        if (contrC != null)
        {
            timeText.text = String.Format("Время промежутков: {0} c", contrC.timesGo);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
