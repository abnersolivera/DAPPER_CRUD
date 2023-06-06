
using Dapper;
using DapperCrud.Domain.Dto;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DapperCrud.Infra;

public class Context
{
    const string connectionString = "Server=localhost,1433;Database=DapperCrud;User ID=sa;Password=1q2w3e4r@#$;Trusted_Connection=False; TrustServerCertificate=True;";
    private SqlConnection Connection { get; set; }

    public Context() => Connection = new SqlConnection(connectionString);

    public async Task<int> Create()
    {
        await using (Connection)        
            return await Connection.ExecuteAsync("INSERT INTO [Category] VALUES(@title, @slug, @description)",
                new
                {
                    title = "Backend",
                    slug = "backend",
                    description = "Aprenda tudo sobre backend nesta carreira completa."
                });  
    }

    public async Task<int> CreateScalar()
    {
        await using (Connection)
            return await Connection.ExecuteScalarAsync<int>("INSERT INTO [Category] VALUES(@title, @slug, @description);SELECT CAST(scope_identity() AS INT)",
            new
            {
                title = "Backend2",
                slug = "backend2",
                description = "Aprenda tudo sobre backend nesta carreira completa.2"
            });
    }

    public async Task<IEnumerable<CategoryDto>> ReadAll()
    {
        await using (Connection)
            return await Connection.QueryAsync<CategoryDto>("SELECT [Id], [Title], [Slug], [Description] FROM [Category]")
    }


}