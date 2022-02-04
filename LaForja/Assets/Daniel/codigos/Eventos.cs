using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Eventos : MonoBehaviour
{
    public ControlNivel control;
    public CaracteristicasObjetoJuego caracteristicasJuegoV;
    public CinemachineVirtualCamera[] cameraThir;
    public int encenderCamaraPos;
    public Mesh objetojuego;
    
    private void Start()
    {
        //objetojuego = caracteristicasJuegoV.GetComponent<MeshFilter>().mesh;
       // objetojuego = control.MaterialSeleccionado.GetComponent<MeshFilter>(); 
      // objetojuego = control.MaterialSeleccionado.GetComponent<MeshFilter>().sharedMesh;
    }

    public void IniciarJuego()
    {
        int posSeleccion = Random.Range(0, control.inventarioCuchillosForjar.Length);
        control.cuchilloAForjar = control.inventarioCuchillosForjar[posSeleccion];
        //caracteristicasJuegoV.mallasCambiar = control.
        switch (posSeleccion)
        {
            case 0:
                caracteristicasJuegoV.mallasCambiarBuenas = control.mallasArma1;
                caracteristicasJuegoV.mallasCambiarMalas = control.mallasArma1Malas;
                break;
            case 1:
                caracteristicasJuegoV.mallasCambiarBuenas = control.mallasArma2;
                caracteristicasJuegoV.mallasCambiarMalas = control.mallasArma2Malas;
                break;
            case 2:
                caracteristicasJuegoV.mallasCambiarBuenas = control.mallasArma3;
                caracteristicasJuegoV.mallasCambiarMalas = control.mallasArma3Malas;
                break;
            case 3:
                caracteristicasJuegoV.mallasCambiarBuenas = control.mallasArma4;
                caracteristicasJuegoV.mallasCambiarMalas = control.mallasArma4Malas;
                break;
        }
    }
    public void Seleccionar()
    {
        control.MaterialSeleccionado = control.MaterialSeleccion;

        caracteristicasJuegoV.gameObject.GetComponent<MeshFilter>().mesh = control.MaterialSeleccionado.GetComponent<MeshFilter>().sharedMesh;
        caracteristicasJuegoV.puntos = control.MaterialSeleccionado.GetComponent<Caracteristicas>().puntos;
        caracteristicasJuegoV.dificultad = control.MaterialSeleccionado.GetComponent<Caracteristicas>().dificultad;
        caracteristicasJuegoV.maleabilidad = control.MaterialSeleccionado.GetComponent<Caracteristicas>().maleabilidad;
        caracteristicasJuegoV.calor = control.MaterialSeleccionado.GetComponent<Caracteristicas>().calor;
        //caracteristicasJuegoV.gameObject.SetActive(true);
        caracteristicasJuegoV.GetComponent<CogerYsoltar>().estadoJuego = true;
        // MeshFilter malla1= caracteristicasJuegoV.GetComponent<MeshFilter>(); 
        control.MaterialSeleccion = null;
        control.MaterialSeleccionado = null;

    }
    public void CambiarCamaraDerecha()
    {
        switch (encenderCamaraPos)
        {
            case 0:
                encenderCamaraPos = 1;
                break;
            case 1:
                encenderCamaraPos = 2;
                break;
            case 2:
                encenderCamaraPos = 0;
                break;
        }

        for (int i = 0; i < cameraThir.Length; i++)
        {
            if (encenderCamaraPos==i)
            {
                cameraThir[i].Priority = 11;
            }
            else
            {
                cameraThir[i].Priority = 10;
            }
        }
    }
    public void CambiarCamaraIzquierda()
    {
        switch (encenderCamaraPos)
        {
            case 0:
                encenderCamaraPos = 2;
                break;
            case 1:
                encenderCamaraPos = 0;
                break;
            case 2:
                encenderCamaraPos = 1;
                break;
        }

        for (int i = 0; i < cameraThir.Length; i++)
        {
            if (encenderCamaraPos == i)
            {
                cameraThir[i].Priority = 11;
            }
            else
            {
                cameraThir[i].Priority = 10;
            }
        }
    }

}
