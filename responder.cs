using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class responder : MonoBehaviour
{

    public string resultadoT0 = "ResultadoT0";

    //public GameObject ResultadoT1;
    public GameObject T1;
    //public GameObject Avan�ar;
    //public GameObject OK;

    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;



    //IMAGENS DAS QUESTOES 

    public GameObject questao4;
    public GameObject questao5;
    public GameObject questao6;
    public GameObject questao7;

    public GameObject apagador;










    public Text txtNota;


    public string[] perguntas;      // armazena todas as perguntas
    public string[] alternativaA;   // armazena todas as alternativas A
    public string[] alternativaB;   // armazena todas as alternativas B
    public string[] alternativaC;   // armazena todas as alternativas C
    public string[] alternativaD;   // armazena todas as alternativas D
    public string[] corretas;       // armazena todas as alternativas corretas

    private int idPergunta;

    public static int acertos;
    public static int questoes;
    public static int media;
    public static int notaFinal;

    public int idResultado = temaJogo.idTema;
    
    void Start()
    {
        
        idTema = 1;
        idPergunta = 0;
        acertos = 0;


        questoes = perguntas.Length; //QUANTAS QUESTOES TEM MEU TEMA?

        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];

    }
    void Update()
    {
        Debug.Log("script responder");
    }

    public void resposta (string alternativa)
    {
        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalT++;
            }
                 
        }

        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalT++;
            }

        }

        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalT++;
            }

        }

        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalT++;
            }

        }
      
        proximaPergunta();
        
    }

    void proximaPergunta ()
    {
        idPergunta += 1;

        if (idPergunta <= (questoes - 1))
        {
            questao4.SetActive(false);
            questao5.SetActive(false);
            questao6.SetActive(false);
            questao7.SetActive(false);
            apagador.SetActive(false);
            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            if (idPergunta == 3)
            {
                questao4.SetActive(true);
                apagador.SetActive(true);
            }
            if (idPergunta == 5)
            {
                questao5.SetActive(true);
                apagador.SetActive(true);
            }
            if (idPergunta == 6)
            {
                questao6.SetActive(true);
                apagador.SetActive(true);
            }
            if (idPergunta == 7)
            {
                questao7.SetActive(true);
                
            }



        }

        else //O QUE FAZER SE ACABOU AS PERGUNTAS
        {
            
            media = 10 * (acertos / questoes); // CALCULA A MEDIA COM BASE NO PERCENTUAL DE ACERTO 
            Pontuacao.notaFinalT += acertos * CharacterSelectionMenu.exp; //ARREDONDA A NOTA PARA O PROXIMO INTEIRO
            
           // notaFinal += Pontuacao.scoreTotalT;

            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())) // GRAVA NOVO RECORD SE ELE FOR MAIOR QUE O ANTERIOR
            {
                PlayerPrefs.SetInt("notaFinal" + temaJogo.idTema.ToString(), acertos); //gravado quando bate o record
                PlayerPrefs.SetInt("acertos" + temaJogo.idTema.ToString(), (int)acertos);
            }

            PlayerPrefs.SetInt("notaFinalTemp" + temaJogo.idTema.ToString(), acertos); //sempre sao gravados
            PlayerPrefs.SetInt("acertosTemp" + temaJogo.idTema.ToString(), (int)acertos);

            Debug.Log("acertos teste " + acertos);

            Debug.Log("notaFinal responder " + notaFinal);

            avaliarProjeto.notaFinal = 0;
            
            acertos = 0;

            SceneManager.LoadScene("ResultadoT" + temaJogo.idTema.ToString());

        }
    }
}
