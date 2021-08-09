using System;
using System.Collections.Generic;

namespace Mod7
{
    internal abstract class Product
    {
        private protected string Name;
        private protected string Description;
        private protected List<string> Ingredients;
        private protected int Calories;
        private protected int Price;
        protected Product()
        {
        }
        protected Product(string name, string description, int calories, int price)
        {
            Name = name;
            Description = description;
            Calories = calories;
            Price = price;
        }
        protected Product(string name, string description, List<string> ingredients, int calories, int price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Calories = calories;
            Price = price;
        }

        internal abstract Product GetProduct();
        // {
        //     return Product;
        // }
    }

    internal abstract class Food : Product
    {
        private protected bool IsHot;
        private protected List<string> Extras;
        protected Food() 
        {
        }
        protected Food(string name, string description,  int calories, int price,bool isHot = false):base(name, description, calories, price)
        {
            IsHot = isHot;
        }       
        protected Food(string name, string description, List<string> ingredients, int calories, int price,bool isHot, List<string> extras):base(name, description, ingredients, calories, price)
        {
            IsHot = isHot;
            Extras = extras;
        }
        // public virtual  Product GetProduct();
    }
    abstract class Drink : Product
    {
        private protected string Vessel;
        private protected bool AddPaperCup;
    }
    internal class Sushi : Food
    {
        private string Filler;
        public Sushi(){}

        private Sushi(string name, string description, List<string> ingredients, int calories, int price, bool isHot, List<string> extras):base(name, description, ingredients, calories, price, isHot, extras)
        {
        }

        internal Sushi(string name, string filler, string description, int calories, int price, bool isHot = false) :
            base(name, description, calories, price, isHot)
        {
            Filler = filler;
            MakeSushi();
        }
        
        private void MakeSushi( )
        {
            List<string> ingredients = new List<string>();
            ingredients.Add("рис");
            ingredients.Add(Filler);
            ingredients.Add("морская капуста");
            Ingredients = ingredients;
            List<string> extras = new List<string>();
            extras.Add("соевый соус");
            extras.Add("васаби");
            Extras = extras;

        }

        internal override Product GetProduct()
        {   
            MakeSushi();
            string ingredients = "";
            foreach (string item in Ingredients)
            {
                ingredients += item + "; ";
            }
            string extras = "";
            foreach (string extra in Extras)
            {
                extras += extra + "; ";
            }

            string s = $"Название: {Name} " +
                       $"\nОписание: {Description} " +
                       $"\nСостав: {ingredients}" +
                       $"\nКалорийность: {Calories} ккал " +
                       $"\nЦена: {Price} руб.";
            if (IsHot) s+= $"\nГорячее блюдо!";
            s += $"\nДополнительно: {extras}";
            Console.WriteLine(s);
            // return s;
            return new Sushi(Name, Description, Ingredients, Calories, Price, IsHot, Extras);

        }
        
    }
    // internal class Roll : Food
    // {
    //
    // }
    // internal class Soup : Food
    // {
    //
    // }
    // internal class Salad : Food
    // {
    //
    // }
    // internal class Tea : Drink
    // {
    //
    // }
    // internal class Juice : Drink
    // {
    //
    // }

}