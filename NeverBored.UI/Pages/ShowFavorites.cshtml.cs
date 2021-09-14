using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NeverBored.API;
using NeverBored.Data;
using Newtonsoft.Json;

namespace NeverBored.UI.Pages
{
    public class ShowFavoritesModel : PageModel
    {
        public void OnGet()
        {
            string stringFavorties = HttpContext.Session.GetString("Favorites");

            if (!String.IsNullOrEmpty(stringFavorties))
            {
                ActivityManager.Activities = JsonConvert.DeserializeObject<List<ActivityModel>>(stringFavorties);
            }
        }
    }
}
