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
    public int X_posicion_imaginaria = 0;
    [SerializeField]
    public int Y_posicion_imaginaria = 0;

    public int X_posicion_imaginaria_anterior , Y_posicion_imaginaria_anterior;

    public void Awake() {
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    private void Start() {
        
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
        // RESETEA LA POSICIÓN OCUPADA ACTUALMENTE, ESTO ES EL PROBLEMA DEL BUG PORQUE EN EL BUCLE SE HACE MUCHAS VECES
        // Y HACE QUE LOS BARCOS SE SUPERPONGAN,SI COMENTAS ESTA LINEA VAS A VER QUE PODES MOVER LOS BARCOS CON DIRECCION
        //HACIA ABAJO Y OCUPAN LOS CASTILLEROS,PERO LUEGO QUEDAN TODOS MARCADOS Y YA NO SE PUEDE VOLVER A MOVER 
        _GameHandler.setOccupied(lengthBarco, direccion, X_posicion_imaginaria_anterior, Y_posicion_imaginaria_anterior, 0);//cero esta posición no esta ocupada
        
        //si esta dentro de la grilla puedo mover..
        //Recibe como parametro el tamaño del barco(aunque no se desde adonde toma el tamaño),
        //la dirección hacia adonde apunta,
        //la posición imaginaria de la grilla en el eje "X" y en el eje "Y"..."El eje Y es el Z" nose si corrija ese detalle,no me molesta
        X_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_X_posicion;
        Y_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_Y_posicion;


        Vector3 PosicionNueva = _GameHandler.grillaActual.transform.position;
       

            //si esta adentro de la grilla
            if ( _GameHandler.inGrid(lengthBarco, lenghtBarcoDerecha , lenghtBarcoIzquierda , direccion,X_posicion_imaginaria,Y_posicion_imaginaria) )
            {
                //muevo el barco a la posicion de la grilla
                    // this.gameObject.transform.position = new Vector3(
                    //     _GameHandler.grillaActual.transform.position.x,
                    //     this.gameObject.transform.position.y,
                    //     _GameHandler.grillaActual.transform.position.z
                    // );

                //si la posición no esta ocupada por otro barco
                if(!_GameHandler.isOccupied(lengthBarco,direccion,X_posicion_imaginaria,Y_posicion_imaginaria))//hago la comparación con la posición anterior para evitar el
                {
                    //muevo el barco a la posicion de la grilla
                    this.gameObject.transform.position = new Vector3(
                        PosicionNueva.x,
                        this.gameObject.transform.position.y,
                        PosicionNueva.z
                    );
                }
            }

            
        
        // //hago que esa posición este ocupada para que los barcos no se superpongan
        _GameHandler.setOccupied(lengthBarco, direccion, X_posicion_imaginaria, Y_posicion_imaginaria, 1);//uno esta posición no esta ocupada
     
        X_posicion_imaginaria_anterior = X_posicion_imaginaria;
        Y_posicion_imaginaria_anterior = Y_posicion_imaginaria;
        // print("MUEVO EL BARCO :" + this.transform.gameObject.name);
        // print( " Esta OCUPADO X = " + X_posicion_imaginaria + " / " + " Esta OCUPADO Y = " + Y_posicion_imaginaria);
    }
}
