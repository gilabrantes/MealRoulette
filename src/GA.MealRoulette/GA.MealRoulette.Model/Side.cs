// Copyright (c) 2013 Gil Abrantes | MIT License

namespace GA.MealRoulette.Model
{
    // TODO docs
    public class Side
    {
        #region Constructors

        public Side(string name)
        {
            Name = name;
        }

        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; private set; }

        #endregion
    }
}
