// Copyright (c) 2013 Gil Abrantes | MIT License

using System.Data.Entity;

namespace GA.MealRoulette.Model
{
    public class PlanningContext : DbContext
    {
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Soup> Soups { get; set; }
        public DbSet<Main> Mains { get; set; }
        public DbSet<Side> Sides { get; set; }
        public DbSet<Meal> Meals { get; set; }
    }
}
