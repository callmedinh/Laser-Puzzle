using _Scripts.Utilities;

namespace _Scripts
{
    public class LevelManager : Singleton<LevelManager>
    {
        public int CurrentLevel { get; set; } = 1;

        public void CompleteLevel()
        {
            CurrentLevel++;
        }
    }
}