using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float speed = 0;
    public TextMeshProUGUI countText;
    public Transform respawnPoint;
    public MenuController menuController;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText(){
        countText.text = "Count: " + count.ToString();
        if(count >= 12){
            menuController.WinGame();
        }
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }

    private void OnCollisionEnter(Collision collision){
        // vendo se ouve colissao com enemy
        if(collision.gameObject.CompareTag("Enemy")){
            // Jogo acaba quando for pego
            EndGame();
        }
    }

    // Quando jogador toca em enemy volta para certa possicao
    void Respawn(){
        // tirando velocidade do player
        rb.velocity = Vector3.zero; //x=0, y=0, z=0
        // tirando velocidade angular do player
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        // Colocando em posicao inicial
        transform.position = respawnPoint.position;
    }

    // Funacao de END GAME
    void EndGame(){
        // Chamando a funcao de texto game over
        menuController.LoseGame();
        // jogar desaparece quando acaba
        gameObject.SetActive(false);
    }
}
