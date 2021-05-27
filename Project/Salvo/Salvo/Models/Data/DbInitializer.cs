using System.Linq;

namespace Salvo.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SalvoContext context)
        {
            //Players
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

            // Games
            if (context.Games.Any())
            {
                return;   // DB has been seeded
            }

            var games = new Game[]
            {
                new Game{CreationDate=System.DateTime.Parse("2019-01-01T18:32:49.8716178")},
                new Game{CreationDate=System.DateTime.Parse("2019-01-01T19:32:49.8725558")},
                new Game{CreationDate=System.DateTime.Parse("2019-01-01T20:32:49.8725564")},
                new Game{CreationDate=System.DateTime.Parse("2019-01-01T21:32:49.8725565")}
            };

            foreach (Game g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();

        }
    }
}
