using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HighScores : MonoBehaviour
{
    //victoria leaderboards at// lb/NahH015Fl0WOSd-TMIA7PgieqPQVKAX0WWt2K7le2U5g
    const string private_code_vic = "NahH015Fl0WOSd-TMIA7PgieqPQVKAX0WWt2K7le2U5g";
    const string public_code_vic = "6105756e778d3cc600517b3e";

    //emo leaderboards at lb/DZBHqBoYrESsZeSrrkEsrgoQse4z8FZka19KKRprX7Zg
    const string private_code_emo = "DZBHqBoYrESsZeSrrkEsrgoQse4z8FZka19KKRprX7Zg";
    const string public_code_emo = "610575d6778d3cc600517b43";

    //   lb/kJfFNNyzNEqISCqJhhhC4gJXIzbWfZQEuBkFbJkUPP6w
    const string private_code_dev = "kJfFNNyzNEqISCqJhhhC4gJXIzbWfZQEuBkFbJkUPP6w";
    const string public_code_dev = "61057628778d3cc600517b4a";

    // lb/dVJJ_zpoxkmgZcUNc6aHFA0L-szcMhv0qEzr24Sd6Uaw
    const string private_code_fin = "dVJJ_zpoxkmgZcUNc6aHFA0L-szcMhv0qEzr24Sd6Uaw";
    const string public_code_fin = "61057645778d3cc600517b4d";

    const string web_url = "http://dreamlo.com/lb/";
    public Entry[] high_scores;

    public bool download_finished = false;


    private void Update()
    {
        if (SceneSwitcher.instance.is_debugging && Input.GetKeyDown(KeyCode.Q)) FakeTestScore();
    }

    //generates a random score to add to the scoreboard
    public void FakeTestScore()
    {
        int boo = Random.Range(0, 200);
        Debug.Log(boo);
        AddNewHighscore(new string[] { "Tyfus", "Mick", "Marcello" }[Random.Range(0, 3)], boo, new string[] { "vic", "emo", "dev", "fin" }[Random.Range(0, 4)]);
    }




    public void PointlessButton()
    {
        if (SceneSwitcher.instance.is_debugging)
        {
            UnityWebRequest www = new UnityWebRequest(web_url + private_code_vic + "/clear");
            www.SendWebRequest();
            UnityWebRequest ww2 = new UnityWebRequest(web_url + private_code_emo + "/clear");
            ww2.SendWebRequest();
            UnityWebRequest ww3 = new UnityWebRequest(web_url + private_code_dev + "/clear");
            ww3.SendWebRequest();
            UnityWebRequest ww4 = new UnityWebRequest(web_url + private_code_fin + "/clear");
            ww4.SendWebRequest();
            Debug.LogWarning("HS purged.");
        }


    }


    #region coroutine starters


    //collects all player scores and sends them to the server
    public void SendPlayerDataToServer(string _name)
    {
        StartCoroutine(SmooooothedPlayerUpload(_name));
    }

    //adds a specified highscore to one of the leaderboards
    public void AddNewHighscore(string username, int score, string board)
    {
        StartCoroutine(UploadNewScore(username, score, board));
    }

    //downloads a specified highscore to one of the leaderboards
    public void DownloadHighscores(string board)
    {
        StartCoroutine(DownloadScores(board));
    }

    //refreshes the leaderboard displaying objects
    public void UpdateHSDisplay()
    {
        StartCoroutine(SmoothedLeaderDownloader());
    }



    #endregion 

    #region coroutines

    //uploads a new score to the leaderboard
    IEnumerator UploadNewScore(string username, int score, string board)
    {

        string pc;
        switch (board)
        {
            default: { pc = private_code_vic; break; }
            case ("emo"): { pc = private_code_emo; break; }
            case ("dev"): { pc = private_code_dev; break; }
            case ("fin"): { pc = private_code_fin; break; }

        }
        //Debug.Log("upload starting");

        UnityWebRequest www = new UnityWebRequest(web_url + pc + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        //WWW www = new WWW(web_url + private_code_vic + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error)) Debug.LogWarning("upload succesfull");
        else Debug.LogWarning("upload error: " + www.error);
    }


    //downloads the raw scoreboard
    IEnumerator DownloadScores(string board)
    {
        download_finished = false;

        string pc;
        switch (board)
        {
            default: { pc = public_code_vic; break; }
            case ("emo"): { pc = public_code_emo; break; }
            case ("dev"): { pc = public_code_dev; break; }
            case ("fin"): { pc = public_code_fin; break; }

        }

        UnityWebRequest www = new UnityWebRequest(web_url + pc + "/pipe/");
        www.downloadHandler = new DownloadHandlerBuffer();
        yield return www.SendWebRequest();

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.LogWarning("download succesfull:" + www.downloadHandler.text);    //if(SceneSwitcher.instance.is_debugging) 
            FormatHighscore(www.downloadHandler.text);
        }
        else { 
            Debug.LogWarning("upload error: " + www.error);
            if (www.error == "HTTP/1.1 503 Service Unavailable") 
            {
                Menu.instance.board_vic.text = "if you're seeing this, HighScore servers are down :c";
                Menu.instance.board_fin.text = "if you're seeing this, HighScore servers are down :c";
                Menu.instance.board_emo.text = "if you're seeing this, HighScore servers are down :c";
                Menu.instance.board_dev.text = "if you're seeing this, HighScore servers are down :c";

            } 
        }
        download_finished = true;
    }


    //formats the downloaded scores to a readable format
    Entry[] FormatHighscore(string input_string)
    {
        string[] entries = input_string.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        high_scores = new Entry[entries.Length];
        if (high_scores.Length > 10) high_scores = new Entry[10];

        for (int i = 0; i < high_scores.Length; i++)
        {
            string name = entries[i].Split('|')[0];
            int score = int.Parse(entries[i].Split('|')[1]);

            high_scores[i] = new Entry(name, score);
        }


        return high_scores;
    }


    //downloads all the leaderboards asynchronously
    IEnumerator SmoothedLeaderDownloader()
    {
        //Debug.Log("smoother");

        string output = "";

        DownloadHighscores("vic");
        while (!download_finished) yield return new WaitForEndOfFrame();

        for (int i = 0; i < high_scores.Length; i++)
        {
            output += "#" + (i + 1) + ":" + high_scores[i].name + "-" + high_scores[i].score + '\n';
        }
        //Debug.Log("V:" + output);
        Menu.instance.board_vic.text = output;

        DownloadHighscores("emo");
        while (!download_finished) yield return new WaitForEndOfFrame();
        output = "";
        for (int i = 0; i < high_scores.Length; i++)
        {
            output += "#" + (i + 1) + ":" + high_scores[i].name + "-" + high_scores[i].score + '\n';
        }
        //Debug.Log("E:" + output);
        Menu.instance.board_emo.text = output;

        DownloadHighscores("dev");
        while (!download_finished) yield return new WaitForEndOfFrame();
        output = "";
        for (int i = 0; i < high_scores.Length; i++)
        {
            output += "#" + (i + 1) + ":" + high_scores[i].name + "-" + high_scores[i].score + '\n';
        }
        //Debug.Log("D:" + output);
        Menu.instance.board_dev.text = output;

        DownloadHighscores("fin");
        while (!download_finished) yield return new WaitForEndOfFrame();
        output = "";
        for (int i = 0; i < high_scores.Length; i++)
        {
            output += "#" + (i + 1) + ":" + high_scores[i].name + "-" + high_scores[i].score + '\n';
        }
        //Debug.Log("F:" + output);
        Menu.instance.board_fin.text = output;
        Debug.Log("smooth finish");
    }



    //fully automated score submission - red from SceneChanger's local highscores
    IEnumerator SmooooothedPlayerUpload(string _name)
    {
        yield return null;
        if (SceneSwitcher.instance.highscore_victoria > 0)  AddNewHighscore(_name, SceneSwitcher.instance.highscore_victoria,   "vic");
        if (SceneSwitcher.instance.highscore_emo > 0)       AddNewHighscore(_name, SceneSwitcher.instance.highscore_emo,        "emo");
        if (SceneSwitcher.instance.highscore_devil > 0)     AddNewHighscore(_name, SceneSwitcher.instance.highscore_devil,      "dev");
        if (SceneSwitcher.instance.highscore_final > 0)     AddNewHighscore(_name, SceneSwitcher.instance.highscore_final,      "fin");

    }

    #endregion







    //data structs

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
