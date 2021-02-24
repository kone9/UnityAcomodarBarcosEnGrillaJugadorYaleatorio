using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYrotar : MonoBehaviour
{

    GameHandler _GameHandler;

    private void Awake() {
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    /// <summary>Rota 90 grados el barco</summary>
    public void RotarBarco()
    {
         transform.Rotate(new Vector3(0,0,90),Space.Self);
    }
    

    /// <summary>Mueve el barco usando la cuadricula</summary>
    public void moverBarcosPorCuadricula()
    {
        this.gameObject.transform.position = new Vector3(
            _GameHandler.grillaActual.transform.position.x,
            this.gameObject.transform.position.y,
            _GameHandler.grillaActual.transform.position.z
        ); 
    }
}
