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
                    new Player{Email="t.almeida@ctu.gov"},
                    new Player{Email="t.perez@ctu.gov"}
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
                Player player5 = context.Players.Find(5L);

                var gameplayers = new GamePlayer[]
                {
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player2 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player4 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player4 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player2 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player5 }
                };

                foreach (GamePlayer gp in gameplayers)
                {
                    context.GamePlayers.Add(gp);
                }
                context.SaveChanges();
            }

            // Ships
            if (!context.Ships.Any())
            {
                GamePlayer gp1 = context.GamePlayers.Find(1L);
                GamePlayer gp2 = context.GamePlayers.Find(2L);
                GamePlayer gp3 = context.GamePlayers.Find(3L);
                GamePlayer gp4 = context.GamePlayers.Find(4L);

                var ships = new Ship[]
                {
                    new Ship { Type="Destroyer", GamePlayer=gp1 },
                    new Ship { Type="PatroalBoat", GamePlayer=gp1 },
                    new Ship { Type="Destroyer", GamePlayer=gp3 },
                    new Ship { Type="Destroyer", GamePlayer=gp2 },
                    new Ship { Type="PatroalBoat", GamePlayer=gp4 },
                    new Ship { Type="Destroyer", GamePlayer=gp2 },
                    new Ship { Type="Submarine", GamePlayer=gp2 },
                    new Ship { Type="PatroalBoat", GamePlayer=gp4 }
                };

                foreach (Ship s in ships)
                {
                    context.Ships.Add(s);
                }
                context.SaveChanges();
            }

            // Ship Locations
            if (!context.ShipLocations.Any())
            {
                Ship ship1 = context.Ships.Find(1L);
                Ship ship2 = context.Ships.Find(2L);
                Ship ship3 = context.Ships.Find(3L);
                Ship ship4 = context.Ships.Find(4L);
                Ship ship5 = context.Ships.Find(5L);
                Ship ship6 = context.Ships.Find(6L);
                Ship ship7 = context.Ships.Find(7L);
                Ship ship8 = context.Ships.Find(8L);

                var shipLocations = new ShipLocation[]
                {
                    new ShipLocation { Location="H2", Ship=ship1 },
                    new ShipLocation { Location="H3", Ship=ship1 },
                    new ShipLocation { Location="H4", Ship=ship1 },

                    new ShipLocation { Location="B4", Ship=ship2 },
                    new ShipLocation { Location="B5", Ship=ship2 },

                    new ShipLocation { Location="B5", Ship=ship4 },
                    new ShipLocation { Location="C5", Ship=ship4 },
                    new ShipLocation { Location="D5", Ship=ship4 },

                    new ShipLocation { Location="F1", Ship=ship5 },
                    new ShipLocation { Location="F2", Ship=ship5 },

                    new ShipLocation { Location="B5", Ship=ship3 },
                    new ShipLocation { Location="C5", Ship=ship3 },
                    new ShipLocation { Location="D5", Ship=ship3 },

                    new ShipLocation { Location="A2", Ship=ship6 },
                    new ShipLocation { Location="A3", Ship=ship6 },
                    new ShipLocation { Location="A4", Ship=ship6 },

                    new ShipLocation { Location="B5", Ship=ship7 },
                    new ShipLocation { Location="C5", Ship=ship7 },
                    new ShipLocation { Location="D5", Ship=ship7 },

                    new ShipLocation { Location="C6", Ship=ship8 },
                    new ShipLocation { Location="C7", Ship=ship8 }
                };

                foreach (ShipLocation sl in shipLocations)
                {
                    context.ShipLocations.Add(sl);
                }
                context.SaveChanges();
            }

            // Salvo
            if (!context.Salvos.Any())
            {
                GamePlayer gp1 = context.GamePlayers.Find(1L);
                GamePlayer gp2 = context.GamePlayers.Find(2L);
                GamePlayer gp3 = context.GamePlayers.Find(3L);
                GamePlayer gp4 = context.GamePlayers.Find(4L);

                var salvos = new Salvo[]
                {
                    new Salvo { GamePlayer=gp1, Turn=1 },
                    new Salvo { GamePlayer=gp2, Turn=2 },
                    new Salvo { GamePlayer=gp3, Turn=3 },
                    new Salvo { GamePlayer=gp4, Turn=1 },
                    new Salvo { GamePlayer=gp1, Turn=2 },
                    new Salvo { GamePlayer=gp1, Turn=3 },
                };

                foreach (Salvo s in salvos)
                {
                    context.Salvos.Add(s);
                }
                context.SaveChanges();
            }

            // Salvo Locations
            if (!context.SalvoLocations.Any())
            {
                Salvo salvo1 = context.Salvos.Find(1L);
                Salvo salvo2 = context.Salvos.Find(2L);
                Salvo salvo3 = context.Salvos.Find(3L);
                Salvo salvo4 = context.Salvos.Find(4L);

                var salvoLocations = new SalvoLocation[]
                {
                    new SalvoLocation { Cell="H2", Salvo=salvo1 },
                    new SalvoLocation { Cell="H3", Salvo=salvo1 },
                    new SalvoLocation { Cell="H4", Salvo=salvo1 },

                    new SalvoLocation { Cell="B4", Salvo=salvo2 },
                    new SalvoLocation { Cell="B5", Salvo=salvo2 },

                    new SalvoLocation { Cell="B5", Salvo=salvo2 },
                    new SalvoLocation { Cell="C5", Salvo=salvo2 },
                    new SalvoLocation { Cell="D5", Salvo=salvo2 },

                    new SalvoLocation { Cell="F1", Salvo=salvo3 },
                    new SalvoLocation { Cell="F2", Salvo=salvo3 },

                    new SalvoLocation { Cell="B5", Salvo=salvo3 },
                    new SalvoLocation { Cell="C5", Salvo=salvo3 },
                    new SalvoLocation { Cell="D5", Salvo=salvo3 },

                    new SalvoLocation { Cell="A2", Salvo=salvo4 },
                    new SalvoLocation { Cell="A3", Salvo=salvo4 },
                    new SalvoLocation { Cell="A4", Salvo=salvo4 },

                    new SalvoLocation { Cell="B5", Salvo=salvo4 },
                    new SalvoLocation { Cell="C5", Salvo=salvo4 },
                    new SalvoLocation { Cell="D5", Salvo=salvo4 },

                    new SalvoLocation { Cell="C6", Salvo=salvo1 },
                    new SalvoLocation { Cell="C7", Salvo=salvo1 }
                };

                foreach (SalvoLocation sl in salvoLocations)
                {
                    context.SalvoLocations.Add(sl);
                }
                context.SaveChanges();
            }

        }
    }
}
