using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonAcomodarBarcos : MonoBehaviour
{
    GameObject[] barcos;
    GameObject[] cuadriculas;

    GameHandler _GameHandler;

    public int barcoEleguido = 3;

    public int cantidadNumeros = 5;
    public int rangoNumeros = 10;
    public List<int> listaDeNumeros = new List<int>();//para listar los barcos


    private void Awake()
    {
        barcos = GameObject.FindGameObjectsWithTag("boat");//busca todos los barcos
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadricula");
        _GameHandler = FindObjectOfType<GameHandler>();
        // listaDeNumeros = new int[cantidadNumerosAletorios];
    }

    public void AutoBoton()
    {
        StartCoroutine("PosicionarBarcoAleatoriamente");
    }

    //prueba posicionar el barco mientras no este afuera
    IEnumerator PosicionarBarcoAleatoriamente()
    {
        this.GetComponent<Button>().interactable = false;//no puedo tocar el boton
        
        for (int i = 0; i < 5; i++)//Solo funciona hasta 3 tengo..No funciona portaAviones, ni submarino
        {
            GameObject barcoActual = barcos[i];

            StartCoroutine(barcoActual.GetComponent<MoverYrotar>().PosicionarBarcoAleatoriamenteSinColisionarConOtros());    
        }
        yield return new WaitForSeconds(0.5f);
        this.GetComponent<Button>().interactable = true;//puedo volver a tocar el boton
        
    }

}
