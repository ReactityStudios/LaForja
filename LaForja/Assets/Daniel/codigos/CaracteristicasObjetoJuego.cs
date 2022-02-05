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
    public MeshFilter[] mallasObjetoDureza;
    public MeshFilter[] mallasObjetoFilo;
    public MeshFilter[] mallasObjetoLetalidad;
    public int cantidadColicionMartillo;
    public int puntosBuenos, PuntosMalos;
    public bool dentroDelHorno = true;
    public float pruebas;
    public Image barraCalor;
    public int colocarMallaFilo, colocarMallaDureza, colocarMallaLetalidad, colocarMallaArma;
    public bool tempaldo = false;
    void Start()
    {
        cantidadColicionMartillo = Random.Range(0, 6);
        calorActual = 0.1f;
    }

    void Update()
    {
        pruebas = (filo + dureza + letalidad) / 5f; //es un ejemplo el numero q se quiere poner es 5 
        barraCalor.fillAmount = calorActual / (calor * 2);
        letalidad = (((40f * filo) / 100f) + ((60f * dureza) / 100f));
        if (dentroDelHorno == false&& calorActual>0.5)
        {
            calorActual = calorActual - 0.0005f - (dificultad / 100f); 
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("templado")&& tempaldo==false)
        {
            tempaldo = true;
            if((100f * calorActual) / calor < 90)
            {
                dureza = Random.Range(0f, 0.2f);
            }
            if ((100f * calorActual) / calor > 90 && (100f * calorActual) / calor < 110)
            {
                dureza = Random.Range(0.8f, 1.0f);
            }
            if ((100f * calorActual) / calor > 110)
            {
                dureza = Random.Range(0.3f, 0.7f);
            }
        }
        if (other.gameObject.CompareTag("martillo")&&colocarMallaArma<mallasCambiarBuenas.Length)
        {
            cantidadColicionMartillo--;
            if (cantidadColicionMartillo == 0)
            {
                if (puntosBuenos > PuntosMalos)
                {
                    GetComponent<MeshFilter>().mesh = mallasCambiarBuenas[colocarMallaArma].sharedMesh;
                    Debug.Log("colocar buena malla");
                }
                else
                {
                    daño++;
                    GetComponent<MeshFilter>().mesh = mallasCambiarMalas[colocarMallaArma].sharedMesh;
                    Debug.Log("colocar mala malla");
                }

                puntosBuenos = 0;
                PuntosMalos = 0;
                colocarMallaArma++;
                cantidadColicionMartillo = Random.Range(0, 6);
            }
            else
            {
                if (cantidadColicionMartillo > 0 && (((100 * calorActual) / calor <= 110) && ((100 * calorActual) / calor) >= 90))
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
       
        if (other.gameObject.CompareTag("piedra afilar")&&filo<dureza)
        {
            filo = filo + Random.Range(0f, 0.05f)-dificultad/100;
            Debug.Log("colicion piedra afilar");
        }

        if(other.gameObject.CompareTag("Prueba dureza"))
        {
            if (dureza > (letalidad + dureza + filo) / 5)
            {
                other.gameObject.GetComponent<MeshFilter>().mesh = mallasObjetoDureza[colocarMallaDureza].sharedMesh;
                if (colocarMallaDureza < mallasObjetoDureza.Length)
                {
                    colocarMallaDureza++;
                }
                Debug.Log("pasa la prueba de dureza");
            }
        }
        if (other.gameObject.CompareTag("Prueba filo"))
        {
            if (filo > (letalidad + dureza + filo) / 5)
            {
                other.gameObject.GetComponent<MeshFilter>().mesh = mallasObjetoDureza[colocarMallaFilo].sharedMesh;
                if (colocarMallaDureza < mallasObjetoDureza.Length)
                {
                    colocarMallaFilo++;
                }
                Debug.Log("pasa la prueba de filo");
            }
        }
        if (other.gameObject.CompareTag("Prueba letalidad"))
        {
            if (letalidad > (letalidad + dureza + filo) / 5)
            {
                other.gameObject.GetComponent<MeshFilter>().mesh = mallasObjetoDureza[colocarMallaLetalidad].sharedMesh;
                if (colocarMallaLetalidad < mallasObjetoLetalidad.Length)
                {
                    colocarMallaLetalidad++;
                }
                Debug.Log("pasa la prueba de letalidad");
            }
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("horno"))
        {
            calorActual = calorActual + 0.005f-dificultad/1000f;
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
