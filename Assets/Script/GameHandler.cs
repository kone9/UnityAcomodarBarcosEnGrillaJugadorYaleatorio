using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    
    //hago referencia a la grilla donde estoy posicionado con el mouse,
    //lo uso desde el script cuadricula colision que al entrar el mouse devuelve el objeto donde estoy arriba 
    //luego es usado desde posicionarYrotar para posicionar el barco a donde esta el mouse arriba en ese 
    //posicion en concreto del la grilla

    int[,] occupied = new int[10, 10];//se usa como castillero imaginario
    public int posiciones_X;
    public int posiciones_Y;

    //direcciones
    private const int EAST = 1;
    private const int WEST = 3;
    private const int SOUTH = 2;
    private const int NORTH = 0;

    public GameObject grillaActual;

    public LayerMask grillaParaColision;



    //si estoy dentro de la grilla solo puedo mover
    public bool inGrid(int length,int lenghtBarcoDerecha,int lenghtBarcoIzquierda, int dir, int x, int y)
    {
        switch (dir)
        {
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
                if (x <= (9 - (length - 1) )   && y >= lenghtBarcoIzquierda  && y <= (9 - (lenghtBarcoDerecha)) ) //si posicion en y es mayor a cero y si y es menor o igial a 10 menos tamaño del barco y x es mayor a cero y si y es menor o igual a nueve
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



    //para saber si la grilla esta ocupada devuelve verdadero o falso
    public bool isOccupied(int length, int dir, int x, int y)
    {
        switch (dir)
        {
            case EAST:  //y+
                for (int i = y; i < y + length; i++)
                {
                    if (occupied[x, i] == 1)
                        return true;
                }
                break;
            case WEST:  //y-
                for (int i = y; i > y - length; i--)
                {
                    if (occupied[x, i] == 1)
                        return true;
                }
                break;
            case SOUTH: //x+
                for (int i = x; i < x + length; i++)
                {
                    if (occupied[i, y] == 1)
                        return true;
                }
                break;
            // case NORTH: //x-
            //     for (int i = x; i > x - length; i--)
            //     {
            //         if (occupied[i, y] == 1)
            //             return true;
            //     }
            //     break;
            case NORTH: //x-
                // for (int i = y; i > y + length; i--)
                // {
                //     if (occupied[x, i] == 1)
                //         return true;
                // }
                if (occupied[x, y] == 1)
                    return true;
                break;
        }
        return false;
    }

    //hacer que esta posición este ocupada
    //el parametro value es usado en isOccupied si es 1 ese lugar esta ocupado si es 0 no lo esta
    public void setOccupied(int length, int dir, int x, int y, int value)
    {
        switch (dir)
        {
            // case EAST:  //y+
            //     for (int i = y; i < y + length; i++)
            //     {
            //         occupied[x, i] = value;
            //     }
            //     break;
            // case WEST:  //y-
            //     for (int i = y; i > y - length; i--)
            //     {
            //         occupied[x, i] = value;
            //     }
            //     break;
            // case SOUTH: //x+
            //     for (int i = x; i < x + length; i++)
            //     {
            //         print(y);
            //         occupied[i, y] = value;
            //     }
            //     break;
            // case NORTH: //x-
            //     for (int i = x; i > x - length; i--)
            //     {
            //         print(y);
            //         occupied[i, y] = value;
            //     }
            //     break;
            case NORTH: //x-
                // for (int i = y; i > y + length; i--)
                // {
                //     print(x);
                //     occupied[x, i] = value;
                // }

                occupied[x, y] = value;
                break;
        }
    }


    void rayoParaDetectarSuelo()
    {
        Ray ray;
        RaycastHit rayHit;
        float rayLength = 100f;

        //어디를 터치했느냐
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out rayHit, rayLength,grillaParaColision))
        {
            //배를 터치했다면
            // if (rayHit.transform.gameObject.tag == "boat")
            // {
            //     print("Estoy arriba del BARCO " + rayHit.transform.gameObject.name);
            //     //배의 위치 이동 및 회전을 담당하는 코루틴 호출
            //     // StartCoroutine(MoverSoloUnaVes());
            //     puedoMover = true;
            // }
            // Debug.DrawLine(rayHit.transform.position,rayHit.transform.position * Vector3.down,Color.red,0.1f);
            Debug.DrawRay(rayHit.transform.position,Vector3.down* -rayLength,Color.red,0.1f);
            if (rayHit.transform.gameObject.CompareTag("cuadricula"))
            {
                print("Estoy arriba de la GRILLA " + rayHit.transform.gameObject.name);
                grillaActual = rayHit.transform.gameObject;
                // grillaActual.GetComponent<MeshRenderer>().enabled = true;
            }
           
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        rayoParaDetectarSuelo();
    }
}
