using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {  Start, PlayerAction, PlayerMove, EnemyMove, Busy}

public class BattleSystem : MonoBehaviour
{
    [SerializeField] BattleUnit playerUnit;
    [SerializeField] BattleUnit enemyUnit;
    [SerializeField] BattleHUD playerHUD;
    [SerializeField] BattleHUD enemyHUD;
    [SerializeField] BattleDialogueBox dialogueBox;

    BattleState state;
    int currentAction;

    private void Start()
    {
        StartCoroutine(SetupBattle());
    }

    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHUD.SetData(playerUnit.Pokemon);
        enemyHUD.SetData(enemyUnit.Pokemon);
        yield return dialogueBox.TypeDialogue($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");
        yield return new WaitForSeconds(1f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        StartCoroutine(dialogueBox.TypeDialogue("Choose an action"));
        dialogueBox.ToggleActionSelector(true);
    }

    private void Update()
    {
         if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
    }
    
    void HandleActionSelection()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentAction < 1)
            {
                currentAction++;
            }
            else
                currentAction--;
            
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentAction > 0)
                currentAction--;
            else
               currentAction++;
        }

        dialogueBox.UpdateActionSelection(currentAction);
    }
}
