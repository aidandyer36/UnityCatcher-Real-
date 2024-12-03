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
    private PlayerControls playerControls;

    BattleState state;
    int currentAction;
    int currentMove;
    bool isChanging;

    private void Awake()
    {
        playerControls = new PlayerControls();
        Debug.Log("Player Controls Created");
        StartCoroutine(SetupBattle());
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    public IEnumerator SetupBattle()
    {
        playerUnit.Setup();
        enemyUnit.Setup();
        playerHUD.SetData(playerUnit.Pokemon);
        enemyHUD.SetData(enemyUnit.Pokemon);

        dialogueBox.SetMoveNames(playerUnit.Pokemon.Moves);

        yield return dialogueBox.TypeDialogue($"A wild {enemyUnit.Pokemon.Base.Name} appeared.");
        yield return new WaitForSeconds(.75f);

        PlayerAction();
    }

    void PlayerAction()
    {
        state = BattleState.PlayerAction;
        dialogueBox.ToggleMoveSelector(false);
        dialogueBox.ToggleDialogueText(true);
        StartCoroutine(dialogueBox.TypeDialogue("Choose an action"));
        dialogueBox.ToggleActionSelector(true);
    }

    void PlayerMove()
    {
        state = BattleState.PlayerMove;
        dialogueBox.ToggleActionSelector(false);
        dialogueBox.ToggleDialogueText(false);
        dialogueBox.ToggleMoveSelector(true);
    }

    IEnumerator PerformPlayerMove()
    {
        state = BattleState.Busy;
        var move = playerUnit.Pokemon.Moves[currentMove];
        yield return dialogueBox.TypeDialogue($"{playerUnit.Pokemon.Base.Name} used {move.Base.Name}");

        yield return new WaitForSeconds(.75f);

        bool isFainted = enemyUnit.Pokemon.TakeDamage(move, playerUnit.Pokemon);
        yield return enemyHUD.SetHPSmooth();
        if (isFainted)
        {
            yield return dialogueBox.TypeDialogue($"{enemyUnit.Pokemon.Base.Name} fainted!");
        }
        else
        {
            StartCoroutine(EnemyMove());
        }
    }

    IEnumerator EnemyMove()
    {
        state = BattleState.EnemyMove;
        var move = enemyUnit.Pokemon.GetRandomMove();
        yield return dialogueBox.TypeDialogue($"{enemyUnit.Pokemon.Base.Name} used {move.Base.Name}");

        yield return new WaitForSeconds(1f);

        bool isFainted = playerUnit.Pokemon.TakeDamage(move, enemyUnit.Pokemon);
        yield return playerHUD.SetHPSmooth();
        if (isFainted)
        {
            yield return dialogueBox.TypeDialogue($"{playerUnit.Pokemon.Base.Name} fainted!");
        }
        else
        {
            PlayerAction();
        }
    }

    private void Update()
    {
         if(state == BattleState.PlayerAction)
        {
            HandleActionSelection();
        }
        if(state == BattleState.PlayerMove)
        {
            HandleMoveSelection();
        }
    }
    
    void HandleActionSelection()
    {
        if (playerControls.Travel.Move.ReadValue<Vector2>().y < 0)
        {
            Debug.Log(currentMove);
            if (currentAction < 1)
                currentAction++;
            
        }
        else if(playerControls.Travel.Move.ReadValue<Vector2>().y > 0)
        {
            Debug.Log(currentMove);
            if (currentAction > 0)
                currentAction--;
        }

        dialogueBox.UpdateActionSelection(currentAction);

        if (playerControls.Travel.Interact2.triggered)
        {
            if (currentAction == 0)
            {
                //Fight
                PlayerMove();

            }
            else if (currentAction == 1)
            {
                //Run
            }
        }
    }

    void HandleMoveSelection()
    {
        var menuInput = playerControls.UI.Navigate.ReadValue<Vector2>();
        if (menuInput.x != 0) menuInput.y = 0;

        if (menuInput.x > 0)
        {
            Debug.Log("Right Arrow");
            if (currentMove < playerUnit.Pokemon.Moves.Count - 1)
              ++currentMove;
            Debug.Log(currentMove);
        }
        else if (menuInput.x < 0) 
        {
            Debug.Log("Left Arrow");
            if (currentMove > 0)
                --currentMove;
            Debug.Log(currentMove);
        }
        else if (menuInput.y < 0)
        {
            Debug.Log("Down Arrow");
            if (currentMove < playerUnit.Pokemon.Moves.Count - 2)
                currentMove += 2;
            Debug.Log(currentMove);
        }
        else if (menuInput.y > 0) 
        {
            Debug.Log("Up Arrow");
            if (currentMove > 1)
                currentMove -= 2;
            Debug.Log(currentMove);
        }

        dialogueBox.UpdateMoveSelection(currentMove, playerUnit.Pokemon.Moves[currentMove]);

        if (playerControls.Travel.Interact2.triggered)
        {
            dialogueBox.ToggleMoveSelector(false);
            dialogueBox.ToggleDialogueText(true);
            StartCoroutine(PerformPlayerMove());
            }
    }
}
