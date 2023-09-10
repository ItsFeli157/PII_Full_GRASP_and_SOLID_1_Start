//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Linq; // brinda una serie de extensiones y operaciones que permiten realizar consultas

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }
        //El principio que se uso es el SOLID : Este método sigue el principio de responsabilidad única al asignar
        // la responsabilidad de calcular el costo total de producción a la clase Recipe.
        public double GetProductionCost()
        {
             double costOfIngredients = 0;
            double costOfEquipment = 0;

            foreach (Step step in this.steps)
            {
                costOfIngredients += step.Quantity * step.Input.UnitCost;
                costOfEquipment += (step.Time / 60.0) * step.Equipment.HourlyCost; // Convierte minutos a horas
            }

            return costOfIngredients + costOfEquipment;
        }
    }
}