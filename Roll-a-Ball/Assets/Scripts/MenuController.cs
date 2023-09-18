using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // painel que contem o texto de ganhou ou perdeu ao final do jogo
    public GameObject endPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Jogador perde jogo:
    public void LoseGame(){
        // ativando texto
        endPanel.SetActive(true);
        // Exibindo texto de game over
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Game Over!";
    }

    // Jogador ganha jogo:
    public void WinGame(){
        // ativando texto
        endPanel.SetActive(true);
        // Exibindo texto de winner
        endPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "You Win!";
    }

    public void StartGame(){
        // Scena do jogo
        SceneManager.LoadScene(1);
    }

    public void RestartGame(){
        SceneManager.LoadScene(1);
    }
}
