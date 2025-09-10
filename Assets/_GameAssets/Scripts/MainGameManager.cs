using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;
    [SerializeField] private GameObject NewDay;
    [SerializeField] private GameObject[] Day1Events;
    [SerializeField] private GameObject[] Day2Events;
    [SerializeField] private GameObject[] Day3Events;
    [SerializeField] private GameObject[] Day4Events;
    [SerializeField] private GameObject[] Day5Events;
    [SerializeField] private GameObject[] Day6Events;
    [SerializeField] private GameObject[] Day7Events;
    [SerializeField] private TMP_Text DayText;
    [SerializeField] private GameObject DontBusted;
    [SerializeField] private GameObject MazeGame;
    [SerializeField] private GameObject PosterGame;
    [SerializeField] private GameObject MainGame;
    [SerializeField] private GameObject _finalPosterGame;



    [SerializeField] private int currentDay = 1;
    [SerializeField] private int currentEvent = 0;
    [SerializeField] private int DayCount = 1;
    private float delay = 1f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // sahneye tekrar eklenirse yok et
        }
    }
    void Start()
    {
        NewDay.SetActive(true);
        StartCoroutine(OpenNewDayPanel());
    }



    public void NextEvent()
    {
        GameObject[] events = GetEventsForDay(currentDay);

        if (currentEvent < events.Length)
        {
            // Paneli aktif et
            events[currentEvent].SetActive(true);
            Debug.Log("Event Açıldı: " + events[currentEvent].name);

            currentEvent++;
        }
        else
        {
            currentDay++;
            currentEvent = 0;
            NewDay.SetActive(true);

            StartCoroutine(OpenNewDayPanel());

        }
    }

    private GameObject[] GetEventsForDay(int day)
    {
        switch (day)
        {
            case 1: return Day1Events;
            case 2: return Day2Events;
            case 3: return Day3Events;
            case 4: return Day4Events;
            case 5: return Day5Events;
            case 6: return Day6Events;
            case 7: return Day7Events;
            default: return new GameObject[0];
        }
    }
    public void CloseEvent()
    {
        GameObject[] events = GetEventsForDay(currentDay);
        int TempEvent = currentEvent - 1;
        events[TempEvent].SetActive(false);
    }
    IEnumerator OpenNewDayPanel()
    {
        yield return new WaitForSeconds(delay);
        NewDay.SetActive(false);
        DayCount += 1;
        DayText.text = "Day " + DayCount;
        NextEvent();
    }
    public void SellGuitar()
    {
        GameValueButtons.GInstance.sellGuitar();
        GameObject[] events = GetEventsForDay(currentDay);
        int TempEvent = currentEvent - 1;
        events[TempEvent].SetActive(false);
        NextEvent();
    }
    public void DePolice()
    {
        CloseEvent();
        MainGame.SetActive(false);
        DontBusted.SetActive(true);

    }
    public void MazeHunter()
    {
        CloseEvent();
        MainGame.SetActive(false);
        MazeGame.SetActive(true);
    }
    public void PosterHunter()
    {
        CloseEvent();
        MainGame.SetActive(false);
        PosterGame.SetActive(true);
    }
    public void FinalGame()
    {
        CloseEvent();
        MainGame.SetActive(false);
        _finalPosterGame.SetActive(true);
    }

}

