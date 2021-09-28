using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelectionMenu : MonoBehaviour
{

    public GameObject[] playerObjects;
    public static int selectedCharacter = 0;

    public string inicioJogo = "InicioJogo";

    public string gameScene = "Character Selection Scene";

    public static string selectedCharacterDataName = "SelectedCharacter";

    public string[] nomes; 

    public static int fixedTempo;
    public static int tempo;
    public static int exp;

    public Button iniciarJogo;
    public InputField playerName;
        

    void Start()
    {

        playerName.characterLimit = 11;

        HideAllCharacters();

        selectedCharacter = PlayerPrefs.GetInt(selectedCharacterDataName, 0);

        playerObjects[selectedCharacter].SetActive(true);       


    }
    // Updates button's text while user is typing
    public void gerarNome()
    {
        playerName.text = nomes[Random.Range(0, nomes.Length)];
        iniciarJogo.interactable = true;
    }

  
    void Update()
    {

        if (playerName.text == "")
        {
            iniciarJogo.interactable = false;
        }
        

    }
    
    private void HideAllCharacters()
    {
        foreach (GameObject g in playerObjects)
        {
            g.SetActive(false);
        }
    }

    public void NextCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter >= playerObjects.Length)
        {
            selectedCharacter = 0;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        playerObjects[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter = playerObjects.Length - 1;
        }
        playerObjects[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {

        temaJogo.playernamestr = playerName.text;

        if (selectedCharacter == 0) //COMUNICATIVO
        {
            fixedTempo = 180;
            tempo = 180;
            exp = 17;
        }

        else if (selectedCharacter == 1) //PONDERADO
        {
            fixedTempo = 120;
            tempo = 120;
            exp = 18;
        }
        else if (selectedCharacter == 2) //FOCADO
        {
            fixedTempo = 60;
            tempo = 60;
            exp = 19;
        }

        PlayerPrefs.SetInt(selectedCharacterDataName, selectedCharacter);
        SceneManager.LoadScene(inicioJogo);

    }
}
