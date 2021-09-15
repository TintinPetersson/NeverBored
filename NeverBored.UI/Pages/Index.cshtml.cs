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
        public List<ActivityModel> ActivityFavorties { get; set; }
        public async Task<IActionResult> OnGet()
        {
            //----Prepare and Get Cookies

            string stringFavorites = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                ActivityFavorties = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorites);
            }

            //----Get Activity from API

            ActivityManager activityManager = new ActivityManager();

            Activity = await activityManager.GetActivity();

            ActivityManager.Activities.Add(Activity);

            return Page();
        }
        public async Task<IActionResult> OnPost(string id)
        {
            ActivityManager activityManager = new ActivityManager();
            Activity = await activityManager.SearchActivity(id);


            string stringFavorites = HttpContext.Session.GetString("Favorites");
            var favorites = new List<ActivityModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorites);
            }

            favorites.Add(Activity);

            if (ModelState.IsValid)
            {
                stringFavorites = JsonConvert.SerializeObject(favorites);

                HttpContext.Session.SetString("Favorites", stringFavorites);

                return Redirect("/Index");
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostDelete(string key)
        {
            string stringFavorites = HttpContext.Session.GetString("Favorites");

            var favorites = new List<ActivityModel>();

            if (!String.IsNullOrEmpty(stringFavorites))
            {
                favorites = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorites);
            }

            var activityToRemove = favorites.First(c => c.Key == key);

            favorites.Remove(activityToRemove);

            stringFavorites = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString("Favorites", stringFavorites);

            return RedirectToPage("/Index");
        }
    }
}
