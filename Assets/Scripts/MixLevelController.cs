using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixLevelController : MonoBehaviour
{

    public AudioMixer maxterMixer;

    public void SetFXVolume(float valor)
    {
        maxterMixer.SetFloat("EfectosVolumen", valor);
    }

    public void SetAmbienteVolume(float valor)
    {
        maxterMixer.SetFloat("AmbienteVolumen", valor);
    }


}
