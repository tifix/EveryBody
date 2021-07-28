using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    const string private_code = "_Um4cNUohUmbJn2wzffI3QtMrgIJw3t0at9irr4gZ72g";
    const string public_code = "610186c08f40bb8ea04bdd0d";
    const string web_url = "http://dreamlo.com/lb/";
    public Entry[] high_scores;

    private void Awake()
    {
        AddNewHighscore("Tyfus", 10);
        AddNewHighscore("Mick", 30);
        AddNewHighscore("Marivn", 2);

        DownloadHighscores();
    }

    public void AddNewHighscore(string username, int score) 
    {
        StartCoroutine(UploadNewScore(username, score));
    }
    public void DownloadHighscores()
    {
        StartCoroutine(DownloadScores());
    }


    IEnumerator UploadNewScore(string username, int score) 
    {
        UnityWebRequest www = new UnityWebRequest(web_url + private_code + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        //WWW www = new WWW(web_url + private_code + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error)) Debug.LogWarning("upload succesfull"); 
        else Debug.LogWarning("upload error: "+www.error);
    }

    IEnumerator DownloadScores()
    {
        UnityWebRequest www = new UnityWebRequest(web_url + public_code + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.LogWarning("download succesfull");
            //FormatHighscore(www.text);
            //UnityWebRequest.Get(www);
            FormatHighscore(www.downloadHandler.text);
        }
        else Debug.LogWarning("upload error: " + www.error);
    }

    void FormatHighscore(string input_string) 
    {
        string[] entries = input_string.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        high_scores = new Entry[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string name = entries[i].Split('|')[0];
            int score= int.Parse( entries[i].Split('|')[1]);

            high_scores[i] = new Entry(name, score);
            Debug.Log(high_scores[i]);
        }
        
    }


    [System.Serializable]
    public struct Entry 
    {
        public string name;
        public int score;


        public Entry(string _name, int _score) 
        {
            name = _name;
            score = _score;
        }
    }

}
