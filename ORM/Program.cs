using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Customers;Integrated Security=True";

            var ctx = new CustomersDbContext(connectionString);

            var customers = ctx.Customers.ToList();

            var sqlQuery = "INSERT INTO Customers (Name) VALUES ('Igor')";
            var insertedRowsCount = ctx.Database.ExecuteSqlCommand(sqlQuery);

            //var customer = ctx.Customers
            //.Include(x => x.Profile)
            //.Include(x => x.Orders.Select(y => y.OrderLines))
            //.Include(x => x.Orders.Select(y => y.OrderDetails))
            //.FirstOrDefault(x => x.Id == 1);

            //ctx.Customers.Add(GetCustomer());
            //ctx.SaveChanges();
        }

        private static Customer GetCustomer()
        {
            return new Customer
            {
                Name = "Igor",
                Profile = new Profile
                {
                    RegistrationDate = DateTime.UtcNow,
                    Name = "Igor's Profile",
                },
                Orders = new List<Order>
                {
                    new Order
                    {
                        Price = 100,
                        OrderLines = new List<OrderLine>
                        {
                            new OrderLine
                            {
                                ProductName = "Product 1"
                            },
                            new OrderLine
                            {
                                ProductName = "Product 2"
                            }
                        },
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                Date = DateTime.UtcNow
                            },
                            new OrderDetail
                            {
                                Date = DateTime.UtcNow.AddDays(1)
                            }
                        }
                    },
                    new Order
                    {
                        Price = 200,
                        OrderLines = new List<OrderLine>
                        {
                            new OrderLine
                            {
                                ProductName = "Product 3"
                            },
                            new OrderLine
                            {
                                ProductName = "Product 4"
                            }
                        },
                        OrderDetails = new List<OrderDetail>
                        {
                            new OrderDetail
                            {
                                Date = DateTime.UtcNow
                            },
                            new OrderDetail
                            {
                                Date = DateTime.UtcNow.AddDays(1)
                            }
                        }
                    }
                }
            };
        }
    }
}
