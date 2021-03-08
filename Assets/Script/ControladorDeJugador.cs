using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeJugador : MonoBehaviour
{
    MoverYrotar _MoverYrotar;

    bool puedoMover = false;


    public BoxCollider[] _BoxCollider;

    //para que los barcos no se choquen
    public BoxCollider[] overlappers;
    public LayerMask isOverlapper;

    int direccion = 0;
  
    Vector3 startPos;

    GameHandler _GameHandler;
    private void Awake() {
        _MoverYrotar = GetComponent<MoverYrotar>();
        _GameHandler = FindObjectOfType<GameHandler>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(puedoMover)//si puedo mover el barco llamo a las funciones para mover tengo que presionar las teclas para que se mueva
        {
            
            
            // print("tendria que moverse");
            foreach (Collider i in _BoxCollider)
            {
                i.enabled = false;
            }
        
            StartCoroutine(MoverSoloUnaVes());
            // _MoverYrotar.moverBarcosPorCuadricula();
            // StartCoroutine(_MoverYrotar.moverBarcosPorCuadricula());

            if(Input.GetMouseButtonDown(1))
            {
                //si esta en la grilla
                if(_GameHandler.inGrid(_MoverYrotar.lengthBarco,_MoverYrotar.lenghtBarcoDerecha,_MoverYrotar.lenghtBarcoIzquierda, (_MoverYrotar.direccion + 1) % 4,_MoverYrotar.X_posicion_imaginaria,_MoverYrotar.Y_posicion_imaginaria))
                {
                    //puedo rotar
                    _MoverYrotar.RotarBarco();
                }
            }

            if(Input.GetMouseButtonUp(0))
            {
                DejarDeMover();
            }

 
        }
        // if (Input.GetButtonDown("Fire1"))
        // {
        //     Ray ray;
        //     RaycastHit rayHit;
        //     float rayLength = 100f;

        //     //어디를 터치했느냐
        //     ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //     if(Physics.Raycast(ray, out rayHit, rayLength))
        //     {
        //         //배를 터치했다면
        //         if (rayHit.transform.gameObject.tag == "boat")
        //         {
        //             print("Estoy arriba del BARCO " + rayHit.transform.gameObject.name);
        //             //배의 위치 이동 및 회전을 담당하는 코루틴 호출
        //             // StartCoroutine(MoverSoloUnaVes());
        //             puedoMover = true;
        //         }
        //         if (rayHit.transform.gameObject.tag == "cuadricula")
        //         {
        //              print("Estoy arriba de la GRILLA " + rayHit.transform.gameObject.name);
        //             _GameHandler.grillaActual = rayHit.transform.gameObject;
        //         }
        //     }
        // }
    }

    private IEnumerator MoverSoloUnaVes()
    {
        _MoverYrotar.moverBarcosPorCuadricula();
        yield return null;
    }

    private void OnMouseOver()//si el mouse esta arriba de la colision
    {   
        if(Input.GetMouseButtonDown(0))
        {
            startPos = transform.localPosition;
            puedoMover = true;//puedo mover
        }

    }


    void DejarDeMover()//tengo que usar una corrutina para esperar un segundo sino se presiona el boton inmediatamente y hay un error de sincronización de botones
    {
        puedoMover = false;
        foreach (Collider i in _BoxCollider)
        {
            i.enabled = true;
        }

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
                    puedoMover = true;
                }
                else
                {
                    puedoMover = false;
                    // puedoRotar = true;
                    Debug.Log("No hay overlap");
                }
			}
		}
        // print("Ahora tendria que dejar de moverse");

    }
    

    
}
