using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class notaFinal : MonoBehaviour
{

    public Text txtNota;

    public GameObject ResultadoT1;
    public GameObject RepetirT1;
    public GameObject AvancarT1;

    public static int notaF;
    public static int acertos;

    void Start()
    {
        notaF = PlayerPrefs.GetInt("notaFinalTemp" + temaJogo.idTema.ToString());
        acertos = PlayerPrefs.GetInt("acertosTemp" + temaJogo.idTema.ToString());

        

        if (acertos > responder.questoes / 2)
        {
            Debug.Log("ENTREOU");
            ResultadoT1.SetActive(true);
            ResultadoT1.SetActive(true);
            AvancarT1.SetActive(true);
            RepetirT1.SetActive(false);
            temaJogo.idTema++;
            txtNota.text = "Você foi muito bem no periodo de treinamento, obteve " 
                + acertos.ToString() + " acertos de " + responder.questoes.ToString();
            

        }
        else
        {
            ResultadoT1.SetActive(true);
            AvancarT1.SetActive(false); 
            RepetirT1.SetActive(true);
            Pontuacao.scoreTotalT =- responder.media;
            txtNota.text = "Você precisa se esforçar no periodo de treinamento! obteve "
                + acertos.ToString() + " acertos de " + responder.questoes.ToString();
        }
       
        Debug.Log("acertos" + acertos);
        Pontuacao.notaFinalT = 0;

        
    }

    

    public void jogarNovamente()
    {
        SceneManager.LoadScene("T" + temaJogo.idTema.ToString());
    }
}
