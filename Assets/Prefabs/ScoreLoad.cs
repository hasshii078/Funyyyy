using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;
public class ScoreLoad : MonoBehaviour
{
    public void LoadScore()
    {
        int rank;

        NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("ScoreClass");

        query.OrderByDescending("score");
        query.Limit = 10;

        query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
        {
            if (e != null)
            {
                Debug.LogWarning("error: " + e.ErrorMessage);
            }
            else
            {
                for (int i = 0; i < objList.Count; i++)
                {
                    rank = i + 1;
                    Debug.Log("ScoreRanking " + rank + "ˆÊ: " + objList[i]["score"]);
                }
            }
        });

    }
}