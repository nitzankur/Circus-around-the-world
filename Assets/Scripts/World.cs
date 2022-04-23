using System;

namespace DefaultNamespace
{
    public class World
    {
        private String name;

        private int shotCounter;

        private int areaCounter;
        private bool painted;
        private float progress;

        private int areaLimit, shotLimit;

        public World(string name, int sharedShotLimit, int sharedAreaLimit)
        {
            this.name = name;
            shotCounter = 0;
            areaCounter = 0;
            painted = false;
            progress = 0;

            areaLimit = sharedAreaLimit;
            shotLimit = sharedShotLimit;
        }
        
        public string Name => name;

        public bool Painted => painted;

        public float Progress => (progress < 100) ? progress : 100;
        
        public int ShotCounter
        {
            get => shotCounter;
            set
            {
                shotCounter = value;
                UpdateProgress();
            }
        }
        
        public int AreaCounter
        {
            get => areaCounter;
            set
            {
                areaCounter = value;
                UpdateProgress();
            }
        }

        private void UpdateProgress()
        {
            progress = 100 * ((float)areaCounter / areaLimit + (float)shotCounter / shotLimit) / 2;
            painted = progress >= 1;
        }
    }
}