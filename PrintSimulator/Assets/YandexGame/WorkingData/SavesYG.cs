
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public int character = -1;
        public int bestScoreSlow;
        public int bestScoreMid;
        public int bestScoreFast;
        public int bestScoreVeryFast;
    }
}
