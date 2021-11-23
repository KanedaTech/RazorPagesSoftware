using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesSoftware.Data;
using RazorPagesSoftware.Models;

namespace RazorPagesSoftware.Pages.Softwares
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesSoftware.Data.RazorPagesSoftwareContext _context;

        public IndexModel(RazorPagesSoftware.Data.RazorPagesSoftwareContext context)
        {
            _context = context;
        }

        public IList<Software> Softwares { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SoftwarePublisher { get; set; }

        public SelectList Publishers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Publisher { get; set; }

        [BindProperty(SupportsGet =true)]
        public string SoftwareLocations { get; set; }

        public SelectList Locations { get; set; }

        [BindProperty(SupportsGet =true)]
        public string Location { get; set; }


        public SelectList PoNumbers { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PurchaseOrder { get; set; }

        public IList<Software> Software { get;set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of publishers.
            IQueryable<string> publisherQuery = from p in _context.Software
                                                orderby p.Publisher
                                                select p.Publisher;

            IQueryable<string> locationQuery = from l in _context.Software
                                                orderby l.Location
                                                select l.Location;

            IQueryable<string> poQuery = from po in _context.Software
                                         orderby po.PONumber
                                         select po.PONumber;


            var softwares = from s in _context.Software
                            select s;
                        
            
            if (!string.IsNullOrEmpty(SearchString))
            {
                softwares = softwares.Where(s => s.Name.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SoftwarePublisher))
            {
                softwares = softwares.Where(x => x.Publisher == SoftwarePublisher);
            }

            if (!string.IsNullOrEmpty(SoftwareLocations))
            {
                softwares = softwares.Where(x => x.Location == SoftwareLocations);
            }

            if (!string.IsNullOrEmpty(PurchaseOrder))
            {
                softwares = softwares.Where(po => po.PONumber == PurchaseOrder);
            }

            //Software = await _context.Software.ToListAsync();
            Publishers = new SelectList(await publisherQuery.Distinct().ToListAsync());
            Locations = new SelectList(await locationQuery.Distinct().ToListAsync());
            PoNumbers = new SelectList(await poQuery.Distinct().ToListAsync());
            Software = await softwares.ToListAsync();

        }
    }
}
