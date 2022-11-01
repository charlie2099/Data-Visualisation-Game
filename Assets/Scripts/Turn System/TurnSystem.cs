using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    //Turn system
    [NonSerialized]
    public int current_turn;

    public bool currently_busy;

    public bool p1_active = false;
    public bool p2_active = false;

    public bool p1_selecting = false;
    public bool p2_selecting = false;

    public int p1_score;
    public int p2_score;

    public int choosen_states_air_quality = 0;
    //UI
    [SerializeField]
    TMP_Text CURRENT_TURN_TEXT_HOLDER;
    [SerializeField]
    public TMP_Text PLAYER_1_SCORE_HOLDER;
    [SerializeField]
    public TMP_Text PLAYER_2_SCORE_HOLDER;
    [SerializeField]
    TMP_Text WHAT_TO_DO;
    
    //
    [NonSerialized]
    public bool is_both_player_finish_their_turns;

    //Guessed air quality number
    public int p1_GUESS;
    public int p2_GUESS;

    //Slider Selector Gameobject
    [SerializeField]
    GameObject Selector_Panel;

    private void Awake()
    {
        current_turn = 1;
    }
    private void Update()
    {
        this.CURRENT_TURN_TEXT_HOLDER.text = "Turn : " + current_turn.ToString();
        change_WHAT_TO_DO_update();
        is_Currently_Busy();
    }

    private void change_WHAT_TO_DO_update()
    {
        if (p1_active)
        {
            WHAT_TO_DO.text = "Player 1 \n Select the City";
        }
        if (p1_selecting)
        {
            WHAT_TO_DO.text = "Player 1 \n Select possible air quality";
        }
        if (p2_active)
        {
            WHAT_TO_DO.text = "Player 2 \n Select the City";
        }
        if (p2_selecting)
        {
            WHAT_TO_DO.text = "Player 2 \n Select possible air quality";
        }

        
    }


    [SerializeField]
    public GameObject POPUP_SLIDER_MENU;
    GameObject menu;
    public Slider quality_slider;
    //when click a province, open POPUP
    //send information to the popup window 
    public void instantiate_SLIDER_POP_UP()
    {
        menu = Instantiate(POPUP_SLIDER_MENU);
        quality_slider = menu.GetComponentInChildren<Slider>();
        if(menu.GetComponentInChildren<Slider>() != null)
        {
            Debug.Log("I can see the slider");
        }
    }
    public void destroy_SLIDER_POP_UP()
    {
        Destroy(menu);
    }

    public void nextTurn()
    {
        if(this.current_turn%2 == 0)
        {
            clear_all();
            //this.p1_active = true;
            this.current_turn++;
        }
        else if(this.current_turn%2 == 1)
        {
            clear_all();
            //this.p2_active = true;
            this.current_turn++;
        }
    }

    public void clear_all()
    {
        this.currently_busy = false;
        this.p1_active = false;
        this.p2_active = false;
        this.p1_selecting = false;
        this.p2_selecting = false;
        this.p1_GUESS = 0;
        this.p2_GUESS = 0;
        choosen_states_air_quality = 0;
    }

        // player whoes turn first clicks and chooses the competitive province
        // -> SO turn cycle is p1 p2 , p2 p1 , p1 p2 ...
        //  ...


        //when both player click a province, calculate win and pass turn
        //  ...


        //Clear everything on turn change
        //  ...











    public void is_Currently_Busy()
    {
        if (p1_active == false && p2_active == false && p1_selecting == false && p2_selecting == false)
        {
            currently_busy = false;
        }
        else
        {
            currently_busy = true;
        }
    }
    }
