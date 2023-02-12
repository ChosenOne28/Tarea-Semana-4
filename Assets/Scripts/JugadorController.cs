using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class JugadorController : MonoBehaviour {

	//Declaro variable RigidBody que luego asociaremos a nuestro Jugador
	private Rigidbody rb;

	//inicializo el contador de coleccionables recogidos
	private int contador;

	//inicializo variables para los textos
	public Text TextoContador,TextoGanar;

	//Declaro la variable publica velocidad para poder modificarla desde la inspector window
	public float velocidad;

	

	// Use this for initialization
	void Start () {
		
		//Capturo esa variable al iniciar juego
		rb=GetComponent<Rigidbody>();

		//inicio el contador en 0
		contador=0;
		
		//Actualizo el contador por primera vez
		setTextoContador ();

		//Inicio el texto de ganar vacio
		TextoGanar.text="";

		//Boton volver oculto
		//BTNVolver.hide();
	}
	
	// Para que se sinconice con los frames de fisica del motor
	void FixedUpdate () {
		
		// Estas variables nos capturn el movimiento en horizontal y vertical de nuestro teclado
		float movimientoH = Input.GetAxis("Horizontal");
		float movimientoV = Input.GetAxis("Vertical");

		//Un vector 3 es un trio de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento
		Vector3 movimiento = new Vector3(movimientoH,0.0f,movimientoV);

		//Asigno ese movimiento o desplazamiento a mi RigidBody
		rb.AddForce(movimiento * velocidad);
	
	}

	//se ejecuta al entrar a un objeto con la opcion isTrigger seleccionada
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Coleccionable"))
		{
			//desactivo el objeto
			other.gameObject.SetActive(false);

			//incremento el contador en uno(tambien se puede hacer contador++)
			contador= contador+1;

			//Actualizo el texto del contador
			setTextoContador();
		}
	}

	public float delay = 5f;

	//Actualizo el texto del contador (o muestro el de ganar si las ha cogido todas)
	void setTextoContador(){
		TextoContador.text="Contador:"+contador.ToString();
		if(contador >= 12) {
			TextoGanar.text="Ganaste!!";

			//añadimos el contador para cambiar escena
			Invoke("CargarEscena", delay);

		}
	}
	
	void CargarEscena(){
		SceneManager.LoadScene("Finjuego");
	}
}
