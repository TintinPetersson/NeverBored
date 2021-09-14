using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NeverBored.API;
using NeverBored.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeverBored.UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public ActivityModel Activity { get; set; }
        public async Task<IActionResult> OnGet()
        {
            //----Prepare and Get Cookies

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                ActivityManager.Activities = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorites);
            }

            //----Get Activity from API

            ActivityManager activityManager = new ActivityManager();

            Activity = await activityManager.GetActivity();


            return Page();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            ActivityManager activityManager = new ActivityManager();
            Activity = await activityManager.SearchActivity(id);

            ActivityManager.Activities.Add(Activity);

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                ActivityManager.Activities = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorites);
            }

            if (ModelState.IsValid)
            {
                stringFavorites = JsonConvert.SerializeObject(ActivityManager.Activities);

                HttpContext.Session.SetString("Favorites", stringFavorites);

                return Redirect("/ShowFavorites");
            }
            else
            {
                return Redirect("/Index");
            }
        }
    }
}
