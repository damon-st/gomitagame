using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardarNiveles : MonoBehaviour
{

    public static GuardarNiveles guardarNiveles;
  
    public static string CargarDatos(string nivel)
    {
       
          return  PlayerPrefs.GetString(nivel);
        
    }

    public static void GuardarNivel(string nivel)
    {
        PlayerPrefs.SetString(nivel, nivel);
    }

   
    public static string CargarEstrellas(string nivel)
    {
        return PlayerPrefs.GetString(nivel);
    }

    public static void GuardarEstrellas(string nivel,string estrellas)
    {
        PlayerPrefs.SetString(nivel+"e", estrellas);
    }


    public static void GuardarManual(string guardado)
    {
        PlayerPrefs.SetString("manual", guardado);
    }

    public static string CargarManual(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static void GuardarPosicionPuerta(float x , float y)
    {
        PlayerPrefs.SetFloat("positionx", x);
        PlayerPrefs.SetFloat("positiony", y);
        
    }

    public static Vector2 CargarPosicionPuerta()
    {
        float x = PlayerPrefs.GetFloat("positionx");
        float y = PlayerPrefs.GetFloat("positiony");

        return new Vector2(x, y);
    }

    public static void GuardarEscenaOnmitida(string nivel)
    {
        PlayerPrefs.SetString(nivel + "escena", nivel);
    }

    public static string CargarEscenaOnmitida(string nivel)
    {
        return PlayerPrefs.GetString(nivel + "escena");
    }
}
