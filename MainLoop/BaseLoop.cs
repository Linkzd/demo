using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace MainLoop
{
    public class BaseLoop
    {
        DispatcherTimer timer = new DispatcherTimer();

        float interval = 30.0f;
        public BaseLoop()
        {
            timer.Interval = TimeSpan.FromMilliseconds(interval);
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpDate();
        }

        public virtual void UpDate()
        {

        }

        public virtual void Start()
        {
            timer.Start();
        }

        public virtual void Stop()
        {
            timer.Stop();
        }

        public void SetInterval(float interval)
        {
            timer.Interval = TimeSpan.FromMilliseconds(interval);
        }
    }
}
