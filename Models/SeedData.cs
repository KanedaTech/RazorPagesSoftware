using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using RazorPagesSoftware.Data;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesSoftware.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesSoftwareContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesSoftwareContext>>()))
            {
                // Look for any movies.
                if (context.Software.Any())
                {
                    return;   // DB has been seeded
                }

                context.Software.AddRange(
                    new Software
                    {
                        Name = "Visual Studio Community 2019",
                        Publisher = "Microsoft",
                        Vendor = "Microsoft",
                        LicenseKey = "N/A",
                        PONumber = "N/A",
                        Location = "ATC111",
                        LicenseQuantity = 99999,                        
                        RenewalDate = DateTime.Parse("2019-3-13"),
                        IsInstructional = true,
                        IsFacStaff = true,
                        IsArchived = false
                    }
                );;
                context.SaveChanges();
            }
        }
    }
}
