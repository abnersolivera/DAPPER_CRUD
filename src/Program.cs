using DapperCrud.Infra;
using DapperCrud.Domain.Dto;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DapperCrud;

class Program
{
    static async Task Main(string[] args)
    {
        var conext = new Context();

        var categories = await conext.ReadAll();

        foreach (var item in categories)
        {
            Console.WriteLine($"Id: {item.Id}, Title: {item.Title}, Slug: {item.Slug}, Description: {item.Description}");
        }

        


    }
}
