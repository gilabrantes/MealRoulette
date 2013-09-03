// Copyright (c) 2013 Gil Abrantes | MIT/X11 License

namespace GA.MealRoulette.Model
{
    // TODO docs
    public class Main
    {
        #region Constructors

        public Main(string name)
        {
            Name = name;
        }
        
        #endregion

        #region Properties

        public int Id { get; set; }
        public string Name { get; private set; }
        public MainCategory Category { get; private set; }

        #endregion
    }
}
