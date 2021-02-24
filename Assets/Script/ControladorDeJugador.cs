using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeJugador : MonoBehaviour
{
    MoverYrotar _MoverYrotar;

    bool puedoMover = false;
    public BoxCollider[] _BoxCollider;

    private void Awake() {
        _MoverYrotar = GetComponent<MoverYrotar>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        {
            print("tendria que moverse");
            foreach (Collider i in _BoxCollider)
            {
                i.enabled = false;
            }
            _MoverYrotar.moverBarcosPorCuadricula();

            if(Input.GetMouseButtonDown(1))
            {
                _MoverYrotar.RotarBarco();
            }

            if(Input.GetMouseButtonUp(0))
            {
                DejarDeMover();
            }
        }
    }


    private void OnMouseOver()//si el mouse esta arriba de la colision
    {
        if(Input.GetMouseButtonDown(0))//si presione el mouse
        {
             puedoMover = true;//puedo mover
        } 
    }

    void DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        puedoMover = false;
        foreach (Collider i in _BoxCollider)
        {
            i.enabled = true;
        }
        print("Ahora tendria que dejar de moverse");

    }
}
