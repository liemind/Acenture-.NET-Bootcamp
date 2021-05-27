using System;
using System.Collections.Generic;
using System.Linq;
using Salvo.Models;
using System.Threading.Tasks;

namespace Salvo.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SalvoContext context)
        {
            if (context.Players.Any())
            {
                return;   // DB has been seeded
            }

            var players = new Player[]
            {
                new Player{Email="j.bauer@ctu.gov"},
                new Player{Email="c.obrian@ctu.gov"},
                new Player{Email="kim_bauer@gmail.com"},
                new Player{Email="t.almeida@ctu.gov"}
            };

            foreach (Player p in players)
            {
                context.Players.Add(p);
            }
            context.SaveChanges();

        }
    }
}
