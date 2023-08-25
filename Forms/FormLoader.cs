using Timer = System.Windows.Forms.Timer;

namespace Archive.Forms
{
    public partial class FormLoader : Form
    {
        private ProgressBar progressBar;
        private Timer timer;

        private int progressValue = 0;
        private bool increment = true;

        public FormLoader()
        {
            InitializeComponent();

            // Настройка формы
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = SystemColors.Control;

            // Создание ProgressBar
            progressBar = new ProgressBar();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            progressBar.Width = 200;
            progressBar.Height = 20;
            progressBar.Left = (this.ClientSize.Width - progressBar.Width) / 2;
            progressBar.Top = (this.ClientSize.Height - progressBar.Height) / 2;

            // Создание Timer для мигания
            timer = new Timer();
            timer.Interval = 500;
            timer.Tick += TimerTick;
            timer.Start();

            // Добавление ProgressBar на форму
            this.Controls.Add(progressBar);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (increment)
            {
                progressValue += 5;
                if (progressValue >= 100)
                {
                    progressValue = 100;
                    increment = false;
                }
            }
            else
            {
                progressValue -= 5;
                if (progressValue <= 0)
                {
                    progressValue = 0;
                    increment = true;
                }
            }

            progressBar.Value = progressValue;
        }
    }
}
