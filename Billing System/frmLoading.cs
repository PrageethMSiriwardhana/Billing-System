using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Billing_System
{
    public partial class frmLoading : Sample
    {
        private int dotCount = 0; // To keep track of the dots count

        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            timer1.Interval = 15; // Set the timer interval for dot animation (e.g., 200 milliseconds)
            timer1.Tick += Timer1_Tick; // Add event handler for the timer tick
            timer1.Start();
        }

        private async void Timer1_Tick(object sender, EventArgs e)
        {
            AnimateLoadingDots();
            AnimateLoadingPercentage();

            loadingPanel2.Width += 2; // Increment width by 2

            // Use ranges for specific actions
            if ((loadingPanel2.Width >= 100 && loadingPanel2.Width < 130) ||
                (loadingPanel2.Width >= 200 && loadingPanel2.Width < 210) ||
                (loadingPanel2.Width >= 450 && loadingPanel2.Width < 500))
            {
                await PauseTimer(200); // Pauses for 200 milliseconds
            }
           
            if (loadingPanel2.Width >= 599)
            {
               
                timer1.Stop();
                timer1.Tick -= Timer1_Tick; // Detach event handler when done
                label2.Text = "100%";
                label1.Text = "Done";
                await PauseTimer(500);
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();
            }
        }


        private async Task PauseTimer(int delay)
        {
            timer1.Stop();
            await Task.Delay(delay);
            timer1.Start();
        }

        private void AnimateLoadingDots()
        {
            //LoadingData add Name is : Lahiru Prasad
            if (dotCount == 0)
            {
                label1.Text = "Loading";
                dotCount++;
            }
            else if (dotCount == 1)
            {
                label1.Text = "Loading.";
                dotCount++;
            }
            else if (dotCount == 2)
            {
                label1.Text = "Loading..";
                dotCount++;
            }
            else if (dotCount == 3)
            {
                label1.Text = "Loading...";
                dotCount++;
            }
            else if (dotCount == 4)
            {
                label1.Text = "Loading....";
                dotCount = 0;
            }

        }



        private void AnimateLoadingPercentage()
        {
            // Calculate the percentage based on the width of loadingPanel2
            int percentage = (int)((loadingPanel2.Width / 599.0) * 100);

            // Update label2 to show the percentage
            label2.Text = $"{percentage}%";
        }


    }
}

