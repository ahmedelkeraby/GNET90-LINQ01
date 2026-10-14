using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LINQ.DataSources.Source;
namespace LINQ
{
    internal class Program
    {

        static void Main(string[] args)
        {
            #region Q1
            var result = ProductList.Where(p => p.Category == "Seafood")
                                    .Select(p => new { p.ProductName, p.UnitPrice });
            foreach (var p in result)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion

            #region Q2
            var result2 = ProductList.Select(p => p.ProductName);
            foreach (var name in result2)
                Console.WriteLine(name);
            #endregion

            #region Q3
            var result3 = ProductList.OrderBy(p => p.UnitPrice)
                .Select(p => new { p.ProductName, p.UnitPrice });
            foreach (var p in result3)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion

            #region Q4
            var result4 = ProductList.Where(p => p.UnitPrice > 10 && p.UnitPrice < 30)
                .Select(p => new { p.ProductName, p.UnitPrice });

            foreach (var p in result4)
                Console.WriteLine($"{p.ProductName} - {p.UnitPrice}");
            #endregion

            #region Q5
            var result5 = ProductList.Where(p => p.Category == "Condiments" && p.UnitsInStock > 0)
                .Select(p => new { p.ProductName, p.UnitsInStock });

            foreach (var p in result5)
                Console.WriteLine($"{p.ProductName} (Stock: {p.UnitsInStock})");
            #endregion
            #region Q6
            var result6 = ProductList.Select(p => new {
                Name = p.ProductName,
                Price = p.UnitPrice,
                StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"

            });

            foreach (var item in result6)
                Console.WriteLine($"{item.Name} | {item.Price} | {item.StockStatus}");
            #endregion 
            #region Q7

            var result7 = ProductList.Select((p, index) => $"{index + 1}. {p.ProductName}");
            foreach (var line in result7)
                Console.WriteLine(line);
            #endregion
            #region Q8

            var result8 = ProductList.OrderBy(p => p.Category)
                                   .ThenByDescending(p => p.UnitPrice);
            foreach (var p in result8)
                Console.WriteLine($"{p.Category} | {p.ProductName} | {p.UnitPrice}");
            #endregion
            #region Q9
            var result9 = ProductList.Where(p => p.Category == "Beverages")
                                     .OrderByDescending(p => p.UnitsInStock)
                                     .Select(p => new { p.ProductName, p.UnitsInStock });
            foreach (var p in result9)  
                Console.WriteLine($"{p.ProductName} - {p.UnitsInStock}");
            #endregion
            #region Q10
            var result10 = from c in CustomerList
                      from o in c.Orders
                      where o.OrderDate.Year >= 1997
                      select new { c.CustomerID, o.OrderDate };
            foreach (var x in result10)
                Console.WriteLine($"{x.CustomerID} - {x.OrderDate:yyyy-MM-dd}");
            #endregion
            #region Q11
            var result11 = ProductList.Select((p, index) => new { p.ProductName, Index = index + 1 });
            foreach(var item in result11)
                Console.WriteLine($"{item.Index}. {item.ProductName}");
            #endregion
            #region Q12
            String[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

            var result12 = Arr.OrderBy(w => w.Length)
                              .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
            foreach (var word in result12)
                Console.WriteLine(word);
            #endregion





        }
    }
}
