using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYrotar : MonoBehaviour
{

    GameHandler _GameHandler;

    public int lengthBarco;//tamaño de arriba abajo del barco

    public int lenghtBarcoDerecha;//tamaño hacia la derecha del barco
    
    public int lenghtBarcoIzquierda;//tamaño hacia la izquierda del barco

    public int direccion = 0;

    [SerializeField]
    private int X_posicion_imaginaria = 0;
    [SerializeField]
    private int Y_posicion_imaginaria = 0;

    private void Awake() {
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    /// <summary>Rota 90 grados el barco</summary>
    public void RotarBarco()
    {
        transform.Rotate(new Vector3(0,0,90),Space.Self);
        direccion += 1;//relacionado a los movimientos imaginorios para rotar el barco
        if(direccion > 3)//relacionado a los movimientos imaginorios para rotar el barco
        {
            direccion = 0;//relacionado a los movimientos imaginorios para rotar el barco
        }
    }
    

    /// <summary>Mueve el barco usando la cuadricula y devuelve la posición de la grilla</summary>
    public void moverBarcosPorCuadricula()
    {
        //si esta dentro de la grilla puedo mover..
        //Recibe como parametro el tamaño del barco(aunque no se desde adonde toma el tamaño),
        //la dirección hacia adonde apunta,
        //la posición imaginaria de la grilla en el eje "X" y en el eje "Y"..."El eje Y es el Z" nose si corrija ese detalle,no me molesta
        X_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_X_posicion;
        Y_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_Y_posicion;
        if ( _GameHandler.inGrid(lengthBarco, lenghtBarcoDerecha , lenghtBarcoIzquierda , direccion,X_posicion_imaginaria,Y_posicion_imaginaria) )
        {
            this.gameObject.transform.position = new Vector3(
                _GameHandler.grillaActual.transform.position.x,
                this.gameObject.transform.position.y,
                _GameHandler.grillaActual.transform.position.z
            );
        }

        
    }
}
