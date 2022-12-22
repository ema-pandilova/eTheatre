﻿using eTheatre.Data.Static;
using eTheatre.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTheatre.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Theatre
                if (!context.Theatres.Any())
                {
                    context.Theatres.AddRange(new List<Theatre>()
                    {
                        new Theatre()
                        {
                            Name = "Theatre 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first theatre"
                        },
                        new Theatre()
                        {
                            Name = "Theatre 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first theatre"
                        },
                        new Theatre()
                        {
                            Name = "Theatre 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first theatre"
                        },
                        new Theatre()
                        {
                            Name = "Theatre 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first theatre"
                        },
                        new Theatre()
                        {
                            Name = "Theatre 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first theatre"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Plays
                if (!context.Plays.Any())
                {
                    context.Plays.AddRange(new List<Play>()
                    {
                        new Play()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            TheatreId = 3,
                            ProducerId = 3,
                            PlayCategory = PlayCategory.Comedy
                        },
                        new Play()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            TheatreId = 1,
                            ProducerId = 1,
                            PlayCategory = PlayCategory.Comedy
                        },
                        new Play()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            TheatreId = 4,
                            ProducerId = 4,
                            PlayCategory = PlayCategory.Comedy
                        },
                        new Play()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            TheatreId = 1,
                            ProducerId = 2,
                            PlayCategory = PlayCategory.Comedy
                        },
                        new Play()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            TheatreId = 1,
                            ProducerId = 3,
                            PlayCategory = PlayCategory.Comedy
                        },
                        new Play()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            TheatreId = 1,
                            ProducerId = 5,
                            PlayCategory = PlayCategory.Comedy
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Plays.Any())
                {
                    context.Actors_Plays.AddRange(new List<Actor_play>()
                    {
                        new Actor_play()
                        {
                            ActorId = 1,
                            PlayId = 1
                        },
                        new Actor_play()
                        {
                            ActorId = 3,
                            PlayId = 1
                        },

                         new Actor_play()
                        {
                            ActorId = 1,
                            PlayId = 2
                        },
                         new Actor_play()
                        {
                            ActorId = 4,
                            PlayId = 2
                        },

                        new Actor_play()
                        {
                            ActorId = 1,
                            PlayId = 3
                        },
                        new Actor_play()
                        {
                            ActorId = 2,
                            PlayId = 3
                        },
                        new Actor_play()
                        {
                            ActorId = 5,
                            PlayId = 3
                        },


                        new Actor_play()
                        {
                            ActorId = 2,
                            PlayId = 4
                        },
                        new Actor_play()
                        {
                            ActorId = 3,
                            PlayId = 4
                        },
                        new Actor_play()
                        {
                            ActorId = 4,
                            PlayId = 4
                        },


                        new Actor_play()
                        {
                            ActorId = 2,
                            PlayId = 5
                        },
                        new Actor_play()
                        {
                            ActorId = 3,
                            PlayId = 5
                        },
                        new Actor_play()
                        {
                            ActorId = 4,
                            PlayId = 5
                        },
                        new Actor_play()
                        {
                            ActorId = 5,
                            PlayId = 5
                        },


                        new Actor_play()
                        {
                            ActorId = 3,
                            PlayId = 6
                        },
                        new Actor_play()
                        {
                            ActorId = 4,
                            PlayId = 6
                        },
                        new Actor_play()
                        {
                            ActorId = 5,
                            PlayId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "adminUser@etickets.com";
                 var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

               
                string appUserEmail = "user@etickets.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }

            }
        }
    }
}
