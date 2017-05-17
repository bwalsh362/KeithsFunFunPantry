﻿using KeithsFunFunPantry.CS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace KeithsFunFunPantry
{
    [Serializable()]
    public class Ingredient
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Regex nameValidation = new Regex(@"^[a-zA-Z\s]*$");
        private string name = "";
        private Measurement ingredientMeasurement;

        //Name of the ingredient
        public string Name
        {
            get { return name; }
            set
            {
                if (nameValidation.IsMatch(value))
                {
                    name = value;
                    FieldChanged();
                }
                else
                {
                    MessageBox.Show("Please enter a valid name");
                }
            }
        }

        //Measurement of the ingredient
        public Measurement IngredientMeasurement
        {
            get { return ingredientMeasurement; }
            set
            {
                ingredientMeasurement = value;
                FieldChanged();
            }
        }

        public Ingredient(string name, Measurement m)
        {
            Name = name;
            IngredientMeasurement = m;
        }

        protected void FieldChanged([CallerMemberName] string field = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(field));
            }
        }
    }
}