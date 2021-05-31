using System;
using System.Linq;

namespace Salvo.Models.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SalvoContext context)
        {
            //Players
            if (!context.Players.Any())
            {
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

            // Games
            if (!context.Games.Any())
            {
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

            // GamePlayer
            if (!context.GamePlayers.Any())
            {
                Game game1 = context.Games.Find(1L);
                Game game2 = context.Games.Find(2L);
                Game game3 = context.Games.Find(3L);
                Game game4 = context.Games.Find(4L);

                Player player1 = context.Players.Find(1L);
                Player player2 = context.Players.Find(2L);
                Player player3 = context.Players.Find(3L);
                Player player4 = context.Players.Find(4L);

                var gameplayers = new GamePlayer[]
                {
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player2 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player4 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player4 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player2 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player2 },
                };

                foreach (GamePlayer gp in gameplayers)
                {
                    context.GamePlayers.Add(gp);
                }
                context.SaveChanges();
            }

        }
    }
}
