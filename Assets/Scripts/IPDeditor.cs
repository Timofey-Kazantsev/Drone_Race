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
    public string strD;

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
        List<int> differences = new List<int>();
        for (int i = 0; i < contrC.timesGo.Count; i++)
        {
            if (i + 1 < contrC.timesGo.Count)
            {
                int diff = contrC.timesGo[i + 1] - contrC.timesGo[i];
                differences.Add(diff);
            }

        }
        Debug.Log(differences.Count);
        for (int i = 0; i < differences.Count - 1; i++)
        {
            string strD = string.Format("\n{0} участок - {1} секунд", i, differences[i]);
            timeText.text += strD;
        }
        string allTime = string.Format("\nОбщее время - {0} минут {1} секунд", contrC.g_min, contrC.g_sec);
        timeText.text += allTime;
    }

    void Start()
    {
        ipdText = GameObject.Find("IPDtext").GetComponent<TextMesh>();
        timeText = GameObject.Find("timeText").GetComponent<TextMesh>();
        contrC = GameObject.FindObjectOfType<ContrC>();

        if (PlayerPrefs.HasKey("ipd"))
        {
            ipd = PlayerPrefs.GetFloat("ipd");
            applyIPD();
        }
        List<int> differences = new List<int>();
        for (int i = 0; i < contrC.timesGo.Count; i++)
        {
            if (i + 1 < contrC.timesGo.Count)
            {
                int diff = contrC.timesGo[i + 1] - contrC.timesGo[i];
                differences.Add(diff);
            }

        }
        Debug.Log(differences.Count);
        for (int i = 0; i < differences.Count - 1; i++)
        {
            string strD = string.Format("\n{0} участок - {1} секунд", i, differences[i]);
            timeText.text += strD;
        }
        string allTime = string.Format("\nОбщее время - {0} минут {1} секунд", contrC.g_min, contrC.g_sec);
        timeText.text += allTime;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
