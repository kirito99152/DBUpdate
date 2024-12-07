using DBUpdate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DBUpdate.Controllers
{
    public class testController : Controller
    {
        private readonly C500HemisContext Context;
        private readonly IConfiguration configuration;
        public testController(C500HemisContext _Context, IConfiguration configuration)
        {
            Context = _Context;
            this.configuration = configuration;
        }
        public async Task<IActionResult> Index()
        {
            List<string> tables = new List<string>();
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("C500")))
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.CommandText = "SELECT name FROM sys.tables WHERE schema_id = 9";
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        tables.Add(reader.GetString(0));
                    }
                    con.Close();
                }
            }
            //Dictionary<string, int> checks = new Dictionary<string, int>();
            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("C500")))
            {
                foreach (string table in tables)
                {
                    using (SqlCommand cmd = con.CreateCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.Clear();
                        cmd.CommandText = $"SELECT COUNT(*) FROM [DM].[{table}]";
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int cr = reader.GetInt32(0);
                            if (cr == 0) Console.WriteLine($"{table} : {cr}");
                        }
                        con.Close();
                    }
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string ds_)
        {
            List<Nhap>? ds = JsonSerializer.Deserialize<List<Nhap>>(ds_);
            if (!check(ds))
            {
                return View();
            }
            Console.WriteLine("Ok run!");
            int cnt = 0;
            foreach (Nhap d in ds)
            {
                ++cnt;
                bool dk = await add(d);
                Console.WriteLine("Ok GOOD!");
            }
            Console.WriteLine($"Complete! Total: {cnt}");
            return View();
        }
        private bool check(List<Nhap> ds)
        {
            foreach (Nhap d in ds)
            {
                if (!TryValidateModel(d))
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<bool> add(Nhap d)
        {
            if (!TryValidateModel(d)) return false;

            Context.Add(d);
            await Context.SaveChangesAsync();
            return true;
        }

    }
}
