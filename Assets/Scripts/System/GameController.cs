using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] List<Pokemon> monTypes;
    [SerializeField] BattleSystem battleSystem;
    [SerializeField] AudioSource bgmMusic;
    [SerializeField] AudioClip battleTheme;
    [SerializeField] AudioClip overworldTheme;
    private Pokemon enemy;
    // Start is called before the first frame update
    private void Start()
    {

        battleSystem.OnBattleOver += EndBattle;
        foreach(Pokemon pokemon in monTypes)
        {
            pokemon.Init();
        }
    }
    public void InitializeBattle(string pokemonBase)
    {
        var playerParty = player.GetComponent<PokemonParty>();
        foreach(Pokemon pokemon in monTypes)
        {
            if(pokemon.Base.Name == pokemonBase)
                enemy = pokemon;
        }
        if(enemy == null)
        {
            Debug.LogError("No matching Pokemon in list");
        }
        battleSystem.gameObject.SetActive(true);
        bgmMusic.clip = battleTheme;
        bgmMusic.Play();
        battleSystem.StartBattle(playerParty, enemy);
    }

    // Update is called once per frame
    public void InitializeStarter(string starterName)
    {
        var playerParty = player.GetComponent<PokemonParty>();
        playerParty.pokemons.Clear();
        foreach(Pokemon pokemon in monTypes)
        {
            if (starterName == pokemon.Base.Name)
                playerParty.pokemons.Add(pokemon);
        }
    }

    void EndBattle(bool won, Pokemon enemy)
    {
        var playerParty = player.GetComponent<PokemonParty>();
        battleSystem.gameObject.SetActive(false);
        if(won)
        {
            playerParty.pokemons.Add(enemy);
        }
        bgmMusic.clip = overworldTheme;
        bgmMusic.Play();
    }   

    public void HealPlayerParty()
    {
        var playerParty = player.GetComponent<PokemonParty>();
        foreach(Pokemon pokemon in playerParty.pokemons)
        {
            pokemon.HP = pokemon.MaxHP;
        }
    }
}
