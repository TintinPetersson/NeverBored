using NeverBored.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeverBored.API
{
    public class ActivityManager
    {
        public async Task<ActivityModel> GetActivity()
        {
            ActivityModel activity = new ActivityModel();

            activity = await ActivityProcessor.LoadActivity();

            return activity;
        }
    }
}
