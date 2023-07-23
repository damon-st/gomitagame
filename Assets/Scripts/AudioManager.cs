using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    //utilizo la metodologia singleTon
    static AudioManager current;

    [Header("Sonidos")]
    public AudioClip clipWalk;
    public AudioClip clipWalkIzquierdo;
    public AudioClip clipAmbiente;
    public AudioClip clipCoin;
    public AudioClip clipTemporizador;
    public AudioClip clipSaltar;
    public AudioClip clipDoorOpen;
    public AudioClip clipColissionEnemys;
    public AudioClip clipPuertaNivel;
    public AudioClip clipWinLevel;
    public AudioClip clipPortal;
    public AudioClip clipMenu;


    [Header("MixerGroup")]
    public AudioMixerGroup groupWalk;
    public AudioMixerGroup groupWalkIzquierdo;
    public AudioMixerGroup groupAmbiente;
    public AudioMixerGroup groupCoin;
    public AudioMixerGroup groupTemporizador;
    public AudioMixerGroup groupSaltar;
    public AudioMixerGroup groupDoorOpen;
    public AudioMixerGroup groupCollisionEnemys;
    public AudioMixerGroup groupPuertaNivel;
    public AudioMixerGroup groupWinLevel;
    public AudioMixerGroup groupPortal;
    public AudioMixerGroup groupMenu;
    


    AudioSource ambientSource;
    AudioSource walkSource;
    AudioSource walkSourceIzquierdo;
    AudioSource coinSource;
    AudioSource temporizadorSource;
    AudioSource saltarSource;
    AudioSource doorOpenSource;
    AudioSource collisionEnemys;
    AudioSource puertaNivelSource;
    AudioSource winLevelSource;
    AudioSource portalSource;
    AudioSource menuSource;

    private void Awake()
    {
        // si audiomanager existe y no es este 
        if (current != null && current != this)
        {
            // destruimos esta clase para que solo se carge una vez el AudioManger
            Destroy(gameObject);
            return;
        }

        // este es el audiomanager actual y debe persistir entre las cargas de escena
        current = this;
        DontDestroyOnLoad(gameObject);

        //generar los canales de fuente de audio para nuestros juegos de audio
        ambientSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        walkSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        walkSourceIzquierdo = gameObject.AddComponent<AudioSource>() as AudioSource;
        coinSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        temporizadorSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        saltarSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        doorOpenSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        collisionEnemys = gameObject.AddComponent<AudioSource>() as AudioSource;
        puertaNivelSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        winLevelSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        portalSource = gameObject.AddComponent<AudioSource>() as AudioSource;
        menuSource = gameObject.AddComponent<AudioSource>() as AudioSource;

        //asegunciando cada fuente de audio a su grupo mezclador respectivo para que sea enrutado
        //y controlado por el mezclador de audio

        ambientSource.outputAudioMixerGroup = groupAmbiente;
        walkSource.outputAudioMixerGroup = groupWalk;
        walkSourceIzquierdo.outputAudioMixerGroup = groupWalkIzquierdo;
        coinSource.outputAudioMixerGroup = groupCoin;
        temporizadorSource.outputAudioMixerGroup = groupTemporizador;
        saltarSource.outputAudioMixerGroup = groupSaltar;
        doorOpenSource.outputAudioMixerGroup = groupDoorOpen;
        collisionEnemys.outputAudioMixerGroup = groupCollisionEnemys;
        puertaNivelSource.outputAudioMixerGroup = groupPuertaNivel;
        winLevelSource.outputAudioMixerGroup = groupWinLevel;
        portalSource.outputAudioMixerGroup = groupPortal;
        menuSource.outputAudioMixerGroup = groupMenu;

       

        // empezamos a reproducir el audio dle juego
        StarLevelAudio();
    }

    private void StarLevelAudio()
    {
        //Ajuste el clip para el audio ambien decirle que se ponga en bucle, y el dile que se reproduzca
        current.ambientSource.clip = current.clipAmbiente;
        current.ambientSource.loop = true;
        current.ambientSource.Play();

        //
    }

    public static void PlayWalkStepAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip

        if (current == null || current.walkSource.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.walkSource.clip = current.clipWalk;
        current.walkSource.loop = false;
        current.walkSource.Play();
    }

    public static void PlayWlakIzquierdoAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip

        if (current == null || current.walkSourceIzquierdo.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.walkSourceIzquierdo.clip = current.clipWalkIzquierdo;
        current.walkSourceIzquierdo.loop = false;
        current.walkSourceIzquierdo.Play();
    }
    

    public static void PlayCoinStepAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.coinSource.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.coinSource.clip = current.clipCoin;
        current.coinSource.Play();

    }

    public static void PlayTemporizadorAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.temporizadorSource.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.temporizadorSource.clip = current.clipTemporizador;
        current.temporizadorSource.Play();

    }

    public static void StopTemporizadorAudio()
    {
        if(current != null || current.temporizadorSource!=null)
        current.temporizadorSource.Stop();

    }


    public static void PlaySaltarAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.saltarSource.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.saltarSource.clip = current.clipSaltar;
        
        current.saltarSource.Play();
    }

    public static void PlayOpenDoorAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.doorOpenSource.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.doorOpenSource.clip = current.clipDoorOpen;

        current.doorOpenSource.Play();
    }

    public static void PlayCollisionEnemyAudio()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.collisionEnemys.isPlaying)
            return;
        // establecer el clip de paso y decirle a la fuente para reproducir
        current.collisionEnemys.clip = current.clipColissionEnemys;

        current.collisionEnemys.Play();
    }


    public static void PlayPuertaNivel()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.puertaNivelSource.isPlaying)
            return;

        // establecer el clip de paso y decirle a la fuente para reproducir
        current.puertaNivelSource.clip = current.clipPuertaNivel;
        current.puertaNivelSource.Play();
    }


    public static void PlayWinLevel()
    {
        //si no hay un audiomanager actual o la fuente del reproductor ya está reproduciendo 
        //una salida de clip
        if (current == null || current.winLevelSource.isPlaying) return;

        // establecer el clip de paso y decirle a la fuente para reproducir
        current.winLevelSource.clip = current.clipWinLevel;
        current.winLevelSource.loop = false;
        current.winLevelSource.Play();

    }

    // Start is called before the first frame update
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            Application.targetFrameRate = 30;
        }
    }

    public static void PlayPortalAudio()
    {
        if (current == null || current.portalSource.isPlaying) return;

        current.portalSource.clip = current.clipPortal;
        current.portalSource.loop = false;
        current.portalSource.Play();
    }

    public static void StopPortalAudio()
    {
        if(current != null || current.portalSource.isPlaying)
        {
            current.portalSource.Stop();
        }
    }

    public static void PlayAudioMenu()
    {
        if (current == null && current.menuSource.isPlaying) return;

        current.menuSource.clip = current.clipMenu;
        current.menuSource.loop = false;
        current.menuSource.Play();
    }

}
