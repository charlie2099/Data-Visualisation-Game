using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    [SerializeField] public int Score_To_Win = 5;

    //Crime Selection Toolbar
    [SerializeField] public GameObject Crime_Selection;
    
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
    [SerializeField] public TMP_Text P1_Selected_City_Result;
    [SerializeField] public TMP_Text P2_Selected_City_Result;

    //Panel Managers
    [SerializeField] public GameObject Selection_Panel;
    [SerializeField] public GameObject Results_Panel;
    [SerializeField] public Button Next_Button;

    //Buttons
    [SerializeField] public Button[] ButtonList;

    private void Start()
    {
        Results_Panel.GetComponent<CanvasGroup>().alpha = 0;
        Crime_Name_Holder.text = "Select Crime Name & Year Below";

    }
    private void Update()
    {
        //Update Current Turn
        Current_Turn_Text_Holder.text = "ROUND " + _current_turn;

        //Update Score
        P1_Score_Text_Holder.text = _P1_Score.ToString() + "/" + Score_To_Win.ToString();
        P2_Score_Text_Holder.text = _P2_Score.ToString() + "/" + Score_To_Win.ToString();

    }

    public void Player_Chooses_City_For_Game(int Crime_Count, String County_Name, String Crime_Name, String Date)
    {
        if (_P1_Turn == true && _P2_Turn == false)
        {
            Activate_Buttons(false);
            //Pass Turn
            _P1_Turn = false;
            _P2_Turn = true;

            //Initialize Values
            Selected_Crime_Count_Of_P1 = Crime_Count;

            //Show in UI
            Crime_Name_Holder.text = Crime_Name + " in " + Date;
            //
            P1_Selected_City.text = County_Name;
            P1_Selected_City_Result.text = County_Name;
            P1_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P1.ToString();


        }
        else if(_P2_Turn == true && _P1_Turn == false)
        {
            var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

            for(int i = 0; i < _All_Cities.Length; i++)
            {
                _All_Cities[i].GetComponent<MeshCollider>().enabled = false;
            }
            //Pass Turn
            _P1_Turn = true;
            _P2_Turn = false;
            //Initialize Values
            Selected_Crime_Count_Of_P2 = Crime_Count;
            P2_Selected_City.text = County_Name;
            P2_Selected_City_Result.text = County_Name;
            P2_Crime_Count_Text_Holder.text = Selected_Crime_Count_Of_P2.ToString();

            //Start End State of the Game
            AudioSource.PlayOneShot(Win_Sounds);
            StartCoroutine(EndState());
            // Deactivate_and_Activate_Buttons(); -- move to next button pressed
        }
    }

    [SerializeField] GameObject P1Win;
    [SerializeField] GameObject P2Win;
    IEnumerator EndState()
    {


        yield return new WaitForSeconds(0.5f);
        //prevent click before animated
        Next_Button.enabled = false;

        Selection_Panel.SetActive(false);
        Results_Panel.GetComponent<CanvasGroup>().alpha = 1;
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
        //Calculate Win State

        //prevent click before animated
        Next_Button.enabled = true;

        GameObject.Find("(!)Next Button").GetComponent<Button>().onClick.AddListener(Next_Button_Pressed);
    }

    public void Next_Button_Pressed()
    {
        // Not sure why Next Button is always double trigger so I change by calculate from score
        if(_P1_Score < Score_To_Win){
            Activate_Buttons(true); //Move from turn p2
        }
        // _current_turn++;
        _current_turn = _P1_Score + _P2_Score + 1;
        

        Debug.Log("Current Turn:"+_current_turn);

        Crime_Name_Holder.text = "Select Crime Name & Year Below";
        P1_Selected_City.text = "";
        P2_Selected_City.text = "";

        CrimeType.CrimeTypeName = "";
        CrimeType.CrimeTypeNameDisplay = "";

        Selection_Panel.SetActive(true);
        Results_Panel.GetComponent<CanvasGroup>().alpha = 0;

        Wins_State();
        


        var _All_Cities = GameObject.FindObjectsOfType(typeof(City));

        for (int i = 0; i < _All_Cities.Length; i++)
        {
            _All_Cities[i].GetComponent<MeshCollider>().enabled = true;
        }
    }

    private void Activate_Buttons(bool operation)
    {
        if (ButtonList[1].enabled && !operation)
        {
            for(int i = 0; i < ButtonList.Length; i++)
            {
                //Change from enabled to active, prevent clicking 
                ButtonList[i].enabled = false; 
                Crime_Selection.SetActive(false);
            }
        }
        else if(!ButtonList[1].enabled && operation)
        {
            for (int i = 0; i < ButtonList.Length; i++)
            {
                //Change from enabled to active, prevent clicking 
                ButtonList[i].enabled = true;
                Crime_Selection.SetActive(true);
            }
        }
        Activate_Slider(operation);
    }

    //Slider Components
    [SerializeField] public Slider Slider;
    private void Activate_Slider(bool operation)
    {
        if (Slider.enabled && !operation)
        {
            Slider.enabled = false; 
        }
        else if(!Slider.enabled && operation)
        {
            Slider.enabled = true;
        }
    }

    //Win State
    [SerializeField] public Canvas Win_Canvas;
    [SerializeField] public TMP_Text Who_Wins;
    [SerializeField] public AudioClip Win_Sounds;
    [SerializeField] public AudioSource AudioSource;
    public void Wins_State()
    {
        if(_P1_Score >= Score_To_Win)
        {
            Win_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Who_Wins.text = "Player 1 Wins !";
            Who_Wins.color = Color.magenta;
            StartCoroutine(Destroy_Win_State_Routine());
        }
        else if(_P2_Score >= Score_To_Win)
        {
            Win_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Who_Wins.text = "Player 2 Wins !";
            Who_Wins.color = Color.cyan;
            StartCoroutine(Destroy_Win_State_Routine());
        }


    }

    IEnumerator Destroy_Win_State_Routine()
    {
        AudioSource.PlayOneShot(Win_Sounds);
        Win_Canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        Results_Panel.GetComponent<CanvasGroup>().alpha = 0;
        Selection_Panel.GetComponent<CanvasGroup>().alpha = 0;
        yield return new WaitForSeconds(5f);


        //Nulify Scores
        _P1_Score = 0;
        _P2_Score = 0;

        SceneManager.LoadScene("Game");
        Results_Panel.GetComponent<CanvasGroup>().alpha = 0;
        Selection_Panel.GetComponent<CanvasGroup>().alpha = 1;
        Win_Canvas.renderMode = RenderMode.WorldSpace;
    }

    
}
