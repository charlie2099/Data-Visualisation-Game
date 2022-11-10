using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;
using Unity.VisualScripting;

public class AirQualityPopUp : MonoBehaviour
{
    [SerializeField]
    AudioClip slider_sound_clip;

    [SerializeField]
    AudioClip win_sound;

    [SerializeField]
    Button confirm_button;

    [SerializeField]
    TMP_Text TEXT1;
    TMP_Text p1GUESS;
    TMP_Text p2GUESS;

    [SerializeField]
    Slider Slider1;

    [SerializeField]
    TurnSystem turn_sys;


    [SerializeField]
    GameObject winwin;
    [SerializeField]
    TMP_Text textext;
    private void Start()
    {
        this.confirm_button = this.GetComponentInChildren<Button>();
        this.TEXT1 = GameObject.Find("GOOD BAD UGLY").GetComponent<TMP_Text>();
        this.Slider1 = this.GetComponentInChildren<Slider>();
        this.turn_sys = GameObject.Find("Turn Manager").GetComponent<TurnSystem>();
        this.p1GUESS = GameObject.Find("p1choose").GetComponent<TMP_Text>();
        this.p2GUESS = GameObject.Find("p2choose").GetComponent<TMP_Text>();
        this.winwin = GameObject.Find("winwin");
        this.textext = GameObject.Find("win win").GetComponent<TMP_Text>();

        winwin.SetActive(false);
        confirm_button.onClick.AddListener(pop_up_button_clicked);

        //Slider volume change
        Slider1.onValueChanged.AddListener(delegate { play_sound_on_slider_change(); });
    }
    //
    private void play_sound_on_slider_change()
    {
        AudioSource audiosource1 = GameObject.Find("Button Source").GetComponent<AudioSource>();
        if(audiosource1.isPlaying == false)
        {
            audiosource1.PlayOneShot(slider_sound_clip);
        }

    }
    private void play_win_sound()
    {
        AudioSource audiosource1 = GameObject.Find("Button Source").GetComponent<AudioSource>();
        audiosource1.PlayOneShot(win_sound);


    }
    private void Update()
    {
        //TEXT1.text = "SA";

        TEXT1.text = "Q:" + (int)(Slider1.value * 100);

    }

    private void pop_up_button_clicked()
    {
        if(turn_sys != null)
        {
            if (turn_sys.p1_selecting == true)
            {
                turn_sys.p1_GUESS = (int)(Slider1.value * 100);
                turn_sys.p1_selecting = false;
                turn_sys.p1_active = false;
                turn_sys.p2_active = false;
                turn_sys.p2_selecting = true;
                p1GUESS.text = "P1: " + ((int)(this.Slider1.value * 100)).ToString();
                //Debug.Log(turn_sys.p1_GUESS);
            }
            else if (turn_sys.p2_selecting == true)
            {
                turn_sys.p2_GUESS = (int)(this.Slider1.value * 100);
                turn_sys.p1_selecting = false;
                turn_sys.p2_selecting = true;
                turn_sys.p1_active = false;
                turn_sys.p2_active = false;
                p2GUESS.text = "P2: " + ((int)(this.Slider1.value * 100)).ToString();
                //Debug.Log(turn_sys.p2_GUESS);
                this.confirm_button.interactable = false;
                play_win_sound();
                StartCoroutine(destroyer_courutine());

            }
            



        }

        
    }

    IEnumerator destroyer_courutine()
    {

        if (turn_sys.p1_GUESS != 0 && turn_sys.p2_GUESS != 0 && turn_sys.choosen_states_air_quality != 0)
        {
            //Create Win State
            if (Mathf.Abs(turn_sys.p1_GUESS - turn_sys.choosen_states_air_quality) > Mathf.Abs(turn_sys.p2_GUESS - turn_sys.choosen_states_air_quality))
            {
                turn_sys.p2_score++;
                //p2 wins
                turn_sys.PLAYER_2_SCORE_HOLDER.text = turn_sys.p2_score.ToString();
                textext.text = "P2 Wins";
                //Debug.Log("Air Quality Index: " + turn_sys.choosen_states_air_quality);
            }
            else if((Mathf.Abs(turn_sys.p1_GUESS - turn_sys.choosen_states_air_quality) == Mathf.Abs(turn_sys.p2_GUESS - turn_sys.choosen_states_air_quality)))
            {
                //p2 wins
                turn_sys.p2_score++;
                turn_sys.p1_score++;
                turn_sys.PLAYER_2_SCORE_HOLDER.text = turn_sys.p2_score.ToString();
                turn_sys.PLAYER_1_SCORE_HOLDER.text = turn_sys.p1_score.ToString();
                textext.text = "DRAW";
                //Debug.Log("Air Quality Index: " + turn_sys.choosen_states_air_quality);
            }
            else
            {
                //p1 wins
                turn_sys.p1_score++;
                //p2 wins
                turn_sys.PLAYER_1_SCORE_HOLDER.text = turn_sys.p1_score.ToString();
                textext.text = "P1 Wins";
                //Debug.Log($"Air Quality Index: {turn_sys.choosen_states_air_quality}");
            }
        }

        
        turn_sys.actualAqiText.gameObject.SetActive(true);
        turn_sys.actualAqiText.text = "Actual Crime Rate: <color=red>" + turn_sys.choosen_states_air_quality + "</color>";
        
        winwin.SetActive(true);

        yield return new WaitForSeconds(3f);
        
        turn_sys.actualAqiText.gameObject.SetActive(false);
        turn_sys.actualAqiText.text = "Actual Crime Rate: <color=red> 0</color>";

        //Next Turn
        turn_sys.nextTurn();

        //Destroy this
        Destroy(gameObject);
    }
}
