using InheritanceC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    internal class VideoPost : Post
    {

        protected bool isPlaying = false;
        protected int currentDuration = 0;
        Timer timer;

        protected string VideoURL {  get; set; }
        protected float Length { get; set; }

        public VideoPost (string title, string sendByUsername, bool isPublic, string videoURL, float length)
        {
            Title = title;
            SendByUsername = sendByUsername;
            IsPublic = isPublic;
            VideoURL = videoURL;
            Length = length;
        }

        public override string ToString()
        {
            return String.Format("{0} - {1} - {2} - {3} - by {4}", this.ID, this.Title, this.VideoURL, this.Length, this.SendByUsername);
        }

        public void Play()
        {
            if (!isPlaying) {
                isPlaying = true;
                Console.WriteLine("Started playing.");
                timer = new Timer(TimerCallBack, null, 0, 1000);
            }
        }

        private void TimerCallBack(object o)
        {
            if (currentDuration < Length)
            {
                currentDuration++;
                Console.WriteLine("Video at {0}s", currentDuration);
                GC.Collect();
            }
            else
            {
                Stop();
            }
        }

        public void Stop()
        {
            if (isPlaying)
            {
                Console.WriteLine("Stopped at {0}s", currentDuration);
                isPlaying = false;
                currentDuration = 0;
                timer.Dispose();
            }
        }
    }
}
