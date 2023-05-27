namespace Scripts.Data
{
    public static class GameStaticData
    {
        private const int MAIN_SCENE_INDEX = 0;
        private const int LEVEL_SCENE_INDEX = 1;
        private const int LOSE_SCENE_INDEX = 2;
        private const int FPS_LIMIT = 120;
        private const float GRAVITATION = -9.81f;

        public static int MainSceneIndex => MAIN_SCENE_INDEX;
        public static int LevelSceneIndex => LEVEL_SCENE_INDEX;
        public static int LoseSceneIndex => LOSE_SCENE_INDEX;
        public static float Gravitation => GRAVITATION;
        public static int FpsLimit => FPS_LIMIT;
    }
}
