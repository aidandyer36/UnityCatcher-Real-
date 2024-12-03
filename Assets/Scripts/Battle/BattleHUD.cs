using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] Slider hpBar;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;
        nameText.text = pokemon.Base.Name;
        levelText.text = "Lv. " + pokemon.Level;
        hpBar.maxValue = pokemon.MaxHP;
        hpBar.value = pokemon.HP;
    }

    public IEnumerator SetHPSmooth()
    {
        float curHP = hpBar.value;
        float changeAmt = curHP - _pokemon.HP;

        while(curHP - _pokemon.HP > Mathf.Epsilon)
        {
            curHP -= changeAmt * Time.deltaTime * 6f;
            hpBar.value = curHP;
            yield return null;
        }
        hpBar.value = _pokemon.HP;
    }
    
}
