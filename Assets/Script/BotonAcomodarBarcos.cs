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
        StartCoroutine("PosicionarBarcoAleatoriamente");
        
        // listaDeNumeros.Clear();
        // cantidadNumeros =  barcos.Length;
        // rangoNumeros = cuadriculas.Length;
        // int[] numeros = CrearNumerosAleatoriosSinRepetir(barcos.Length,cuadriculas.Length);

        // foreach (int i in numeros)
        // {
        //     listaDeNumeros.Add(i);
        // }

        


        /////////////////////////////////////////////////////////////////////////////////
        // for (int i = 0; i < barcos.Length; i++)
        // {

        //     barcos[i].transform.position = new Vector3(
        //         cuadriculas[numeros[i]].transform.position.x,
        //         barcos[i].transform.position.y,
        //         cuadriculas[numeros[i]].transform.position.z
        //     );
        //     int rotacionAleatorio = Random.Range(1,4);
        //     barcos[i].transform.Rotate(new Vector3(0,0,90 * rotacionAleatorio),Space.Self);

        //     /////////////////////////////////////////////////////////////
        //     ///Repito hasta que todo este en la grilla/////////////////
        //     while(
        //         !_GameHandler.inGrid
        //             (
        //                 barcos[i].GetComponent<MoverYrotar>().lengthBarco,
        //                 barcos[i].GetComponent<MoverYrotar>().lenghtBarcoDerecha,
        //                 barcos[i].GetComponent<MoverYrotar>().lenghtBarcoIzquierda,
        //                 barcos[i].GetComponent<MoverYrotar>().direccion,
        //                 barcos[i].GetComponent<MoverYrotar>().X_posicion_imaginaria,
        //                 barcos[i].GetComponent<MoverYrotar>().Y_posicion_imaginaria
        //             )
        //         )
        //     {   
        //         int[] numerosNuevosAleatorios = CrearNumerosAleatoriosSinRepetir(barcos.Length,cuadriculas.Length);
        //         int rotacionAleatorioDos = Random.Range(1,4);
        //         barcos[i].transform.Rotate(new Vector3(0,0,90 * rotacionAleatorioDos),Space.Self);    

        //         barcos[i].transform.position = new Vector3(
        //             cuadriculas[numerosNuevosAleatorios[i]].transform.position.x,
        //             barcos[i].transform.position.y,
        //             cuadriculas[numerosNuevosAleatorios[i]].transform.position.z
        //         );
        //     }
            
        //     ////////////////////////////////////////////////////////
            
        // }
        ////////////////////////////////////////////////////////////////////////////////
    }

    //prueba posicionar el barco mientras no este afuera
    IEnumerator PosicionarBarcoAleatoriamente()
    {
        this.GetComponent<Button>().interactable = false;//no puedo tocar el boton
        // bool estaEngrilla = false;
        // bool estaColsionandoConbarco = false;
        
        // for (int i = 0; i < barcos.Length; i++)
        // {
            GameObject barcoActual = barcos[barcoEleguido];

            //tiro primera vez
            int[] numeros = _GameHandler.CrearNumerosAleatoriosSinRepetir(barcos.Length,cuadriculas.Length);
                        
            barcoActual.GetComponent<MoverYrotar>().Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[numeros[0]]);
            
            
            yield return new WaitForSeconds(0.5f);//prueba luego borrar

            //repetir sino esta en grilla y si esta colisionando con otro barco
            // while (!estaEngrilla && estaColsionandoConbarco)
            while (!barcoActual.GetComponent<MoverYrotar>().EstaEngrilla_Y_NoEstaColisionandoConOtroBarco())
            {
                //Sino esta en la grilla y sino esta chocando con otro barco repetir hasta que no se cumpla
                // if(!barcoActual.GetComponent<MoverYrotar>().EstaDentroDeLagrilla() && barcoActual.GetComponent<MoverYrotar>().EstaChocandoContraOtroBarco())
                // if(barcoActual.GetComponent<MoverYrotar>().EstaEngrilla_Y_NoEstaColisionandoConOtroBarco())
                // {    
                print("el barco no esta en la grilla");
                numeros = _GameHandler.CrearNumerosAleatoriosSinRepetir( barcos.Length, cuadriculas.Length );
                    
                    //mover y rotar barcos automaticamente
                barcoActual.GetComponent<MoverYrotar>().Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[numeros[0]]);
                yield return new WaitForSeconds(0.5f);//prueba luego borrar
                // }
                // else
                // {
                //     estaEngrilla = true;
                //     estaColsionandoConbarco = false;
                //     // yield return null;
                // }
                print("termino el bucle esta en grilla");
            }      
        // }

        this.GetComponent<Button>().interactable = true;//puedo volver a tocar el boton
        
    }

}
