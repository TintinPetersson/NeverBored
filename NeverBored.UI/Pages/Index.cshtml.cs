using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NeverBored.API;
using NeverBored.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeverBored.UI.Pages
{
    public class IndexModel : PageModel
    {
        public ActivityModel Activity { get; set; }
        public void OnGet()
        {

        }
        public async Task<IActionResult> Generator()
        {
            ActivityManager jokeManager = new ActivityManager();

            Activity = await jokeManager.GetActivity();

            return Page();
        }
    }
}
