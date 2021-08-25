using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/// <summary>
/// Code taken from https://www.youtube.com/watch?v=JzEwVCgALuY 
/// </summary>

namespace GamesArchitectureProject
{
    public class ScoreManager
    {
        private static string _fileName = "scores.xml"; // Since we don't give a path, this'll be saved in the "bin" folder

        public List<GameGlobals> Highscores { get; private set; }

        public List<GameGlobals> Scores { get; private set; }

        public ScoreManager()
            : this(new List<GameGlobals>())
        {

        }

        public ScoreManager(List<GameGlobals> scores)
        {
            Scores = scores;

            UpdateHighscores();
        }

        public void Add(GameGlobals score)
        {
            Scores.Add(score);

            Scores = Scores.OrderByDescending(c => c.Value).ToList(); // Orders the list so that the higher scores are first

            UpdateHighscores();
        }

        public static ScoreManager Load()
        {
            // If there isn't a file to load - create a new instance of "ScoreManager"
            if (!File.Exists(_fileName))
                return new ScoreManager();

            // Otherwise we load the file

            using (var reader = new StreamReader(new FileStream(_fileName, FileMode.Open)))
            {
                var serilizer = new XmlSerializer(typeof(List<GameGlobals>));

                var scores = (List<GameGlobals>)serilizer.Deserialize(reader);

                return new ScoreManager(scores);
            }
        }

        public void UpdateHighscores()
        {
            Highscores = Scores.Take(3).ToList(); // Takes the first 3 elements
        }

        public static void Save(ScoreManager scoreManager)
        {
            // Overrides the file if it alreadt exists
            using (var writer = new StreamWriter(new FileStream(_fileName, FileMode.Create)))
            {
                var serilizer = new XmlSerializer(typeof(List<GameGlobals>));

                serilizer.Serialize(writer, scoreManager.Scores);
            }
        }
    }
}
