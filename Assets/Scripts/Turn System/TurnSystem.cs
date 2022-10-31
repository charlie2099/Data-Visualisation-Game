using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    //Turn system
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
    public bool is_both_player_finish_their_turns;

    //Guessed air quality number
    public int p1_GUESS;
    public int p2_GUESS;


    private void Awake()
    {
        current_turn = 1;
    }

    //when click a province, pass turn
    // player whoes turn first clicks and chooses the competitive province
    // -> SO turn cycle is p1 p2 , p2 p1 , p1 p2 ...
    //  ...


    //when both player click a province, calculate win and pass turn
    //  ...


    //Clear everything on turn change
    //  ...
}
