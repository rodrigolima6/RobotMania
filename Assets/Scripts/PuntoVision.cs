using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Tobii.Gaming;

public class PuntoVision : MonoBehaviour
{   
    

    private Image imagenPunto; 
    private Vector2 puntoFiltrado = Vector2.zero;   
    [SerializeField] private RectTransform canvasRect; 
    
    private Vector2 posicioEnPantalla; 
    public Vector2 PosicionEnPantalla{
        get {
             return this.posicioEnPantalla; 
        }
    }
   

    void Awake()
    {
        // crear referencias
        imagenPunto = GetComponent<Image>();       

    }

    void Update()
    {

               

        GazePoint gazePoint = TobiiAPI.GetGazePoint();

		if (gazePoint.IsValid)
		{
			Vector2 posicionGaze = gazePoint.Screen;	
            puntoFiltrado = Vector2.Lerp(puntoFiltrado, posicionGaze, 0.5f);
			Vector2 posicionEntera = new Vector2(
                Mathf.RoundToInt(puntoFiltrado.x), 
                Mathf.RoundToInt(puntoFiltrado.y)
            );

            Debug.Log(posicionEntera); 

            // posicionamos el punto. Debido al punto de pivote y configuracion
            // del canvas, podemos utilizar directamente las coordenadas en 
            // espacio de pantalla para dibujar en el canvas la UI del punto
            imagenPunto.GetComponent<RectTransform>().anchoredPosition = posicionEntera; // posicionEnElCanvas; 
            posicioEnPantalla = posicionEntera; 
			
		} 
      


    }
   
}
