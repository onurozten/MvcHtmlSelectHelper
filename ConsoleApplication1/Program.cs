using System.Collections.Generic;
using HtmlSelectHelper;

namespace ConsoleApplication1
{
    class Program
    {
        class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            var t = new List<Product>()
            {
                new Product(){Id = 1, Name = "Pepper"},
                new Product(){Id = 2, Name = "Watermelon"},
                new Product(){Id = 2, Name = "Grape"},
            };

            var selectList = SelectListHelper.GetSelectList(t, "Id", "Name",true,"Product","-1");
            var selectList2 = t.ToSelectList("Id", "Name",true, "Seçelim");

        }

    }
}
