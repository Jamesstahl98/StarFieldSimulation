namespace StarFieldSimulation
{
    public partial class Form1 : Form
    {
        int numberOfStars = 100;
        private List<Star> stars = [];

        public Form1() => InitializeComponent();

        bool isDrawing = false;
        private Graphics g;
        private Graphics gF;
        private Bitmap btm;

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            btm = new Bitmap(Width, Height);
            gF = Graphics.FromImage(btm);

            for (int i = 0; i < numberOfStars; i++)
            {
                var star = new Star(Width, Height);
                stars.Add(star);
            }

            isDrawing = true;
            Draw();
        }

        private void Draw()
        {
            while (isDrawing)
            {
                gF.Clear(Color.Black);
                for (int i = 0; i < stars.Count; i++)
                {
                    SolidBrush brush = new(Color.FromArgb(stars[i].Alpha, 255, 255, 255));
                    stars[i].Update();
                    gF.FillEllipse(brush, stars[i].sx, stars[i].sy, 6, 6);
                }
                g.DrawImage(btm, 0, 0);
            }
        }
    }
}
