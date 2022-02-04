using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaracteristicasObjetoJuego : MonoBehaviour
{
    public float filo, dureza, letalidad, belleza;
    public int puntos, dificultad, maleabilidad, calor;
    public float calorActual;
    public float daño;
    public MeshFilter[] mallasCambiarBuenas;
    public MeshFilter[] mallasCambiarMalas;
    public int cantidadColicionMartillo;
    public int puntosBuenos, PuntosMalos;
    public bool dentroDelHorno = true;
    public float pruebas;
    public Image barraCalor;
    void Start()
    {
        cantidadColicionMartillo = Random.Range(0, 6);
    }

    void Update()
    {
        barraCalor.fillAmount = calorActual / (calor * 2);
        pruebas = calorActual / (calor * 2f);
        letalidad = (((50f * filo) / 100f) + ((50f * dureza) / 100f));
        if (dentroDelHorno == false&& calorActual>0.5)
        {
            calorActual = calorActual - 0.0005f - (dificultad / 100f); 
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("martillo"))
        {
            cantidadColicionMartillo--;
            if (cantidadColicionMartillo == 0)
            {
                if (puntosBuenos > PuntosMalos)
                {
                    GetComponent<MeshFilter>().mesh = mallasCambiarBuenas[0].sharedMesh;
                    Debug.Log("colocar buena malla");
                }
                else
                {
                    daño++;
                    GetComponent<MeshFilter>().mesh = mallasCambiarMalas[0].sharedMesh;
                    Debug.Log("colocar mala malla");
                }

                puntosBuenos = 0;
                PuntosMalos = 0;
                cantidadColicionMartillo = Random.Range(0, 6);
            }
            else
            {
                if (cantidadColicionMartillo > 0 && ((100 * calorActual) / calor) <= 110 && ((100 * calorActual) / calor) >= 90)
                {
                    puntosBuenos++;
                    Debug.Log("porcentaje de temperatura correcto ");
                }
                else
                {
                    PuntosMalos++;
                    Debug.Log("temperatura mala");
                }
            }           
            Debug.Log("colicion martillo");
        }
       
        if (other.gameObject.CompareTag("piedra afilar"))
        {
            filo = filo + 0.05f;
            Debug.Log("colicion piedra afilar");
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("horno"))
        {
            calorActual = calorActual + 0.0005f;
            dentroDelHorno = true;
            Debug.Log("colicion horno dentro");
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("horno"))
        {
            dentroDelHorno = false;
            Debug.Log("sale del horno ");
        }
    }
}
