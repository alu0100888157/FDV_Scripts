using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementObject : MonoBehaviour
{
    private Vector3 posicion;
    private Vector3 posicion_jugador;
    public GameObject jugador;
    public bool sumar = false; //Esto es para ver si se suma su puntuación en el StaticObject
    private bool lado;
    private bool cerca = true;
    private Vector3 escala;
    public int puntuacion = 0;
    // Start is called before the first frame update
    void Start()
    {
        posicion_jugador = jugador.transform.position;
        escala.x = 0.5f;
        escala.y = 0.5f;
        escala.z = 0.5f;
        posicion.Set(Random.Range(-53, 53), 1, Random.Range(-53, 53));
        this.gameObject.transform.position = posicion;
        InvokeRepeating("ChangePosition", 0, 0.5f); //calls ChangePosition() every 2 secs
    }

    // Update is called once per frame
    void Update()
    {
        posicion_jugador = jugador.transform.position;
        if(Vector3.Distance(posicion_jugador,posicion) < 5 && cerca)
        {
            
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            if (this.gameObject.transform.localScale.sqrMagnitude > escala.sqrMagnitude )
            {
                this.gameObject.transform.localScale = this.gameObject.transform.localScale * 0.75f;
                cerca = false;
                puntuacion += 25;
                sumar = true;
            }
            else
            {
                puntuacion += 25;
                sumar = true;
                this.gameObject.SetActive(false);
            }
        }
        else if(Vector3.Distance(posicion_jugador, posicion) > 5)
        {
            cerca = true;
            sumar = false;
        }
    }

    void ChangePosition()
    {
        if (posicion.x < 53 && posicion.x + 1 < 53 && lado)
        {
            posicion.x++;
            this.gameObject.transform.position = posicion;
        }
        else if(posicion.x > -53 && posicion.x - 1 > -53)
        {
            posicion.x--;
            lado = false;
            this.gameObject.transform.position = posicion;
        } 
        else
        {
            lado = true;
        }
    }
}
