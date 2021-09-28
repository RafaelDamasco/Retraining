using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class temaJogo : MonoBehaviour
{

    public GameObject canvaHighScore;

    public GameObject aviso;

    public GameObject P0;
    public GameObject P1;
    public GameObject P2;

    public GameObject T0;
    public GameObject T1;
    public GameObject T2;

    public GameObject D1;
    public GameObject D2;
    public GameObject D3;



    public Text txtExp;


    public Text txtNomeTema;
    public Text txtNomeProjeto;

    public string[] nomeTema;
    public string[] nomeProjeto;

    private int idAvaliacao;
    public static int idTema;
    public static int idProjeto;


    private int exp;

    public static int aprovadoP;

    public static string playernamestr;
    public Text playername;


    void Start()
    {

            playername.text = playernamestr;
        
        
        if (aprovadoP == 0)
        {
            D1.SetActive(true);
            D2.SetActive(false);
            D3.SetActive(false);

        }
        if (aprovadoP == 1)
        {
            D1.SetActive(false);
            D2.SetActive(true);
            D3.SetActive(false);

        }
        if (aprovadoP == 2)
        {
            D1.SetActive(false);
            D2.SetActive(false);
            D3.SetActive(true);

        }


        if (notaFinal.notaF <= responder.questoes / 2)
        {
            T0.SetActive(true);
            P0.SetActive(false);
            notaFinal.notaF = 0;

            Debug.Log("TIROU MAIS QUE METADE DAS QUESTOES ");
            Debug.Log("aprovadop= " + aprovadoP);

            if (aprovadoP == 1)
            {
                Debug.Log("APROVADO PO ");
                //P0.SetActive(false);
                T0.SetActive(false);
                T1.SetActive(true);
                //P1.SetActive(false);
            }

            if (aprovadoP == 2)
            {
                Debug.Log("APROVADO P1 ");
                //P0.SetActive(false);
                T0.SetActive(false);
                T1.SetActive(false);
                T2.SetActive(true);
                //P1.SetActive(false);
            }
            Pontuacao.scoreTotalT = 0;
            Pontuacao.scoreTotalP = 0;
            Pontuacao.notaFinalT = 0;
            Pontuacao.notaFinalP = 0;

        }

        else if (notaFinal.notaF > responder.questoes / 2)
        {
            T0.SetActive(false);
            P0.SetActive(true);
            notaFinal.notaF = 0;

            if (aprovadoP == 1)
            {
                P0.SetActive(false);
                T0.SetActive(false);
                T1.SetActive(false);
                P1.SetActive(true);
                zerarScore();
            }
            if (aprovadoP == 2)
            {
                P0.SetActive(false);
                P1.SetActive(false);
                P2.SetActive(true);
                zerarScore();
            }

            Debug.Log("NAO TIROU MAIS QUE METADE DAS QUESTOES ");


        }



        //idTema = 0;
        //idProjeto = 0;



        txtNomeTema.text = nomeTema[idTema];
        txtNomeProjeto.text = nomeProjeto[idProjeto];

      
        txtExp.text = "EXP Total:   " + Pontuacao.highScoreP.ToString();

    }

    void Update()
    {
        Debug.Log("script temaJogo");
    }

    void zerarScore()
    {
        Pontuacao.scoreTotalT = 0;
        Pontuacao.scoreTotalP = 0;
        Pontuacao.notaFinalT = 0;
        Pontuacao.notaFinalP = 0;
    }

    public void selecioneTema(int i)
    {
        idTema = i;
        txtNomeTema.text = nomeTema[i];

    }

    public void selecioneProjeto(int i)
    {
        idProjeto = i;
        txtNomeProjeto.text = nomeProjeto[i];

    }


    public void jogar()
    {
        SceneManager.LoadScene("T" + idTema.ToString());

    }

    public void avaliar()
    {
        SceneManager.LoadScene("P" + idProjeto.ToString());

    }
    public void finalizarJogo()
    {
        aviso.SetActive(false);
        canvaHighScore.SetActive(true);
        Debug.Log(playernamestr);
        Debug.Log(Pontuacao.highScoreP);
        
        Invoke("Upload",1f);        
    }
    public void Upload()
    {
        HighScores.UploadScore(playernamestr, Pontuacao.highScoreP);
    }

}
