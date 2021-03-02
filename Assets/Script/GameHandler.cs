using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    
    //hago referencia a la grilla donde estoy posicionado con el mouse,
    //lo uso desde el script cuadricula colision que al entrar el mouse devuelve el objeto donde estoy arriba 
    //luego es usado desde posicionarYrotar para posicionar el barco a donde esta el mouse arriba en ese 
    //posicion en concreto del la grilla

    int[,] occupied = new int[10, 10];
    private const int EAST = 1;
    private const int WEST = 3;
    private const int SOUTH = 2;
    private const int NORTH = 0;

    public GameObject grillaActual;

    //si estoy dentro de la grilla solo puedo mover
    public bool inGrid(int length,int lenghtBarcoDerecha,int lenghtBarcoIzquierda, int dir, int x, int y)
    {
        switch (dir)
        {
            // case EAST:  //y+
            //     if (y >= 0 && y <= 10 - length && x >=0 && x <= 9)//si posicion en y es mayor a cero y si y es menor o igial a 10 menos tamaño del barco y x es mayor a cero y si y es menor o igual a nueve
            //         return true;
            // break;
            // case WEST:  //y-
            //     if (y >= length - 1 && y < 10 && x >= 0 && x <= 9)
            //         return true;
            // break;
            // case SOUTH: //x+
            //     if (x >= 0 && x <= 10 - length && y >= 0 && y <= 9)
            //         return true;
            // break;
            // case NORTH: //x-
            //     if (x >= length - 1 && x < 10 && y >= 0 && y <= 9)
            //         return true;
            // break;
            case NORTH: //y-
                if (y >= length - 1 && x >= lenghtBarcoIzquierda  && x <= (9 - (lenghtBarcoDerecha)) )// es menos 1 porque comienza desce cero
                {
                    return true;
                }
                break;
            case SOUTH: //y+
                if (y <= (9 - (length - 1) ) && x >= lenghtBarcoDerecha  && x <= (9 - (lenghtBarcoIzquierda)) )//nueve porque comienza desde cero..Descuento 1 al tamaño de barco porque comienza desde cero
                {
                    return true;
                }
                break;
            case EAST:  //y+
                if (x <= (9 - (length - 1) )   && y >= lenghtBarcoIzquierda  && y <= (9 - (lenghtBarcoDerecha - 1)) ) //si posicion en y es mayor a cero y si y es menor o igial a 10 menos tamaño del barco y x es mayor a cero y si y es menor o igual a nueve
                {
                    return true;
                }
                break;
            
            case WEST:  //y-
                if (x >= length - 1  && y >= lenghtBarcoDerecha  && y <= (9 - (lenghtBarcoIzquierda)) )                
                {
                    return true;
                }
                break;
            
           
        }
        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
