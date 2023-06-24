using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCMB;

public class ScoreSave : MonoBehaviour
{

    public void SaveScore(int Score)
    {
        NCMBObject scoreClass = new NCMBObject("ScoreClass");
        scoreClass["score"] = Score;

        scoreClass.SaveAsync((NCMBException e) =>
        {
            if (e != null)
            {
                Debug.Log("Error: " + e.ErrorMessage);
            }
            else
            {
                Debug.Log("success");
            }
        });

    }

}