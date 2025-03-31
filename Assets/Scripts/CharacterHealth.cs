using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    /*
     * Falta HACER para este lunes enemigos ROJO (El enemigo bomba - Este mismo lo que hace es tirar bombas al jugador haciendolas explotar a los 2 o 3 segundos de 
     * lanzarla, poner animacion de explosione y sonido, el enemigo lo que hace es moverse persiguiendo al jugador pero al acercarse al enemigo el mismo se alenta para que 
     * sea mas manejable para el jugador -)
     * Hay que hacer el menu de OPCIONES el cual tiene que tener AYUDA (El cual le explica el objetivo de la mision) - CONFIG (Para poder editar con las teclas que te moves 
     * pegas etc.) - VOLVER (Volver para atras) - 
    */
    private GameManager gameManager;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] private HealthBar healthBar;
    public Text textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        //Comienzo a contar el tiempo transcurrido
        //textoTiempo.text = "Tiempo: 00:00";

        //Capturo el script de GameManager
        //gameManager = FindObjectOfType<GameManager>();

        health = maxHealth;
        healthBar.InicialiteHealthBar(health);
    }

    public void Damaged(float Damage)
    {
        //Recibio daño se lo descuento a la vida
        health -= Damage;
        //Actualizo la vida acutal
        healthBar.ChangActualHealth(health);

        if (health <= 0)
        {
            //Destruyo al personaje ya que se quedo sin vida
            Destroy(gameObject);
        }
    }
   
    public void Heal(float HealPlayer)
    {
        //Verifico si el jugador tiene mas de la vida maxima
        if ((health + HealPlayer) > maxHealth) 
        {
            health = maxHealth;
            Debug.Log("El jugador ya tiene la vida al maximo");
        }
        //En caso de no tener la vida maxima aca se puede curar
        else
        {
            Debug.Log("El jugador se pudo curar");
        }
    }

    void Update()
    {
       /*
        //Escribo tiempo transcurrido (si no se ha acabado el juego)
        if (gameManager.isJuego)
        {
            textoTiempo.text = "Tiempo: " + formatearTiempo();
        }
        //Si entra aca significa que el juego ya termino
        else
        {
            Debug.Log("El juego ya acabo");
        }
       */
    }

    //Formatear tiempo (publico xq luego se tiene que utilizar)
    public string formatearTiempo()
    {

        //Añade el intervalo de tiempo a la variable de tiempo
        if (gameManager.isJuego)
        {
            gameManager.tiempo += Time.deltaTime;
        }

        //Reseteo los minutos y los segundos de las variables
        string minutos = Mathf.Floor(gameManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(gameManager.tiempo % 60).ToString("00");

        //Devuelvo el string formateado con : como separador
        return minutos + ":" + segundos;

    }
}
