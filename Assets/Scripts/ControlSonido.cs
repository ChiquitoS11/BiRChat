using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class ControlSonido : MonoBehaviour
{
    public AudioSource miMusica;
    public int delayMusica;

    void Start()
    {
        reproducirMusica();
    }

    private void reproducirMusica()
    {
        miMusica.PlayDelayed(delayMusica); 
    }

    void Update()
    {
        if (!miMusica.isPlaying) // METODO PROPIO DE AUDIOSOURCE QUE DETECTA AUTOMATICAMENTE SI LA MUSICA SE ESTA REPRODUCIENDO O NO
        {
            reproducirMusica();
        } 

    }
}
