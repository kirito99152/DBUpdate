using DBUpdate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DBUpdate.Controllers
{
    public class HandleController : Controller
    {
        private Dictionary<string, int> dic = new Dictionary<string, int>();
        private Dictionary<string, int> dic1 = new Dictionary<string, int>();
        private readonly C500HemisContext Context;
        public HandleController(C500HemisContext _Context) 
        {
            Context = _Context;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string ds_)
        {
            bool[] check = new bool[100000];
            List<object>? ds = JsonConvert.DeserializeObject<List<object>>(ds_);
            return Content(JsonConvert.SerializeObject(ds));
            return View();
        }
        //private async Task<List<table1>> find(List<dmQuocTich> ds)
        //{
        //    List<table1> ls = await Context.table1s.ToListAsync();
        //    List<table2> lv = await Context.table2s.ToListAsync();
        //    foreach (table2 l in lv)
        //    {
        //        dic[l.a] = l.Id;
        //    }
        //    foreach (dmQuocTich d in ds)
        //    {
        //        //ls.Add(cr);
        //    }
        //    return ls;
        //}
        private bool check(List<table1> ds)
        {
            foreach (table1 d in ds)
            {
                if (!TryValidateModel(d))
                {
                    return false;
                }
            }
            return true;
        }
        private async Task<bool> add(table1 d)
        {
            if (!TryValidateModel(d)) return false;
            
            Context.Add(d);
            await Context.SaveChangesAsync();
            return true;
        }

    }
}
