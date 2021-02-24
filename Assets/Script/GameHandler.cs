using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    
    //hago referencia a la grilla donde estoy posicionado con el mouse,
    //lo uso desde el script cuadricula colision que al entrar el mouse devuelve el objeto donde estoy arriba 
    //luego es usado desde posicionarYrotar para posicionar el barco a donde esta el mouse arriba en ese 
    //posicion en concreto del la grilla
    public GameObject grillaActual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
