using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Emplyees.Context;
using Emplyees.Models;

namespace Emplyees.Services
{
    public class EmplyeeService
    {
        public async Task Create(string title)
        {
            using (var db = new BaseContext())
            {
                db.ProgrammingLanguages.Add(new ProgrammingLanguage { Title = title });
                await db.SaveChangesAsync();
            }
        }

        public async Task Edit(ProgrammingLanguage model)
        {
            using (var db = new BaseContext())
            {
                var exist = db.ProgrammingLanguages.FirstOrDefault(x => x.Title == model.Title);
                if (exist != null)
                    throw new Exception($"programming language with title \"{model.Title}\" exist");
                var pl = await db.ProgrammingLanguages.FindAsync(model.Id);
                pl.Title = model.Title;
                await db.SaveChangesAsync();
            }
        }
    }
}