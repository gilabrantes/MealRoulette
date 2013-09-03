// Copyright (c) 2013 Gil Abrantes | MIT License

using GA.MealRoulette.Engine;
using GA.MealRoulette.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GA.MealRoulette.CLI
{
    public class Program
    {
        #region Declarations

        public const int NumberOfPreviousPlans = 3;

        #endregion

        #region Public Methods

        public static void Main(string[] args)
        {
            var dataEngine = new DataEngine();
            var rouletteEngine = new RouletteEngine(dataEngine);
            int action;
            do
            {
                PrintMainMenu();
                Console.WriteLine("");
                Console.Write("Action: ");
                action = Int32.Parse(Console.ReadLine());
                Console.WriteLine("");
                switch (action)
                {
                    case 1:
                        PlanWeek(rouletteEngine, dataEngine);
                        break;
                    case 2:
                        ChoosePlanToEdit(dataEngine);
                        break;
                    case 3:
                        AddComponents(dataEngine);
                        break;
                    case 4:
                        PrintExitMessage();
                        break;
                }
            } while (action != 4);

        }

        #endregion

        #region Private Methods

        private static void AddComponents(DataEngine dataEngine)
        {
            int action;
            do
            {
                Console.WriteLine("*** Add Component Menu ***");
                PrintAddComponentMenu();
                Console.WriteLine("");
                Console.Write("Action: ");
                action = Int32.Parse(Console.ReadLine());
                Console.WriteLine("");
                switch (action)
                {
                    case 1:
                        AddSoup(dataEngine);
                        break;
                    case 2:
                        AddMain(dataEngine);
                        break;
                    case 3:
                        AddSide(dataEngine);
                        break;

                }
            } while (action < 1 || action > 4);
        }

        private static void AddSoup(DataEngine dataEngine)
        {
            Console.WriteLine("*** Add Soup Menu ***");
            Console.Write("Soup name: ");
            // TODO verify blank
            var soupName = Console.ReadLine();
            dataEngine.AddSoup(soupName);
            Console.WriteLine("{0} added to the database.", soupName);
            Console.WriteLine("");
        }

        private static void AddMain(DataEngine dataEngine)
        {
            Console.WriteLine("*** Add Main Menu ***");
            Console.Write("Main name: ");
            // TODO verify blank
            var mainName = Console.ReadLine();
            dataEngine.AddMain(mainName);
            Console.WriteLine("{0} added to the database.", mainName);
            Console.WriteLine("");
        }

        private static void AddSide(DataEngine dataEngine)
        {
            Console.WriteLine("*** Add Side Menu ***");
            Console.Write("Side name: ");
            // TODO verify blank
            var sideName = Console.ReadLine();
            dataEngine.AddSide(sideName);
            Console.WriteLine("{0} added to the database.", sideName);
            Console.WriteLine("");
        }

        private static void ChoosePlanToEdit(DataEngine dataEngine)
        {
            int action;
            do
            {
                PrintEditMenu();
                action = Int32.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        EditPlan(dataEngine.GetCurrentPlan());
                        break;
                    case 2:
                        int planNumber;
                        var plans = dataEngine.GetPreviousPlans(NumberOfPreviousPlans).ToArray();
                        do
                        {
                            PrintPlans(plans);
                            planNumber = Int32.Parse(Console.ReadLine());
                        } while (planNumber < 0 || planNumber > NumberOfPreviousPlans);
                        EditPlan(plans[planNumber]);
                        break;
                }
            } while (action != 3);
        }

        private static void EditPlan(Plan plan)
        {
            int mealNumber;
            do
            {
                PrintPlanMeals(plan);
                mealNumber = Int32.Parse(Console.ReadLine());
                if (mealNumber == plan.Meals.Count + 1)
                {
                    return;
                }
            } while (mealNumber < 1 || mealNumber > plan.Meals.Count);
            // TODO assign meal to plan slot
        }

        private static void PlanWeek(RouletteEngine rouletteEngine, DataEngine dataEngine)
        {
            var plan = rouletteEngine.GeneratePlan();
            int action;
            do
            {
                PrintPlan(plan);
                PrintPlanMenu();
                action = Int32.Parse(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        dataEngine.AddPlan(plan);
                        Console.WriteLine("The plan was saved.");
                        break;
                    case 2:
                        EditPlan(plan);
                        break;
                    case 3:
                        plan = rouletteEngine.GeneratePlan();
                        break;
                    case 4:
                        return;
                }
            } while (action < 1 || action > 2);
        }

        private static void PrintAddComponentMenu()
        {
            Console.WriteLine("Add:");
            Console.WriteLine("1 - Soup");
            Console.WriteLine("2 - Main");
            Console.WriteLine("3 - Side");
            Console.WriteLine("4 - Go back");
        }

        private static void PrintEditMenu()
        {
            Console.WriteLine("Edit:");
            Console.WriteLine("1 - This week's plan");
            Console.WriteLine("2 - Previous plan");
            Console.WriteLine("3 - Go back");
        }

        private static void PrintMeal(Meal meal)
        {
            Console.WriteLine("Meal for {0}", meal.Date);
            Console.WriteLine("Soup: {0}", meal.Soup);
            Console.WriteLine("Main: {0}", meal.Main);
            Console.WriteLine("Side: {0}", meal.Side);
        }

        private static void PrintPlan(Plan plan)
        {
            Console.WriteLine("Plan for week from {0} to {1}:", plan.FirstDay, plan.LastDay);
            var mealNumber = 1;
            foreach (var mealsKv in plan.Meals)
            {
                Console.Write("{0} - ", mealNumber); PrintMeal(mealsKv.Value);
                mealNumber++;
            }
        }

        private static void PrintPlanMeals(Plan plan)
        {
            // TODO get meals from plan
            Console.WriteLine("{0} - Go back", plan.Meals.Count + 1);
        }

        private static void PrintPlanMenu()
        {
            Console.WriteLine("1 - Accept plan");
            Console.WriteLine("2 - Edit plan");
            Console.WriteLine("3 - Redraw plan");
            Console.WriteLine("4 - Go back");
        }

        private static void PrintExitMessage()
        {
            Console.WriteLine("Bye!");
        }

        private static void PrintPlans(IEnumerable<Plan> plans)
        {
            foreach (var plan in plans)
            {
                PrintPlan(plan);
            }
        }

        private static void PrintMainMenu()
        {
            Console.WriteLine("***** Main Menu *****");
            Console.WriteLine("1 - Generate Week Plan");
            Console.WriteLine("2 - Edit Plan");
            Console.WriteLine("3 - Add Recipe");
            Console.WriteLine("4 - Quit");
        }

        #endregion


    }
}
