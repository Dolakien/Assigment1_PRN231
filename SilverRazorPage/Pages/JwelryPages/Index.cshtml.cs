﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObject.Models;
using DataAccessObject;
using System.Text.Json;

namespace SilverRazorPage.Pages.JwelryPages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient httpClient;

        public IndexModel()
        {
            httpClient = new HttpClient();
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5204/api/Jwelry");
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var data = await response.Content.ReadAsStringAsync();
            Category = JsonSerializer.Deserialize<List<Category>>(data, options);
        }
    }
}
