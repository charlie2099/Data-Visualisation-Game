using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurnSystem : MonoBehaviour
{
    //Turn system
    [NonSerialized]
    public int current_turn;
    public bool p1_active;
    public bool p2_active;

    public int p1_score;
    public int p2_score;

    //UI
    [SerializeField]
    TMP_Text CURRENT_TURN_TEXT_HOLDER;
    [SerializeField]
    TMP_Text PLAYER_1_SCORE_HOLDER;
    [SerializeField]
    TMP_Text PLAYER_2_SCORE_HOLDER;

    //
    [NonSerialized]
    public bool is_both_player_finish_their_turns;

    //Guessed air quality number
    public int p1_GUESS;
    public int p2_GUESS;


    private void Awake()
    {
        current_turn = 1;
    }

    [SerializeField]
    public GameObject POPUP_SLIDER_MENU;

    //when click a province, open POPUP
    //send information to the popup window 


    // player whoes turn first clicks and chooses the competitive province
    // -> SO turn cycle is p1 p2 , p2 p1 , p1 p2 ...
    //  ...


    //when both player click a province, calculate win and pass turn
    //  ...


    //Clear everything on turn change
    //  ...
}
