// Copyright (c) 2013 Gil Abrantes | MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GA.MealRoulette.Model;

namespace GA.MealRoulette.Engine
{
    public sealed class DataEngine : IDisposable
    {
        #region Declarations

        private readonly PlanningContext _db;

        #endregion

        #region Constructors

        public DataEngine()
        {
            _db = new PlanningContext();
        }

        #endregion

        #region Public Methods

        public void AddSoup(string name)
        {
            _db.Soups.Add(new Soup(name));
            _db.SaveChanges();
        }

        public void AddMain(string name)
        {
            _db.Mains.Add(new Main(name));
            _db.SaveChanges();
        }

        public void AddSide(string name)
        {
            _db.Sides.Add(new Side(name));
            _db.SaveChanges();
        }

        public void AddPlan(Plan plan)
        {
            _db.Plans.Add(plan);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public IEnumerable<Plan> GetPreviousPlans(int numberOfPlans)
        {
            return _db.Plans.Skip(_db.Plans.Count() - numberOfPlans);
        }

        public Plan GetCurrentPlan()
        {
            return _db.Plans.Last();
        }

        public IEnumerable<Soup> GetAllSoups()
        {
            return _db.Soups;
        }

        public IEnumerable<Main> GetAllMains()
        {
            return _db.Mains;
        }

        public IEnumerable<Side> GetAllSides()
        {
            return _db.Sides;
        }

        #endregion
    }
}
