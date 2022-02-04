using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CogerYsoltar : MonoBehaviour
{
    public bool estadoJuego=false;
    void Update()
    {
        if (Input.touchCount > 0&& estadoJuego==true)
        {
            Touch touch = Input.GetTouch(0);
           // Vector2 posTouch = touch.position;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                transform.position = hit.point;
            }
        }
    }
}