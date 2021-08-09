using System;
using System.Collections.Generic;

namespace Mod7
{
    internal abstract class Product
    {
        protected Product(string name, string description, List<string> ingredients, int calories, int price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Calories = calories;
            Price = price;
        }
        

        private protected string Name;
        private protected string Description;
        private protected List<string> Ingredients;
        private protected int Calories;
        private protected int Price;

        protected Product()
        {
        }
    }

    internal abstract class Food : Product
    {
        private protected bool IsHot;
        private protected List<string> Extras;

        protected Food(bool isHot, List<string> extras)
        {
            IsHot = isHot;
            Extras = extras;
        }        
        protected Food(string name, string description, List<string> ingredients, int calories, int price,bool isHot, List<string> extras):base(name, description, ingredients, calories, price)
        {
            IsHot = isHot;
            Extras = extras;
        }

        protected Food() 
        {
        }
    }
    abstract class Drink : Product
    {
        private protected string Vessel;
        private protected bool AddPaperCup;
    }
    internal class Sushi : Food
    {
        public Sushi(){}
        private Sushi(string name, string description, List<string> ingredients, int calories, int price, bool isHot, List<string> extras):base(name, description, ingredients, calories, price, isHot, extras)
        {
        }

        protected Sushi makeSushi()
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("рис");
            ingredients.Add("чука");
            ingredients.Add("морская капуста");
            List<string> extras = new List<string>();
            extras.Add("соевый соус");
            extras.Add("васаби");
            Sushi chuka = new Sushi("Чука", "Суши с морскими водорослями", ingredients, 50, 100, false, extras);
            return chuka;
        }

        public string getSushi()
        {   Sushi sushi = makeSushi();
            string ingredients = "";
            foreach (string item in sushi.Ingredients)
            {
                ingredients += item + "; ";
            }
            string extras = "";
            foreach (string extra in sushi.Extras)
            {
                extras += extra + "; ";
            }

            string s = $"Название: {sushi.Name} " +
                       $"\nОписание: {sushi.Description} " +
                       $"\nСостав: {ingredients}" +
                       $"\nКалорийность: {sushi.Calories} ккал " +
                       $"\nЦена: {sushi.Price} руб.";
            if (IsHot) s+= $"\nГорячее блюдо!";
            s += $"\nДополнительно: {extras}";
            Console.WriteLine(s);
            return s;
        }
        
    }
    internal class Roll : Food
    {

    }
    internal class Soup : Food
    {

    }
    internal class Salad : Food
    {

    }
    internal class Tea : Drink
    {

    }
    internal class Juice : Drink
    {

    }

}