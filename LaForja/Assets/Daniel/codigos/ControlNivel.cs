using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="control nivel", menuName ="ramdon")]
public class ControlNivel : ScriptableObject
{
    public GameObject[] inventarioCuchillosForjar;
    public MeshFilter[] mallasArma1;
    public MeshFilter[] mallasArma1Malas;
    public MeshFilter[] mallasArma2;
    public MeshFilter[] mallasArma2Malas;
    public MeshFilter[] mallasArma3;
    public MeshFilter[] mallasArma3Malas;
    public MeshFilter[] mallasArma4;
    public MeshFilter[] mallasArma4Malas;
    public GameObject cuchilloAForjar;
    public GameObject MaterialSeleccionado;
    public GameObject MaterialSeleccion;
    public Mesh mallaObjetoInicial;
    /*public Mesh mallaSaiMai;
    public Mesh mallaBarra;*/

}
