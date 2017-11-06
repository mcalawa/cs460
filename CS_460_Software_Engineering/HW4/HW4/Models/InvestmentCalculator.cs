using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW4.Models
{
    public class InvestmentCalculator
    {
        public double Principle { get; set; } //how much you invested
        public double Interest { get; set; } //what your interest rate is
        public int Term { get; set; } //how many times a year it is calculated
        public int Time { get; set; } //number of years
        public bool Compound { get; set; } //if it's compound interest
    }
}