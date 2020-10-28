using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticObject : MonoBehaviour
{
    public GameObject objetoquieto1;
    public GameObject objetoquieto2;
    public GameObject jugador;
    public Text Texto_Score;
    public int scorevalue = 0;
    public MovementObject Objeto_Movil1;
    public MovementObject Objeto_Movil2;
    private Vector3 posicion;
    private Vector3 posicion2;
    private Vector3 posicion_jugador;
    private Vector3 escala;
    private bool flip;
    private bool cerca1 = true;
    private bool cerca2 = true;

    // Start is called before the first frame update
    void Start()
    {
        escala.x = 0.5f;
        escala.y = 0.5f;
        escala.z = 0.5f;
        flip = true;
        posicion.Set(Random.Range(-53, 53), 1, Random.Range(-53, 53));
        posicion2.Set(Random.Range(-53, 53), 1, Random.Range(-53, 53));
        objetoquieto1.transform.position = posicion;
        objetoquieto2.transform.position = posicion2;
        InvokeRepeating("ChangePosition", 10, 10); //calls ChangePosition() every 2 secs
        
    }

    // Update is called once per frame
    void Update()
    {
        posicion_jugador = jugador.transform.position;
        cerca1 = ComprobarEstaticos(posicion_jugador, objetoquieto1,cerca1);
        cerca2 = ComprobarEstaticos(posicion_jugador, objetoquieto2,cerca2);
        ObtenerPuntuacion(Objeto_Movil1);
        ObtenerPuntuacion(Objeto_Movil2);


        Texto_Score.text = "Score:   " + scorevalue.ToString();
    }

    
    void ObtenerPuntuacion(MovementObject Movil)
    {
        if (Movil.sumar)
        {
            scorevalue += Movil.puntuacion;
            Movil.sumar = false;
        }
    }

    bool ComprobarEstaticos(Vector3 posicion_jugador_, GameObject objetoquieto, bool cerca)
    {
        if (Vector3.Distance(posicion_jugador_, objetoquieto.transform.position) < 5 && cerca)
        {

            objetoquieto.GetComponent<Renderer>().material.color = Color.blue;
            if (objetoquieto.transform.localScale.sqrMagnitude > escala.sqrMagnitude)
            {
                objetoquieto.transform.localScale = objetoquieto.transform.localScale * 0.75f;
                
                scorevalue += 15;
                return false;
            }
            else
            {
                scorevalue += 15;
                objetoquieto.SetActive(false);
                return false;
            }

        }
        else if (Vector3.Distance(posicion_jugador_, objetoquieto.transform.position) > 5)
        {
            
            return true;
        }
        return false;
    }

    void ChangePosition()
    {

        Debug.Log(flip + "   " + posicion + "   " + posicion2);
        if(flip)
        {
            objetoquieto1.transform.position = posicion2;
            objetoquieto2.transform.position = posicion;
            flip = false;
            
        }
        else
        {
            objetoquieto2.transform.position = posicion2;
            objetoquieto1.transform.position = posicion;
            flip = true;
        }
        
    }
}
