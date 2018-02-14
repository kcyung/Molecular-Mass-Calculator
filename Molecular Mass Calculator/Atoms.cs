using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Molecular_Mass_Calculator
{
    internal class Atoms
    {
        internal int AtomicNumber;
        internal string Element;
        internal string Symbol;
        internal double MolarMass;

        // Constructor
        public Atoms(int number, string name, string symbol, double mass)
        {
            AtomicNumber = number;
            Element = name;
            Symbol = symbol;
            MolarMass = mass;
        }

        // Display for testing
        public override string ToString()
        {
            return string.Format("{0} - {1}: {2} - {3}", AtomicNumber, Symbol, Element, MolarMass);
        }
    }
}
