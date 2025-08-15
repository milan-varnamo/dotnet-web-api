﻿using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using static System.Net.WebRequestMethods;

namespace NZWalks.API.Data
{
	public class NZWalksDbContext : DbContext
	{
		public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions): base(dbContextOptions)
		{
			
		}

		// Db sets represent collections in the Db.
		public DbSet<Difficulty> Difficulties { get; set; }
		public DbSet<Region> Regions { get; set; }
		public DbSet<Walk> Walks { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			var difficulties = new List<Difficulty>()
			{
				new Difficulty()
				{
					Id = Guid.Parse("8e1bacb1-1bb7-41c8-9f04-55a7d26e4ebf"),
					Name = "Easy"
				},
				new Difficulty()
				{
					Id = Guid.Parse("c3dd252b-0b2d-4934-aecd-395a5aa1d8fa"),
					Name = "Medium"
				},
				new Difficulty()
				{
					Id = Guid.Parse("4f931159-9736-41d2-9d5f-bdb647e88349"),
					Name = "Hard"
				}
			};

			modelBuilder.Entity<Difficulty>().HasData(difficulties);

			var regions = new List<Region>
			{
				new Region
				{
					Id = Guid.Parse("f7248fc3-2585-4efb-8d1d-1c555f4087f6"),
					Name = "Auckland",
					Code = "AKL",
					RegionImageUrl = "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Region
				{
					Id = Guid.Parse("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"),
					Name = "Northland",
					Code = "NTL",
					RegionImageUrl = null
				},
				new Region
				{
					Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
					Name = "Bay Of Plenty",
					Code = "BOP",
					RegionImageUrl = null
				},
				new Region
				{
					Id = Guid.Parse("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"),
					Name = "Wellington",
					Code = "WGN",
					RegionImageUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Region
				{
					Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
					Name = "Nelson",
					Code = "NSN",
					RegionImageUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
				},
				new Region
				{
					Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
					Name = "Southland",
					Code = "STL",
					RegionImageUrl = null
				},
			};

			modelBuilder.Entity<Region>().HasData(regions);
		}
	}
}
