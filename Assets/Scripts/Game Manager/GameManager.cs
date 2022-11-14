using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Turn system
    [NonSerialized] private int _current_turn = 1;

    [NonSerialized] private bool _P1_Turn = true;
    [NonSerialized] private bool _P2_Turn = false;

    [NonSerialized] public int _P1_Score;
    [NonSerialized] public int _P2_Score;

    [NonSerialized] public int Selected_Crime_Count_Of_P1;
    [NonSerialized] public int Selected_Crime_Count_Of_P2;


    //UI
    //Crime Name Holder
    [SerializeField] public TMP_Text Crime_Name_Holder;

    //Current Turn
    [SerializeField] public TMP_Text Current_Turn_Text_Holder;

    //Crime Counts
    [SerializeField] public TMP_Text P1_Crime_Count_Text_Holder;
    [SerializeField] public TMP_Text P2_Crime_Count_Text_Holder;

    //Scores of Players
    [SerializeField] public TMP_Text P1_Score_Text_Holder;
    [SerializeField] public TMP_Text P2_Score_Text_Holder;
    
    [SerializeField] public TMP_Text P1_Selected_City;
    [SerializeField] public TMP_Text P2_Selected_City;

    //Panel Managers
    [SerializeField] public GameObject Selection_Panel;
    [SerializeField] public GameObject Results_Panel;

    //Buttons
    [SerializeField] public Button[] ButtonList;

    private void Start()
    {
        Results_Panel.SetActive(false);

    }
    private void Update()
    {
        //Update Current Turn
        Current_Turn_Text_Holder.text = "ROUND " + _current_turn;

        //Update Score
        P1_Score_Text_Holder.text = _P1_Score.ToString();
        P2_Score_Text_Holder.text = _P2_Score.ToString();

    }

    public void Player_Chooses_City_For_Game(int Crime_Count, String County_Name, String Crime_Name, String Date)
    {
        if (_P1_Turn == true && _P2_Turn == false)
        {
            Deactivate_and_Activate_Buttons();
            //Pass Turn
            _P1_Turn = false;
            _P2_Turn = true;

            //Initialize Values
            Selected_Crime_Count_Of_P1 = Crime_Count;

            //Show in UI
            Crime_Name_Holder.text = Crime_Name + " in " + Date;
            //
            P1_Selected_City.text = County_Name;
            P1_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P1.ToString();


        }
        else if(_P2_Turn == true && _P1_Turn == false)
        {
            //Pass Turn
            _P1_Turn = true;
            _P2_Turn = false;
            //Initialize Values
            Selected_Crime_Count_Of_P2 = Crime_Count;
            P2_Selected_City.text = County_Name;
            P2_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P2.ToString();

            //Start End State of the Game
            StartCoroutine(EndState());
        }
    }


    [SerializeField] GameObject P1Win;
    [SerializeField] GameObject P2Win;
    IEnumerator EndState()
    {


        yield return new WaitForSeconds(0.5f);
        
        Selection_Panel.SetActive(false);
        Results_Panel.SetActive(true);
        P1Win.SetActive(false);
        P2Win.SetActive(false);

        yield return new WaitForSeconds(1f);
        P1_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P1.ToString();
        yield return new WaitForSeconds(1f);
        P2_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P2.ToString();



        if (Selected_Crime_Count_Of_P1 < Selected_Crime_Count_Of_P2)
        {
            //P1 Wins
            P1Win.SetActive(true);
            _P1_Score++;

        }
        else if(Selected_Crime_Count_Of_P1 > Selected_Crime_Count_Of_P2)
        {
            //P2 Wins
            P2Win.SetActive(true);
            _P2_Score++;

        }
        else if(Selected_Crime_Count_Of_P1 == Selected_Crime_Count_Of_P2)
        {
            //Draw
            _P1_Score++;
            _P2_Score++;

        }

        yield return new WaitForSeconds(3f);
        _current_turn++;

        Crime_Name_Holder.text = "";
        P1_Selected_City.text = "";
        P2_Selected_City.text = "";

        Selection_Panel.SetActive(true);
        Results_Panel.SetActive(false);


        //Re activate all ui components
        Deactivate_and_Activate_Buttons();
    }


    private void Deactivate_and_Activate_Buttons()
    {
        if (ButtonList[1].enabled)
        {
            for(int i = 0; i < ButtonList.Length; i++)
            {
                ButtonList[i].enabled = false;  
            }
        }
        else
        {
            for (int i = 0; i < ButtonList.Length; i++)
            {
                ButtonList[i].enabled = true;
            }
        }
        Deactivate_and_Activate_Slider();
    }

    //Slider Components
    [SerializeField] public Slider Slider;
    private void Deactivate_and_Activate_Slider()
    {
        if (Slider.enabled)
        {
            Slider.enabled = false; 
        }
        else
        {
            Slider.enabled = true;
        }
    }
}
