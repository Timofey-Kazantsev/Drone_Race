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
        ipdText.text = String.Format("������������ ����������: {0} ��", ipd);
        var dist = ipd / 1000.0f;
        VrsViewer.Instance.SetIpd(dist);
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
        if (contrC != null)
        {
            timeText.text = String.Format("����� �����������: {0} ��", contrC.timesGo);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
