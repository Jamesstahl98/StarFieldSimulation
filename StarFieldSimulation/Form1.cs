namespace StarFieldSimulation
{
    public partial class Form1 : Form
    {
        int numberOfStars = 100;
        private List<Star> stars = new List<Star>();

        public Form1()
        {
            InitializeComponent();
        }
        bool isDrawing = false;
        Graphics g;
        Graphics gF;
        Bitmap btm;
        SolidBrush brush;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            btm = new Bitmap(Width, Height);
            gF = Graphics.FromImage(btm);
            //brush = new SolidBrush(Color.White);

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
            g.Clear(Color.Black);
            while (isDrawing)
            {
                gF.Clear(Color.Black);
                for (int i = 0; i < stars.Count; i++)
                {
                    SolidBrush brush = new SolidBrush(Color.FromArgb(stars[i].Alpha, 255, 255, 255));
                    stars[i].Update();
                    gF.FillEllipse(brush, stars[i].sx, stars[i].sy, 6, 6);
                }
                g.DrawImage(btm, 0, 0);
            }
        }
    }
}
