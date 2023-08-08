using Assignment2.Model;

namespace Assignment2.Context
{
    public class DbInit
    {
        public static void InitData(ShoppingContext ctx)
        {
            if(ctx.Products.Any())
            {
                return;
            }

            var Account = new Account[]
            {
                new Account{FullName= "Ho Trong Duan", UserName="duanht" ,Password = "1234", Type = "1" },
                new Account{FullName= "Nguyen Van A", UserName="nva" ,Password = "1234", Type = "2" }
            };
            ctx.Account.AddRange(Account);
            ctx.SaveChanges();

            var Categories = new Categories[]
            {
                new Categories{CategoryName= "Standard", Description="Standard food"},
                new Categories{CategoryName= "Mini", Description="Mini food"}
            };
            ctx.Categories.AddRange(Categories);
            ctx.SaveChanges();

            var Suppliers = new Suppliers[]
            {
                new Suppliers{CompanyName="FBT Food", Address="Da nang", Phone= "096969696969"}
            };
            ctx.Suppliers.AddRange(Suppliers);
            ctx.SaveChanges();


            var Products = new Products[]
            {
                new Products{ProductName ="Capricciosa", CategoryID = 1,  SupplierID= 1, QuantityPerUnit = 10, ProductImage="~/Image/pizza1.png"},
                new Products{ProductName ="Pizza", CategoryID = 1,  SupplierID= 1, QuantityPerUnit = 10, ProductImage= "~/Image/pizza2.png"},
                new Products{ProductName ="Capricciosa", CategoryID = 1,  SupplierID= 1, QuantityPerUnit = 10, ProductImage= "~/Image/pizza3.jpg"}
            };
            ctx.Products.AddRange(Products);
            ctx.SaveChanges();
        }
    }
}
