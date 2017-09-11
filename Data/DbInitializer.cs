using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YFinderAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YFinderAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YFinderContext(serviceProvider.GetRequiredService<DbContextOptions<YFinderContext>>()))
            {
                if (context.Customer.Any())
                {
                    return;
                }

                //seeding DESCRIPTORS
                var descriptors = new Descriptor[]
                {
                    new Descriptor {
                        Description = "Abundant Power Outlets",
                        Description = "Rare Power Outlets",
                        Description = "Loud Atmosphere",
                        Description = "Quiet Atmosphere",
                        Description = "Teamwork Friendly",
                        Description = "Teamwork Averse",
                        Description = "Password Protected",
                        Description = "Secluded Seating"
                    }
                };

                foreach (Descriptor i in descriptors)
                {
                    context.Descriptor.Add(i);
                }
                context.SaveChanges();

                //seeding HOSTS
                var hosts = new Host[]
                {
                    new Host { 
                        Address = "2007 Belmont Blvd", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Bongo Java Belmont"
                        UserId = users.Single(n => n.FullName == "Bob Bernstein").UserId,
                        Zip = 37212
                    },
                    new Host { 
                        Address = "1900 Belmont Blvd", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Belmont University Library"
                        UserId = users.Single(n => n.FullName == "Lila D. Bunch").UserId,
                        Zip = 37212
                    },
                    new Host { 
                        Address = "603 Taylor St", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Steadfast Coffee"
                        UserId = null,
                        Zip = 37208
                    },
                    new Host { 
                        Address = "603 Taylor St", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Nashville Software School"
                        UserId = users.Single(n => n.FullName == "Kristen McKinney").UserId,
                        Zip = 37210
                    },
                    new Host { 
                        Address = "2519 Nolensville Pike", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Red Bicycle Nolensville"
                        UserId = null,
                        Zip = 37211
                    },
                    new Host { 
                        Address = "900 Rosa Parks Blvd", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Farmers Market"
                        UserId = null,
                        Zip = 37208
                    },
                    new Host { 
                        Address = "4500 Murphy Rd", 
                        City = "Nashville", 
                        State= "TN"
                        Title = "Edley's BBQ Sylvan Park"
                        UserId = null,
                        Zip = 37209
                    }
                };

                foreach (Host i in hosts)
                {
                    context.Host.Add(i);
                }
                context.SaveChanges();

                //seeding HOTSPOTS
                var hotspots = new Hotspot[]
                {
                    new Hotspot { 
                        HostId = hosts.Single(n => n.FullName == "Bob Bernstein").HostId,
                        Title = ""
                    }
                };

                foreach (Hotspot i in hotspots)
                {
                    context.hotspots.Add(i);
                }
                context.SaveChanges();

                //seeding RATINGS
                var ratings = new Rating[]
                {
                    new Rating { 
                        Type = "Visa",
                        AccountNumber = "12345667890",
                        CustomerId = users.Single(firstname => firstname.FirstName == "Jelly").CustomerId,
                    }
                };

                foreach (Rating i in ratings)
                {
                    context.Rating.Add(i);
                }
                context.SaveChanges();

                //seeding RatingDescriptors, matching up with the initialized ratings and descriptors by id
                var ratingDescriptors = new RatingDescriptors[]
                {
                    new OrderProduct {
                        OrderId = orders.Single(o => o.OrderId == 1).OrderId,
                        ProductId = products.Single(o => o.ProductId == 1).ProductId
                    }
                };
                   
                foreach (RatingDescriptor i in ratingDescriptors)
                {
                    context.RatingDescriptor.Add(i);
                }
                context.SaveChanges();

                //seeding USERS
                var users = new User[]
                {
                    new User { 
                        FullName = "Dee Veloper",
                        Host = 0
                    },
                    new User { 
                        FullName = "Bob Bernstein",
                        Host = 1
                    },
                    new User { 
                        FullName = "Lila D. Bunch",
                        Host = 1
                    },
                    new User { 
                        FullName = "Taylor Swift",
                        Host = 0
                    },
                    new User { 
                        FullName = "Kristen McKinney",
                        Host = 1
                    }

                };

                foreach (User i in users)
                {
                    context.User.Add(i);
                }
                context.SaveChanges();

            }
       }
    }
}