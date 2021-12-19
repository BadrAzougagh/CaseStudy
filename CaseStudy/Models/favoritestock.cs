using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy.Models
{
    //Hier maken wij gebruik van overerving. 
    class favoritestock : IEquatable<favoritestock>, IComparable<favoritestock>
    {
        public string Symbol { get; set; }
        
        public favoritestock()
        {
        }
        public favoritestock(string symbol)
        {
            Symbol = symbol;
           
        }

        public override int GetHashCode()
        {
            return Symbol.GetHashCode();
        }

        public bool Equals(favoritestock other)
        {
            return Symbol == other.Symbol;
        }

        public int CompareTo(favoritestock other)
        {
            return Symbol.CompareTo(other.Symbol);
        }
    }
}
