using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwap : MonoBehaviour
{

    public Sprite[] sprites; 
    private SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 

       
        int SelectedCharacterNum = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Debug.Log("Loaded character index: " + SelectedCharacterNum);

       
        ChangeSprite(SelectedCharacterNum);
    }

    void ChangeSprite(int CharacterNum)
    {
       
        if (CharacterNum < 0 || CharacterNum >= sprites.Length) 
        {
            Debug.LogWarning("Invalid character index: " + CharacterNum + ". Defaulting to index 0.");
            CharacterNum = 0;
        }

       
        spriteRenderer.sprite = sprites[CharacterNum];
        Debug.Log("Sprite changed to: " + sprites[CharacterNum].name);
    }
}
