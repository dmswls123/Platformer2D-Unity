using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/// <summary>
/// UI - slikder ������Ʈ�� �ִ� ������Ʈ�� �� Ŭ���� ����(Add)�ؾ��Ѵ�.
/// </summary>

public class VolumeController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider slider;
    public string mixerParameterName; // BGM, SFX �ۼ����ִ� ����(����� �ͼ� �ȿ� �����)
    public float sliderMultiPlier = 25; // ~1,0������ slider value�� �� ũ�� ���̱� ���� ����

    void Start()
    {
        slider.onValueChanged.AddListener(SliderValue);
        slider.minValue = 0.0001f;
    }


    public void SliderValue(float value)
    {
        audioMixer.SetFloat(mixerParameterName, Mathf.Log10(value) * sliderMultiPlier);
    }
}
