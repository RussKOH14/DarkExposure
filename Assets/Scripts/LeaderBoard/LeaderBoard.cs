using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> names;
    [SerializeField]
    private List<TextMeshProUGUI> scores;

    private string publicLeaderboardKey = "4d1357ac6ea5f1535aac8f799ccf2111a9703456abe3f247e752ff281dec3d14";

    public void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {

            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for(int i=0; i < loopLength; ++i)
            {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }
        }));
    }

    public void SetLeaderBoardEntry(string username, int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) =>
           {
               //if (System.Array.IndexOf(badWords, name) != -1) return;
               GetLeaderboard();
           }));
    }
}
