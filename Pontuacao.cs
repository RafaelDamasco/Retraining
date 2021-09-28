using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pontuacao : MonoBehaviour
{
    public static int scoreTotalP;
    public static int scoreTotalT;
    public static int notaFinalT;
    public static int notaFinalP;

    public static int highScoreP;

    void Update()
    {
        Debug.Log("Score de Prova" + scoreTotalP);
        //Debug.Log("Score de Treinamento " + scoreTotalT);
        Debug.Log("Score de Prova Final" + notaFinalP);
        //Debug.Log("Score de Treinamento Final" + notaFinalT);
    }

    public void zerarPontos()
    {

    }

}
