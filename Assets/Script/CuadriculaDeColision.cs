using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuadriculaDeColision : MonoBehaviour
{
    
    GameHandler _GameHandler;
    
    public int Grilla_X_posicion = 0;
    public int Grilla_Y_posicion = 0;
    private void Awake() {
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //si el mouse entra a esta cuadricula
    private void OnMouseEnter()
    {
        // _GameHandler.grillaActual = this.gameObject;//guardo este gameobject
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;//activo la malla de vista
    }

    //si el mouse sale
    private void OnMouseExit() {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;//desactivo la malla de vista
    }
}
