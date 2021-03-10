using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeJugador : MonoBehaviour
{
    MoverYrotar _MoverYrotar;

    bool puedoMover = false;


    public BoxCollider[] _BoxCollider;
  
    Vector3 startPos;

    GameHandler _GameHandler;
    private void Awake() {
        _MoverYrotar = GetComponent<MoverYrotar>();
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        {
            
            //hay un pequeño bug con el movimiento
            StartCoroutine(MoverSoloUnaVes());

            if(Input.GetMouseButtonDown(1))
            {
                //si esta en la grilla
                if(_GameHandler.inGrid(_MoverYrotar.lengthBarco,_MoverYrotar.lenghtBarcoDerecha,_MoverYrotar.lenghtBarcoIzquierda, (_MoverYrotar.direccion + 1) % 4,_MoverYrotar.X_posicion_imaginaria,_MoverYrotar.Y_posicion_imaginaria))
                {
                    //puedo rotar
                    _MoverYrotar.RotarBarco();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                DejarDeMover();
            }

 
        }
    }

    private IEnumerator MoverSoloUnaVes()
    {
        _MoverYrotar.MoverBarcosPorCuadricula();
        yield return null;
    }

    private void OnMouseOver()//si el mouse esta arriba de la colision
    {   
        //hay un pequeño bug con el movimiento
        if(Input.GetMouseButtonDown(0))
        {
            startPos = transform.localPosition;
            puedoMover = true;//puedo mover
        }

    }


    void DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        if(_MoverYrotar.EstaChocandoContraOtroBarco())
        {
            puedoMover = true;
        }
        if(!_MoverYrotar.EstaChocandoContraOtroBarco())
        {
            puedoMover = false;
        }
        // print("Ahora tendria que dejar de moverse")
    }

}
