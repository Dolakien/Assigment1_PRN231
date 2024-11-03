﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.Models;
using DataAccessObject;

namespace SilverRazorPage.Pages.Admin.Account
{
    public class CreateModel : PageModel
    {
        private readonly DataAccessObject.SilverJewelry2023DbContext _context;

        public CreateModel(DataAccessObject.SilverJewelry2023DbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RoleId"] = new SelectList(_context.Roles, "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public BranchAccount BranchAccount { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BranchAccounts.Add(BranchAccount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}