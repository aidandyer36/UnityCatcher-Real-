using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pokemon
{
    [SerializeField] PokemonBase _base;
    [SerializeField] int level;

    public PokemonBase Base
    {
        get
        {
            return _base;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }
    }

    public int HP {get; set; }

    public List<Move> Moves {get; set;}
    public void Init()
    { 
        HP = MaxHP;

        Moves = new List<Move>();
        foreach (var move in Base.LearnableMoves) 
        {
            if(move.Level <= Level)
                Moves.Add(new Move(move.Base));

            if(Moves.Count >= 4)
                break;
        }
    }

    public int Attack {
        get { return Mathf.FloorToInt((Base.Attack * Level) / 100f) + 5;}
    }
    public int Defense {
        get { return Mathf.FloorToInt((Base.Defense * Level) / 100f) + 5;}
    }
    public int SpAttack {
        get { return Mathf.FloorToInt((Base.SpAttack * Level) / 100f) + 5;}
    }
    public int SpDefense {
        get { return Mathf.FloorToInt((Base.SpDefense * Level) / 100f) + 5;}
    }
    public int Speed {
        get { return Mathf.FloorToInt((Base.Speed * Level) / 100f) + 5;}
    }
    public int MaxHP {
        get { return Mathf.FloorToInt((Base.MaxHP * Level) / 100f) + 10;}
    }

    public bool TakeDamage(Move move, Pokemon attacker)
    {
        float modifiers = Random.Range(0.85f, 1f);
        float a = (2 * attacker.Level + 10) / 250f;
        float d = a * move.Base.Power * ((float)attacker.Attack / Defense) + 2;
        int damage = Mathf.FloorToInt(d * modifiers);

        HP -= damage;
        if (HP <= 0)
        {
            HP = 0;
            return true;
        }
        else
            return false;
    }
    public Move GetRandomMove()
    {
        int r = Random.Range(0, Moves.Count);
        return Moves[r];
    }
}
