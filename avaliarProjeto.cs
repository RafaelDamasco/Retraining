using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avaliarProjeto : MonoBehaviour
{

    public Text tempoTxt;
    public Text tempoParadoTxt;
    public Text expTxt;

    public Text txtResultadoP0;

    private int idTema;

    public Text pergunta;
    public Text respostaA;
    public Text respostaB;
    public Text respostaC;
    public Text respostaD;
    public Text infoRespostas;

    public Text txtNota;


    public string[] perguntas;      // armazena todas as perguntas
    public string[] alternativaA;   // armazena todas as alternativas A
    public string[] alternativaB;   // armazena todas as alternativas B
    public string[] alternativaC;   // armazena todas as alternativas C
    public string[] alternativaD;   // armazena todas as alternativas D
    public string[] corretas;       // armazena todas as alternativas corretas

    private int idPergunta;

    private int acertos;
    private float questoes;
    public static float media;
    public static int notaFinal;

    public GameObject Resultado;
    public GameObject caixaMsg;


    public GameObject questaofinal1;
    public GameObject questaofinal2;
    public GameObject questaofinal3;
    public GameObject questaofinal4;
    public GameObject questaofinal5;

    public GameObject apagadorfinal;


    void Start()

    {
        CharacterSelectionMenu.tempo = CharacterSelectionMenu.fixedTempo;
        tempoParadoTxt.text = CharacterSelectionMenu.tempo.ToString();
        expTxt.text = CharacterSelectionMenu.exp.ToString();

        //expTxt.text = CharacterSelectionMenu.exp.ToString();

        idTema = 1;    
        idPergunta = 0;
        
        
        questoes = perguntas.Length;
        
        pergunta.text = perguntas[idPergunta];
        respostaA.text = alternativaA[idPergunta];
        respostaB.text = alternativaB[idPergunta];
        respostaC.text = alternativaC[idPergunta];
        respostaD.text = alternativaD[idPergunta];       


    }

    void Update()
    {
        /*Debug.Log("script avaliarProjeto");
        Debug.Log("acertos " + acertos);
        Debug.Log("media " + media);
        Debug.Log("notaFinal " + notaFinal);
        Debug.Log("idTema " + temaJogo.idTema);
        Debug.Log("exp " + CharacterSelectionMenu.exp); */
    }

    public void registrarTempo()
    {
        Debug.Log("tempo " + CharacterSelectionMenu.tempo);
    }

    public void iniciaContagem()
    {
        StartCoroutine("contagemRegressiva");
    }

    IEnumerator contagemRegressiva()
    {
        
        tempoTxt.text = CharacterSelectionMenu.tempo.ToString();
        yield return new WaitForSeconds(1);
        CharacterSelectionMenu.tempo -= 1;

        if(CharacterSelectionMenu.tempo > 0)
        {
            StartCoroutine("contagemRegressiva");

        }
        else
        {
            media = 100 / questoes * acertos; // CALCULA A MEDIA COM BASE NO PERCENTUAL DE ACERTO 
            notaFinal = Mathf.RoundToInt(acertos);
            Pontuacao.notaFinalP += acertos * CharacterSelectionMenu.exp;
            Pontuacao.highScoreP += Pontuacao.notaFinalP;
            //ARREDONDA A NOTA PARA O PROXIMO INTEIRO
            //Debug.Log("nota do multiplicador " + notaFinal);
            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())) // GRAVA NOVO RECORD SE ELE FOR MAIOR QUE O ANTERIOR
            {
                notaFinal = acertos;
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal); //gravado quando bate o record
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
            }

            notaFinal = Mathf.RoundToInt(acertos);
            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal); //sempre sao gravados
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            // temaJogo.idProjeto++;
            // temaJogo.idTema++;

            caixaMsg.SetActive(false);
            Resultado.SetActive(true);

            responder.notaFinal = 0;
            Debug.Log("notaFinal avaliarProjeto " + responder.notaFinal);
            temaJogo.aprovadoP++;
            //idPergunta = 0;
            txtResultadoP0.text = "Parabens você acertou " + media.ToString() +
       "% do projeto e obteve " + Pontuacao.notaFinalP.ToString() + " pontos de experiência";
            notaFinal = 0;
            CharacterSelectionMenu.tempo = CharacterSelectionMenu.fixedTempo;

 
            // O QUE ACONTECE SE O TEMPO ACABAR
        }
    }


    public void resposta(string alternativa)
    {

        if (alternativa == "A")
        {
            if (alternativaA[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalP++;
            }

        }

        else if (alternativa == "B")
        {
            if (alternativaB[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalP++;
            }

        }

        else if (alternativa == "C")
        {
            if (alternativaC[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalP++;
            }

        }

        else if (alternativa == "D")
        {
            if (alternativaD[idPergunta] == corretas[idPergunta])
            {
                acertos += 1;
                Pontuacao.scoreTotalP++;
            }

        }

        proximaPergunta();

    }

    void proximaPergunta()
    {
        idPergunta += 1;

        if (idPergunta <= questoes - 1)
        {

            questaofinal1.SetActive(false);
            questaofinal2.SetActive(false);
            questaofinal3.SetActive(false);
            questaofinal4.SetActive(false);
            questaofinal5.SetActive(false);
            apagadorfinal.SetActive(false);

            pergunta.text = perguntas[idPergunta];
            respostaA.text = alternativaA[idPergunta];
            respostaB.text = alternativaB[idPergunta];
            respostaC.text = alternativaC[idPergunta];
            respostaD.text = alternativaD[idPergunta];

            if (idPergunta == 1)
            {
                questaofinal2.SetActive(true);
                apagadorfinal.SetActive(true);
            }
            if (idPergunta == 2)
            {
                questaofinal3.SetActive(true);
                apagadorfinal.SetActive(true);
            }
            if (idPergunta == 3)
            {

                questaofinal4.SetActive(true);
                apagadorfinal.SetActive(true);

            }
            if (idPergunta == 4)
            {

                questaofinal5.SetActive(true);
                apagadorfinal.SetActive(true);

            }

        }

        else //O QUE FAZER SE ACABOU AS PERGUNTAS
        {
            questaofinal1.SetActive(false);
            questaofinal2.SetActive(false);
            questaofinal3.SetActive(false);
            questaofinal4.SetActive(false);
            questaofinal5.SetActive(false);
            apagadorfinal.SetActive(false);
            //notaFinal = notaFinal * exp;

            media = 100 / questoes * acertos; // CALCULA A MEDIA COM BASE NO PERCENTUAL DE ACERTO 
            notaFinal = Mathf.RoundToInt(acertos);
            Pontuacao.notaFinalP += acertos * CharacterSelectionMenu.exp;
            Pontuacao.highScoreP += Pontuacao.notaFinalP;
                //ARREDONDA A NOTA PARA O PROXIMO INTEIRO
            //Debug.Log("nota do multiplicador " + notaFinal);
            if (notaFinal > PlayerPrefs.GetInt("notaFinal" + idTema.ToString())) // GRAVA NOVO RECORD SE ELE FOR MAIOR QUE O ANTERIOR
            {
                notaFinal = acertos;
                PlayerPrefs.SetInt("notaFinal" + idTema.ToString(), notaFinal); //gravado quando bate o record
                PlayerPrefs.SetInt("acertos" + idTema.ToString(), (int)acertos);
            }
            
            notaFinal = Mathf.RoundToInt(acertos);
            PlayerPrefs.SetInt("notaFinalTemp" + idTema.ToString(), notaFinal); //sempre sao gravados
            PlayerPrefs.SetInt("acertosTemp" + idTema.ToString(), (int)acertos);
            // temaJogo.idProjeto++;
            // temaJogo.idTema++;
           
            caixaMsg.SetActive(false);
            Resultado.SetActive(true);
           
           responder.notaFinal = 0;
            Debug.Log("notaFinal avaliarProjeto " + responder.notaFinal);
            temaJogo.aprovadoP ++;
            //idPergunta = 0;
            txtResultadoP0.text = "Parabens você acertou " + media.ToString() +
       "% do projeto e obteve " + Pontuacao.notaFinalP.ToString() + " pontos de experiência";
            notaFinal = 0;
            CharacterSelectionMenu.tempo = CharacterSelectionMenu.fixedTempo;
            
        }
    }
}
