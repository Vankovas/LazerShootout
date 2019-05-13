using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject p1;
    public GameObject p2;

    public int p1Life;
    public int p2Life;

    public GameObject p1Wins;
    public GameObject p2Wins;

    public GameObject[] p1Figures;
    public GameObject[] p2Figures;

    public AudioSource hurt;
    public AudioSource win;

    public string mainMenuScene;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(p1Life < 1) {
            p1.SetActive(false);
            win.Play();
            p2Wins.SetActive(true);
        }
        if(p2Life < 1 ) {
            p2.SetActive(false);
            win.Play();
            p1Wins.SetActive(true);            
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene("game");
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("menu");
        }

    }
    public void HurtP1() {
        p1Life -= 1;
        for (int i = 0; i < p1Figures.Length; i++) {
            if(p1Life > i) {
                p1Figures[i].SetActive(true);
            }
            else {
                p1Figures[i].SetActive(false);
            }
        }
        hurt.Play();
    }

    public void HurtP2() {
        p2Life -= 1;
        for (int i = 0; i < p2Figures.Length; i++) {
            if (p2Life > i) {
                p2Figures[i].SetActive(true);
            }
            else {
                p2Figures[i].SetActive(false);
            }
        }
        hurt.Play();
    }
}
