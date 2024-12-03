using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleDialogueBox : MonoBehaviour
{

    [SerializeField] int lettersPerSecond;
    [SerializeField] Color highlightedColor;
    [SerializeField] Text dialogueText;

    [SerializeField] GameObject actionSelector;
    [SerializeField] List<Text> actionTexts;

    [SerializeField] GameObject moveSelector;
    [SerializeField] List<Text> moveTexts;

    [SerializeField] GameObject moveDetails;
    [SerializeField] Text ppText;
    [SerializeField] Text moveType;
    // Start is called before the first frame update
    public void SetDialogue(string dialogue)
    {
        dialogueText.text = dialogue;   
    }

    public IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";
        foreach(var letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }

    public void ToggleDialogueText(bool enabled)
    {
        dialogueText.enabled = enabled;
    }    

    public void ToggleActionSelector(bool enabled)
    {
        actionSelector.SetActive(enabled);
    }

    public void ToggleMoveSelector(bool enabled)
    {
        moveSelector.SetActive(enabled);
        moveDetails.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectedAction)
    {
        for (int i = 0; i< actionTexts.Count; i++)
        {
            if (i == selectedAction)
            {
                actionTexts[i].color = highlightedColor;
            }
            else
                actionTexts[i].color = Color.black;
        }
    }

}
