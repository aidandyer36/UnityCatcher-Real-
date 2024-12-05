using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    PokemonBase _base;
    int level;

    public Pokemon Pokemon {get; set;}

    public void Setup(Pokemon pokemon, bool isPlayerUnit)
    {
        Pokemon = pokemon;
        if(isPlayerUnit)
            GetComponent<Image>().sprite = Pokemon.Base.BackSprite;
        else
        {
            GetComponent<Image>().sprite = Pokemon.Base.FrontSprite;
            pokemon.HP = pokemon.MaxHP;
        }
            
    }
}
