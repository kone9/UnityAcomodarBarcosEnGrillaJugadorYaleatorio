using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAcomodarAutomaticamente : MonoBehaviour
{
    
    GameObject[] barcos;
    GameObject[] cuadriculas;


    public int cantidadNumerosAletorios = 5;
    public List<int> listaDeNumeros = new List<int>();
    public int[] listaDeNumerosQueHay = new int[5];//lista de números aleatorios

    private void Awake()
    {
        barcos = GameObject.FindGameObjectsWithTag("boat");//busca todos los barcos
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadricula");
        // listaDeNumeros = new int[cantidadNumerosAletorios];
    }

    //para acomodar los barcos de forma aleatoria
        // // public void AcomodarBarcosDeformaAleatoria()
        // // {
            
        // //     int g = 0;
        // //     int numeroAleatorio = 0;
            
        // //     //tendria que tomar aleatoriamente 5 posiciones de la grilla
        // //     for (int i = 0; i < cantidadNumerosAletorios; i++)
        // //     {
        // //         g = i;
        // //         numeroAleatorio = Random.Range(0,cuadriculas.Length);
        // //         // listaDeNumeros[i] = numeroAleatorio;
        // //         listaDeNumeros.Add(numeroAleatorio);

        // //         for (int d=0; d<=g ;d++)
        // //         {
        // //             if(numeroAleatorio == listaDeNumeros[d])  //verifica si el numero se repite 
        // //             { 
        // //                 g= g - g ;
        // //                 i= i - 1 ;
        // //             }
                    
        // //             while((g==i)&&(numeroAleatorio!=listaDeNumeros[d]) && (d==i)) //verifica que sea el ultimo
        // //             {
        // //                 listaDeNumeros[i]=numeroAleatorio;                           //llenamos el vector
        // //             }
            
        // //         }

        // //     foreach (var m in listaDeNumeros)
        // //     {
        // //         print("el numero es: " + m);
        // //     }
        // //     for (int a = 0; a < listaDeNumerosQueHay.Length; a++)
        // //     {
        // //         listaDeNumerosQueHay[a] = listaDeNumeros[a];
        // //     } 
        
        // //     //posicionar los barcos en esa posiciones

        // //     //evitar que los barcos esten unos arribas de otros
        // // }
    // // }
    //para acomodar los barcos de forma aleatoria

    public void AcomodarBarcosDeformaAleatoria()
    {
        int numeroAleatorio = 0;
        listaDeNumeros.Clear();
        //tendria que tomar aleatoriamente 5 posiciones de la grilla
        for (int i = 0; i < cantidadNumerosAletorios; i++)
        {
            // numeroAleatorio = Random.Range(0,cuadriculas.Length);
            numeroAleatorio = Random.Range(0,10);
            // listaDeNumeros[i] = numeroAleatorio;
            listaDeNumeros.Add(numeroAleatorio);
        }  
    }

}
