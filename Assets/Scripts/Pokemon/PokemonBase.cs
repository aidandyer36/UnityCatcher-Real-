using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pokemon", menuName = "Pokemon/Create new pokemon")]

public class PokemonBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] MonsterType type1;
    [SerializeField] MonsterType type2;

    //base stats
    [SerializeField] int maxHP;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name {
        get {return name; }
    }

    public string Description{
        get {return description;}
    }

    public Sprite FrontSprite{
        get {return frontSprite;}
    }
    public Sprite BackSprite{
        get {return backSprite;}
    }
    public MonsterType Type1{
        get {return type1;}
    }
    public MonsterType Type2{
        get {return type2;}
    }
    public int MaxHP{
        get {return maxHP;}
    }
    public int Attack{
        get {return attack;}
    }
    public int Defense{
        get {return defense;}
    }
    public int SpAttack{
        get {return spAttack;}
    }
    public int SpDefense{
        get {return spDefense;}
    }
    public int Speed{
        get {return speed;}
    }
    public List<LearnableMove> LearnableMoves{
        get {return learnableMoves;}
    }
}

[System.Serializable]
public class LearnableMove{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base{
        get {return moveBase;}
    }
    public int Level {
        get {return level;}
    }
}
public enum MonsterType{
    None, 
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,

}
