using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonAcomodarBarcos : MonoBehaviour
{
     GameObject[] barcos;
    GameObject[] cuadriculas;

    GameHandler _GameHandler;


    public int cantidadNumeros = 5;
    public int rangoNumeros = 10;
    public List<int> listaDeNumeros = new List<int>();

    private void Awake()
    {
        barcos = GameObject.FindGameObjectsWithTag("boat");//busca todos los barcos
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadricula");
        _GameHandler = FindObjectOfType<GameHandler>();
        // listaDeNumeros = new int[cantidadNumerosAletorios];
    }

    // // // //para acomodar los barcos de forma aleatoria
        // public void AcomodarBarcosDeformaAleatoria()
        // {
            
        //     int g = 0;
        //     int numeroAleatorio = 0;
            
        //     //tendria que tomar aleatoriamente 5 posiciones de la grilla
        //     for (int i = 0; i < cantidadNumerosAletorios; i++)
        //     {
        //         g = i;
        //         numeroAleatorio = Random.Range(0,cuadriculas.Length);
        //         // listaDeNumeros[i] = numeroAleatorio;
        //         listaDeNumeros.Add(numeroAleatorio);

        //         for (int d=0; d<=g ;d++)
        //         {
        //             if(numeroAleatorio == listaDeNumeros[d])  //verifica si el numero se repite 
        //             { 
        //                 g= g - g ;
        //                 i= i - 1 ;
        //             }
                    
        //             while((g==i)&&(numeroAleatorio!=listaDeNumeros[d]) && (d==i)) //verifica que sea el ultimo
        //             {
        //                 listaDeNumeros[i]=numeroAleatorio;                           //llenamos el vector
        //             }
            
        //         }

        //     foreach (var m in listaDeNumeros)
        //     {
        //         print("el numero es: " + m);
        //     }
        //     for (int a = 0; a < listaDeNumerosQueHay.Length; a++)
        //     {
        //         listaDeNumerosQueHay[a] = listaDeNumeros[a];
        //     } 
        
        //     //posicionar los barcos en esa posiciones

        //     //evitar que los barcos esten unos arribas de otros
        // }
    // }
    // para acomodar los barcos de forma aleatoria

    public void AcomodarBarcosDeformaAleatoria()
    {
        listaDeNumeros.Clear();
        cantidadNumeros =  barcos.Length;
        rangoNumeros = cuadriculas.Length;
        int[] numeros = CrearNumerosAleatoriosSinRepetir(barcos.Length,cuadriculas.Length);

        foreach (int i in numeros)
        {
            listaDeNumeros.Add(i);
        }
        for (int i = 0; i < barcos.Length; i++)
        {

            barcos[i].transform.position = new Vector3(
                cuadriculas[numeros[i]].transform.position.x,
                barcos[i].transform.position.y,
                cuadriculas[numeros[i]].transform.position.z
            );
            int rotacionAleatorio = Random.Range(1,4);
            barcos[i].transform.Rotate(new Vector3(0,0,90 * rotacionAleatorio),Space.Self);

            /////////////////////////////////////////////////////////////
            ///Repito hasta que todo este en la grilla/////////////////
            while(
                !_GameHandler.inGrid
                    (
                        barcos[i].GetComponent<MoverYrotar>().lengthBarco,
                        barcos[i].GetComponent<MoverYrotar>().lenghtBarcoDerecha,
                        barcos[i].GetComponent<MoverYrotar>().lenghtBarcoIzquierda,
                        barcos[i].GetComponent<MoverYrotar>().direccion,
                        barcos[i].GetComponent<MoverYrotar>().X_posicion_imaginaria,
                        barcos[i].GetComponent<MoverYrotar>().Y_posicion_imaginaria
                    )
                )
            {   
                int[] numerosNuevosAleatorios = CrearNumerosAleatoriosSinRepetir(barcos.Length,cuadriculas.Length);
                int rotacionAleatorioDos = Random.Range(1,4);
                barcos[i].transform.Rotate(new Vector3(0,0,90 * rotacionAleatorioDos),Space.Self);    

                barcos[i].transform.position = new Vector3(
                    cuadriculas[numerosNuevosAleatorios[i]].transform.position.x,
                    barcos[i].transform.position.y,
                    cuadriculas[numerosNuevosAleatorios[i]].transform.position.z
                );
            }
            
            ////////////////////////////////////////////////////////
            
        }
    }

    public int[] CrearNumerosAleatoriosSinRepetir( int cantidadNumerosAletorios = 5, int rangoDeNumerosAleatorios = 10)
    {
        
        int numeroAleatorio = 0;//variable que va a guardar el numero aleatorio
        List<int> listaDeNumerosAleatorios = new List<int>();//nueva lista
       
        //While hasta que se complete la cantida de números aleatorios sin repetir
        while(listaDeNumerosAleatorios.Count < cantidadNumerosAletorios)
        {
            numeroAleatorio = Random.Range(0,rangoDeNumerosAleatorios); //numero aleatorio en un rango por parametro

            if (!listaDeNumerosAleatorios.Contains(numeroAleatorio) )//si ese número NO esta
            {
                listaDeNumerosAleatorios.Add(numeroAleatorio);//Agrego a la lista
            }        
        }
        
        int[] numerosParaRetornarAleatorios = new int[cantidadNumerosAletorios];//creo el arreglo provisorio
        for (int i = 0; i < listaDeNumerosAleatorios.Count; i++) //mientras el tamaña sea menos a la lista
        {
            numerosParaRetornarAleatorios[i] = listaDeNumerosAleatorios[i];//guardo todos los valores
        }

        return numerosParaRetornarAleatorios; //retorno la lista de números    
    }



    
    // public void AcomodarBarcosFormaAleatoria()
    // {
        
    //     int numeroAleatorio = 0;//variable que va a guardar el numero aleatorio

    //     listaDeNumeros.Clear();//borro todo lo de la lista guardado antereriormente
       
    //     List<GameObject> posicionesNuevas = new List<GameObject>();
    //     posicionesNuevas.Clear();

    //     //While hasta que se complete la cantida de números aleatorios sin repetir
    //     while(posicionesNuevas.Count < barcos.Length)
    //     {
    //         numeroAleatorio = Random.Range(0,cuadriculas.Length); //numero aleatorio en un rango

    //         if(!posicionesNuevas.Contains(posicionesNuevas[numeroAleatorio]))//si ese número NO esta
    //         {
    //             listaDeNumeros.Add(numeroAleatorio);//Agrego a la lista
    //         }        
    //     }

    //     //acomodo los barcos con las posiciones aleatorias
    //     int contador = 0;
    //     foreach (GameObject i in posicionesNuevas)
    //     {
    //         barcos[contador].transform.position = i.transform.position;
    //     }  
        
    // }
}
