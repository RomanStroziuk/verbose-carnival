using UnityEngine;

namespace Code.Runtime.Infrastructure.Services.TimeService
{
    public class TimeService : ITimeService
    {
        public void Stop()
        {
            Time.timeScale = 0;
        }
        
        public void Resume()
        {
            Time.timeScale = 1;
        }
    }
}