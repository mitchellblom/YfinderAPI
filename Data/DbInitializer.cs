using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using YFinderAPI.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using YFinder.Data;
using YFinder.Models;

namespace YFinderAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YFinderContext(serviceProvider.GetRequiredService<DbContextOptions<YFinderContext>>()))
            {
                if (context.User.Any())
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
                        Description = "Secluded Seating",
                        Description = "Easy To Focus",
                        Description = "Hard To Focus",
                        Description = "Introvert Paradise",
                        Description = "Extravert Playground",
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
                        Title = "Bongo Java"
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
                        Title = "Red Bicycle"
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
                        Title = "Edley's BBQ"
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
                        HostId = hosts.Single(h => h.Title == "Bongo Java").HostId,
                        Title = "BongoWifi"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Belmont University Library").HostId,
                        Title = "BruinWifi"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Steadfast Coffee").HostId,
                        Title = "SteadfastWifi"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Nashville Software School").HostId,
                        Title = "NSSguest"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Red Bicycle").HostId,
                        Title = "RBwifi"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Farmers Market").HostId,
                        Title = "FMwifi"
                    },
                    new Hotspot { 
                        HostId = hosts.Single(h => h.Title == "Edley's BBQ").HostId,
                        Title = "EdleysWifi"
                    },
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
                        Comment = "Killer good speed, and nice place to focus on the task",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "BongoWifi").HotspotId,
                        Public = true,
                        Score = 4,
                        User = users.Single(h => h.FullName == "Jango Fett").UserId
                    },
                    new Rating { 
                        Comment = "Not the best wifi, but Iiked the darkness. It was almost like a cave.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "BruinWifi").HotspotId,
                        Public = true,
                        Score = 4,
                        User = users.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "Tried the coffee soda while sitting there for hours. Tons of outlets.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "SteadfastWifi").HotspotId,
                        Public = true,
                        Score = 5,
                        User = users.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "Couldn't find any outlets. Wouldn't recommend.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "BruinWifi").HotspotId,
                        Public = true,
                        Score = 2,
                        User = users.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "RBwifi").HotspotId,
                        Public = true,
                        Score = 2,
                        User = users.Single(h => h.FullName == "Val Kilmer").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.FullName == "RBwifi").HotspotId,
                        Public = true,
                        Score = 2,
                        User = users.Single(h => h.FullName == "Dee Veloper").UserId
                    },
                    new Rating { 
                        Comment = "They let me sit here all day even though I didn't buy anything.",
                        RatingDate = DateTime.Now;
                        HotspotId = hotspots.Single(h => h.Title == "FMwifi").HotspotId,
                        Public = true,
                        Score = 2,
                        User = users.Single(h => h.FullName == "Jon Snow").UserId
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
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 1).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 3).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 1).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 2).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 4).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 2).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 6).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 3).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 3).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 3).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 4).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 5).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 4).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 7).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 5).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 9).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 6).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 12).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 6).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 10).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 7).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 11).DescriptorId
                    },
                    new RatingDescriptor {
                        RatingId = ratings.Single(o => o.RatingId == 7).RatingId,
                        DescriptorId = descriptors.Single(o => o.DescriptorId == 1).DescriptorId
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
                    },
                    new User { 
                        FullName = "Jango Fett",
                        Host = 0
                    },
                    new User { 
                        FullName = "Jon Snow",
                        Host = 0
                    },
                    new User { 
                        FullName = "Val Kilmer",
                        Host = 0
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