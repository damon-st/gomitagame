using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusicConfi : MonoBehaviour
{

    public Slider FxVolumen, AmbienteVolumen;


    void LoadState()
    {
        FxVolumen.value = PlayerPrefs.GetFloat("FxVolumen", 0f);
        AmbienteVolumen.value = PlayerPrefs.GetFloat("AmbienteVolumen", 0f);
    }

    public void SaveState()
    {
        PlayerPrefs.SetFloat("FxVolumen", FxVolumen.value);
        PlayerPrefs.SetFloat("AmbienteVolumen", AmbienteVolumen.value);
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadState();
    }

}
