using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverYrotar : MonoBehaviour
{

    GameHandler _GameHandler;
    GameObject[] cuadriculas;

    public int lengthBarco;//tamaño de arriba abajo del barco

    public int lenghtBarcoDerecha;//tamaño hacia la derecha del barco

    public int lenghtBarcoIzquierda;//tamaño hacia la izquierda del barco

    public int direccion = 0;

    [SerializeField]
    public int X_posicion_imaginaria = 0;
    [SerializeField]
    public int Y_posicion_imaginaria = 0;


    public Vector3 startPos;//para cambiar la posición inicial

    public BoxCollider[] _BoxCollider;
    public BoxCollider[] overlappers;
    public LayerMask isOverlapper;



    public void Awake() {
        _GameHandler = FindObjectOfType<GameHandler>();
        cuadriculas = GameObject.FindGameObjectsWithTag("cuadricula");
    }

    private void Start() {
    }


    /// <summary>Rota 90 grados el barco</summary>
    public void RotarBarco()
    {
        transform.Rotate(new Vector3(0,0,90),Space.Self);
        direccion += 1;//relacionado a los movimientos imaginorios para rotar el barco
        if(direccion > 3)//relacionado a los movimientos imaginorios para rotar el barco
        {
            direccion = 0;//relacionado a los movimientos imaginorios para rotar el barco
        }
    }


    /// <summary>Mueve el barco usando la cuadricula y devuelve la posición de la grilla</summary>
    public void MoverBarcosPorCuadricula()
    {
        //la posición imaginaria de la grilla en el eje "X" y en el eje "Y"..."El eje Y es el Z" nose si corrija ese detalle,no me molesta
        X_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_X_posicion;
        Y_posicion_imaginaria = _GameHandler.grillaActual.GetComponent<CuadriculaDeColision>().Grilla_Y_posicion;


        //si esta adentro de la grilla
        if ( _GameHandler.inGrid(lengthBarco, lenghtBarcoDerecha , lenghtBarcoIzquierda , direccion ,X_posicion_imaginaria,Y_posicion_imaginaria) )
        {
            print("tendria que moverse");
            // muevo el barco a la posicion de la grilla
            this.gameObject.transform.position = new Vector3(
                _GameHandler.grillaActual.transform.position.x,
                this.gameObject.transform.position.y,
                _GameHandler.grillaActual.transform.position.z
            );

        }
    }


    /// <summary>mueve y rota los barcos de forma aleatoría en una posición de la cuadricula</summary>
    public GameObject Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(GameObject cuadricula)
    {
                    
        this.gameObject.transform.position = new Vector3(
            cuadricula.transform.position.x,
            this.gameObject.transform.position.y,
            cuadricula.transform.position.z);
        
        X_posicion_imaginaria = cuadricula.GetComponent<CuadriculaDeColision>().Grilla_X_posicion;
        Y_posicion_imaginaria = cuadricula.GetComponent<CuadriculaDeColision>().Grilla_Y_posicion;

        RotarBarco();

        return this.gameObject;
    }
    

    /// <summary>Para saber si el barco esta dentro de la grilla</summary>
    public bool EstaDentroDeLagrilla()
    {
        if (_GameHandler.inGrid(lengthBarco, lenghtBarcoDerecha , lenghtBarcoIzquierda , direccion ,X_posicion_imaginaria,Y_posicion_imaginaria) )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    /// <summary>Para saber si el barco esta chocando con otros barcos  "BOOLEANO"</summary>
    public bool EstaChocandoContraOtroBarco()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        bool estaColisionando = false;

        if(overlappers != null)
		{
			for (int i = 0; i < overlappers.Length; i++)
			{
                BoxCollider box = overlappers[i];
                Collider[] collisions = Physics.OverlapBox(box.transform.position, box.bounds.size / 2, Quaternion.identity, isOverlapper);
                if (collisions.Length > 1)
                {
                    Debug.Log("Hay Overlap");
                    // transform.localPosition = startPos;
                    estaColisionando = true;
                    break;
                }
                else
                {
                    estaColisionando = false;
                    // puedoRotar = true;
                    Debug.Log("No hay overlap");
                }
			}
		}
        return estaColisionando;
    }


    /// <summary>Para saber si el barco "esta dentro" de la grilla y "NO" esta colisionando con un barco en simultaneo</summary>
    public bool EstaEngrilla_Y_NoEstaColisionandoConOtroBarco()
    {
        if(EstaDentroDeLagrilla() && !EstaChocandoContraOtroBarco())
        {
            return true;
            
        }
        if(EstaDentroDeLagrilla() && EstaChocandoContraOtroBarco())
        {
            return false;
        }

        return false;

    }

    /// <summary>Posiciona el barco aleatoriamente en un lugar de la grilla sin colisionar con otros barcos</summary>
    public IEnumerator PosicionarBarcoAleatoriamenteSinColisionarConOtros()
    {   
        //tiro primera vez           
        Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[Random.Range(0,cuadriculas.Length - 1)]);
        // yield return new WaitForSeconds(0.01f);//prueba luego borrar
        yield return new WaitForSeconds(0.1f);//prueba luego borrar

        //repetir sino esta en grilla y si esta colisionando con otro barco
        while (!EstaEngrilla_Y_NoEstaColisionandoConOtroBarco())
        { 
            print("el barco no esta en la grilla");
            //mover y rotar barcos automaticamente
            Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[Random.Range(0,cuadriculas.Length - 1)]);
            // yield return new WaitForSeconds(0.01f);//prueba luego borrar
             yield return new WaitForSeconds(0.1f);//prueba luego borrar
            // yield return null;
        }      
    }

    // public void PosicionarBarcoAleatoriamenteSinColisionarConOtros()
    // {   
    //     //tiro primera vez           
    //     Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[Random.Range(0,cuadriculas.Length - 1)]);

    //     //repetir sino esta en grilla y si esta colisionando con otro barco
    //     while (!EstaEngrilla_Y_NoEstaColisionandoConOtroBarco())
    //     { 
    //         print("el barco no esta en la grilla");
    //         //mover y rotar barcos automaticamente
    //         Mover_Y_Rotar_Barcos_AutomaticamentePorCuadricula(cuadriculas[Random.Range(0,cuadriculas.Length - 1)]);
    //         // yield return null;
    //     }      
    // }



}
