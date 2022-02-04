using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Producto : MonoBehaviour
{
    public ControlNivel control;
    public GameObject producto;
    public void Selec()
    {
        control.MaterialSeleccion = producto;
        control.mallaObjetoInicial = producto.GetComponent<Mesh>();
    }
}
