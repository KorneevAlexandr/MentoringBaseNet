using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Linq.Task1.DoNotChange;

namespace Linq.Task1
{
    public static class LinqTask
    {
        public static IEnumerable<Customer> Linq1(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var query = customers.Where(x => x.Orders.Sum(o => o.Total) > limit);

            return query;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers)
        {
            if (customers == null) 
            {
                throw new ArgumentNullException(nameof(customers));
            }

            if (suppliers == null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }

            var query = customers.Select(c => (c, suppliers.Where(s => c.Country.Equals(s.Country) && c.City.Equals(s.City))));
                
            return query;
        }

        public static IEnumerable<(Customer customer, IEnumerable<Supplier> suppliers)> Linq2UsingGroup(
            IEnumerable<Customer> customers,
            IEnumerable<Supplier> suppliers
        )
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            if (suppliers == null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }


            var query = customers.Select(c => (c, suppliers.Where(s => c.Country.Equals(s.Country) && c.City.Equals(s.City))));

            return query;
        }

        public static IEnumerable<Customer> Linq3(IEnumerable<Customer> customers, decimal limit)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var query = customers.Where(x => x.Orders.Any(o => o.Total > limit)).ToList();

            return query;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq4(
            IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var query = customers.Where(x => x.Orders.Any())
                .Select(x => (x, x.Orders.OrderBy(o => o.OrderDate).First().OrderDate));

            return query;
        }

        public static IEnumerable<(Customer customer, DateTime dateOfEntry)> Linq5(
            IEnumerable<Customer> customers)
        {
            var query = Linq4(customers);

            query = query.OrderBy(x => x.dateOfEntry.Year)
                         .ThenBy(x => x.dateOfEntry.Month)
                         .ThenByDescending(x => x.customer.Orders.Sum(o => o.Total))
                         .ThenBy(x => x.customer.CustomerID);

            return query;
        }

        public static IEnumerable<Customer> Linq6(IEnumerable<Customer> customers)
        {
            if (customers == null)
            {
                throw new ArgumentNullException(nameof(customers));
            }

            var digits = "1234567890";

            return customers
                .Where(x => string.IsNullOrWhiteSpace(x.Region) ||
                       x.PostalCode.Any(c => !digits.Contains(c)) ||
                       !x.Phone.Contains("(") && !x.Phone.Contains(")"));
        }

        public static IEnumerable<Linq7CategoryGroup> Linq7(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            var a = products
                .GroupBy(x => x.Category)
                .Select(x => new { Category = x.Key, Count = x.Count(), Categories = x.AsEnumerable() })
                .Select(x => new Linq7CategoryGroup()
                {
                    Category = x.Category,
                    UnitsInStockGroup = x.Categories.Select(c => new Linq7UnitsInStockGroup()
                    {
                        UnitsInStock = x.Count,
                        Prices = x.Categories.Select(p => p.UnitPrice)
                    })
                });

            return a;
        }

        public static IEnumerable<(decimal category, IEnumerable<Product> products)> Linq8(
            IEnumerable<Product> products,
            decimal cheap,
            decimal middle,
            decimal expensive
        )
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<(string city, int averageIncome, int averageIntensity)> Linq9(
            IEnumerable<Customer> customers
        )
        {
            throw new NotImplementedException();
        }

        public static string Linq10(IEnumerable<Supplier> suppliers)
        {
            if (suppliers == null)
            {
                throw new ArgumentNullException(nameof(suppliers));
            }

            var query = suppliers.Select(x => x.Country).Distinct().OrderBy(x => x).OrderBy(x => x.Length);

            return string.Join(string.Empty, query);
        }
    }
}