using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characterselection : MonoBehaviour
{

    public int SelectedCharacterNum = 0;

   
    public void SelectCharacter(int CharacterNum)
    {
        SelectedCharacterNum = CharacterNum;
        PlayerPrefs.SetInt("SelectedCharacter", SelectedCharacterNum);
        PlayerPrefs.Save();
       
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }

    public void LoadCharacterSelection()
    {
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            SelectedCharacterNum = PlayerPrefs.GetInt("SelectedCharacter");
            Debug.Log("Loaded character selection: " + SelectedCharacterNum);
        }
    }

    
    public int GetSelectedCharacterNum()
    {
        return SelectedCharacterNum;
    }
}

