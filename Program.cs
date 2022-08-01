using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace shoppingBasket
{
    class Program
    {


        public class item
        {
            public string productName { get; set; }
            public string category { get; set; }
            public double price { get; set; }
        }


        static void Main(string[] args)
        {
            int counter = 0;
            int categoryChoice = -1;
            int i = 0;
            string cataloguePath = "productCatalogue.csv";
            var catalogueFile = File.ReadAllLines(cataloguePath);
            int catalogueFileLength = catalogueFile.Length;

            string categoryPath = "categories.csv";
            var categoryFile = File.ReadAllLines(categoryPath);
            int categoryFileLength = categoryFile.Length;



            item[]product;
            item[] temp;




            

            string[] category = new string[categoryFileLength];



            product = new item[catalogueFileLength];

            for (i = 0; i < categoryFileLength; i++)
            {
                category[i] = categoryFile[i];
            }

            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("Happy Days Games.");
            Console.WriteLine("====================================");
            for (i = 0; i < category.Length; i++)
            {
                Console.WriteLine(i + ". " + category[i]);
            }
            Console.WriteLine(product.Length);
            Console.WriteLine("Please, select an option, between 0 - " + category.Length + " inclusive: ");
            categoryChoice = Convert.ToInt16(Console.ReadLine());
            while(categoryChoice < 0 || categoryChoice > category.Length)
            {
                Console.WriteLine("error enter a valid number");
                categoryChoice = Convert.ToInt16(Console.ReadLine());
            }
            
            

            for (i = 0; i < catalogueFileLength; i++)
            {

                string line = catalogueFile[i];
                string[] lineList = line.Split(",");
                if (lineList[1] == category[categoryChoice])
                {
                    product[i] = new item();
                    product[i].productName = lineList[0];
                    product[i].category = lineList[1];
                    product[i].price = Convert.ToDouble(lineList[2]);
                    counter++;
                }

            }

            Console.WriteLine("=======================================================");
            Console.WriteLine("Product Cataloge");
            Console.WriteLine("=======================================================");
            string header = String.Format("{0, 6}", "Option") + " | " + String.Format("{0,-40}",
            "Product name") + " | " + String.Format("{0,-20}", "Category") + " | " + String.Format("{0,12}", "Product Price");
            Console.WriteLine(header);

            for (i = 0; i < counter; i++)
            {
                Console.WriteLine(String.Format("{0, 6}", i + ".") + " | " + String.Format("{0,-40}",
                product[i].productName) + " | " + String.Format("{0,-20}", product[i].category) + " | " + String.Format("{0,12}",product[i].price));
            }


            Console.WriteLine("Please, select an option, between 0 - " + product.Length + " inclusive: ");


            //Enter your codes here

        }
    }
}
