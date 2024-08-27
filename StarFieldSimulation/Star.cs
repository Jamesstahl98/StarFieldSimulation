namespace StarFieldSimulation
{
    internal class Star
    {
        readonly Random rand = new Random();
        private readonly int zSubtraction = 2;
        
        private float x;
        private float y;
        private float z;
        public float sx;
        public float sy;

        private readonly int formWidth;
        private readonly int formHeight;

        public int Alpha = 0;

        public Star(int width, int height)
        {
            formWidth = width;
            formHeight = height;
            RandomizePosition();
        }

        public void Update()
        {
            if (Alpha < 255)
            {
                Alpha++;
            }
            z -= zSubtraction;

            sx = Map(x / z, 0, 1, 0, formWidth) + (formWidth / 2);
            sy = Map(y / z, 0, 1, 0, formHeight) + (formHeight / 2);

            if (sx < 0 || sx > formWidth || sy < 0 || sy > formHeight)
            {
                RandomizePosition();
            }
        }

        private void RandomizePosition()
        {
            Alpha = 0;
            x = rand.Next(-formWidth / 2, formWidth / 2);
            y = rand.Next(-formHeight / 2, formHeight / 2);
            z = formWidth;
        }

        static float Map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
    }
}