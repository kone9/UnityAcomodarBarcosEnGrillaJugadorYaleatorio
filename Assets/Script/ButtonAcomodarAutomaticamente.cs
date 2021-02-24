using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAcomodarAutomaticamente : MonoBehaviour
{
    
    GameObject[] barcos;
    GameObject[] cuadriculas;

    private void Awake() {
        barcos = GameObject.FindGameObjectsWithTag("boat");//busca todos los barcos
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadricula");
    }

    //para acomodar los barcos de forma aleatoria
    public void AcomodarBarcosDeformaAleatoria()
    {
        //tendria que tomar aleatoriamente 5 posiciones de la grilla

        //posicionar los barcos en esa posiciones

        //evitar que los barcos esten unos arribas de otros
    }

}
