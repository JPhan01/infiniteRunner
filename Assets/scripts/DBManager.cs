using System.Collections.Generic;
using UnityEngine;
using SQLite;

public static class DBManager 
{
    private static SQLiteConnection db => new SQLiteConnection(Application.streamingAssetsPath + "/Data/DataBase.db");
    public static void InsertNewScore(string name, int score) => db.Execute($"INSERT INTO Score (name,score) VALUES ('{name}','{score}')");
    public static void UpdateScore(string name, int score) => db.Execute($"UPDATE Score Set score = {score} WHERE name ={name}");

    public static List<DBScore> scores => db.Query<DBScore>("SELECT * FROM Score");
    public static List<DBScore> topScores(int nmbPlayers) => db.Query<DBScore>($"SELECT * FROM Score ORDER BY score DESC LIMIT {nmbPlayers + 1}");

    public class DBScore
    {
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
    }
}
