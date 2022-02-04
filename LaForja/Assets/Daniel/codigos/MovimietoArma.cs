using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimietoArma : MonoBehaviour
{
    Vector3 posicion;
    public Camera camara;
    public Touch miToque;
    private Transform camaraT;
    void Start()
    {
        camara = Camera.main;
        camaraT = GameObject.Find("Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
       // if (Input.touchCount > 0)
        {
            //miToque = Input.GetTouch(0);
            //posicion = camara.ScreenToWorldPoint(miToque.position);
            //Physics.Raycast(camara,)
            //Ray ray = Camera.main.ScreenPointToRay(miToque.position);
            RaycastHit hit;
            if(Physics.Raycast(camaraT.position, camaraT.forward, out hit, 100f))
            {
                transform.position = hit.point;
            }
        }


    }
}
