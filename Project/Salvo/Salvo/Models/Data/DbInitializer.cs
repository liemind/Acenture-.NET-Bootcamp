﻿using System;
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
                    new Game{CreationDate=DateTime.Now},
                    new Game{CreationDate=DateTime.Now.AddHours(1)},
                    new Game{CreationDate=DateTime.Now.AddHours(2)},
                    new Game{CreationDate=DateTime.Now.AddHours(3)}
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
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game1, Player=player2 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player1 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game2, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player5 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game3, Player=player4 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player3 },
                    new GamePlayer { JoinDate=System.DateTime.Now, Game=game4, Player=player4 }
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
                GamePlayer gamePlayer1 = context.GamePlayers.Find(1L);
                GamePlayer gamePlayer2 = context.GamePlayers.Find(2L);
                GamePlayer gamePlayer3 = context.GamePlayers.Find(3L);
                GamePlayer gamePlayer4 = context.GamePlayers.Find(4L);
                GamePlayer gamePlayer5 = context.GamePlayers.Find(5L);
                GamePlayer gamePlayer6 = context.GamePlayers.Find(6L);
                GamePlayer gamePlayer7 = context.GamePlayers.Find(7L);
                GamePlayer gamePlayer8 = context.GamePlayers.Find(8L);

                var ships = new Ship[]
                {
                    new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer1, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "H2"},
                            new ShipLocation { Location = "H3"},
                            new ShipLocation { Location = "H4"},
                            },

                    },
                    new Ship{
                            Type="Submarine", GamePlayer = gamePlayer1, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "E1"},
                            new ShipLocation { Location = "F1"},
                            new ShipLocation { Location = "G1"},
                            },

                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer1, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B4"},
                            new ShipLocation { Location = "B5"}
                            },
                    },
                     new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer2, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"},
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer2, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "F1"},
                            new ShipLocation { Location = "F2"}
                            },

                    },
                    new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer3, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"},
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer3, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "C6"},
                            new ShipLocation { Location = "C7"}
                            },
                    },
                     new Ship{
                            Type="Submarine", GamePlayer = gamePlayer4, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "A2"},
                            new ShipLocation { Location = "A3"},
                            new ShipLocation { Location = "A4"},
                            },

                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer4, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "G6"},
                            new ShipLocation { Location = "H6"}
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer5, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"}
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer5, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "C6"},
                            new ShipLocation { Location = "C7"}
                            },
                    },
                    new Ship{
                            Type="Submarine", GamePlayer = gamePlayer5, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "A2"},
                            new ShipLocation { Location = "A3"},
                            new ShipLocation { Location = "A4"},
                            },
                    },
                    new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer6, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"},
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer6, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "G6"},
                            new ShipLocation { Location = "H6"}
                            },
                    },
                    new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer7, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"},
                            },
                    },
                    new Ship{
                            Type="Destroyer", GamePlayer = gamePlayer8, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "B5"},
                            new ShipLocation { Location = "C5"},
                            new ShipLocation { Location = "D5"},
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer8, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "C6"},
                            new ShipLocation { Location = "C7"}
                            },
                    },
                    new Ship{
                            Type="Submarine", GamePlayer = gamePlayer8, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "A2"},
                            new ShipLocation { Location = "A3"},
                            new ShipLocation { Location = "A4"},
                            },
                    },
                    new Ship{
                            Type="PatroalBoat", GamePlayer = gamePlayer6, Locations = new ShipLocation[]{
                            new ShipLocation { Location = "G6"},
                            new ShipLocation { Location = "H6"}
                            },
                    },
                };

                foreach (Ship ship in ships)
                {
                    context.Ships.Add(ship);
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
                GamePlayer gp5 = context.GamePlayers.Find(5L);
                GamePlayer gp6 = context.GamePlayers.Find(6L);
                GamePlayer gp7 = context.GamePlayers.Find(7L);
                GamePlayer gp8 = context.GamePlayers.Find(8L);

                var salvos = new Salvo[]
                {
                    new Salvo{ Turn = 1, GamePlayer = gp1, Locations = new SalvoLocation[]{ 
                        new SalvoLocation { Cell = "B5"},
                        new SalvoLocation { Cell = "C5"},
                        new SalvoLocation { Cell = "F1"},
                    } },
                    new Salvo{ Turn = 2, GamePlayer = gp1, Locations = new SalvoLocation[]{ 
                        new SalvoLocation { Cell = "F2"},
                        new SalvoLocation { Cell = "F5"},
                    } },
                    new Salvo{ Turn = 1, GamePlayer = gp2, Locations = new SalvoLocation[]{ 
                        new SalvoLocation { Cell = "B4"},
                        new SalvoLocation { Cell = "B5"},
                        new SalvoLocation { Cell = "B6"},
                    } },
                    new Salvo{ Turn = 2, GamePlayer = gp2, Locations = new SalvoLocation[]{ 
                        new SalvoLocation { Cell = "E1"},
                        new SalvoLocation { Cell = "H3"},
                        new SalvoLocation { Cell = "A2"},
                    } },
                    new Salvo{Turn = 1, GamePlayer = gp3, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "A2" },
                            new SalvoLocation { Cell = "A4" },
                            new SalvoLocation { Cell = "G6" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp3, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "A3" },
                            new SalvoLocation { Cell = "H6" }
                        }
                    },
                     new Salvo{Turn = 1, GamePlayer = gp4, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "B5" },
                            new SalvoLocation { Cell = "D5" },
                            new SalvoLocation { Cell = "C7" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp4, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "C5" },
                            new SalvoLocation { Cell = "C6" }
                        }
                    },
                    new Salvo{Turn = 1, GamePlayer = gp5, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "G6" },
                            new SalvoLocation { Cell = "H6" },
                            new SalvoLocation { Cell = "A4" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp5, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "A2" },
                            new SalvoLocation { Cell = "A3" },
                            new SalvoLocation { Cell = "D8" }
                        }
                    },
                    new Salvo{Turn = 1, GamePlayer = gp6, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "H1" },
                            new SalvoLocation { Cell = "H2" },
                            new SalvoLocation { Cell = "H3" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp6, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "E1" },
                            new SalvoLocation { Cell = "F2" },
                            new SalvoLocation { Cell = "G3" }
                        }
                    },
                    new Salvo{Turn = 1, GamePlayer = gp7, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "A3" },
                            new SalvoLocation { Cell = "A4" },
                            new SalvoLocation { Cell = "F7" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp7, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "A2" },
                            new SalvoLocation { Cell = "G6" },
                            new SalvoLocation { Cell = "H6" }
                        }
                    },
                    new Salvo{Turn = 1, GamePlayer = gp8, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "B5" },
                            new SalvoLocation { Cell = "C6" },
                            new SalvoLocation { Cell = "H1" }
                        }
                    },
                    new Salvo{Turn = 2, GamePlayer = gp8, Locations = new SalvoLocation[] {
                            new SalvoLocation { Cell = "C5" },
                            new SalvoLocation { Cell = "C7" },
                            new SalvoLocation { Cell = "D5" }
                        }
                    },

                };

                foreach (Salvo salvo in salvos)
                {
                    context.Salvos.Add(salvo);
                }

                context.SaveChanges();
            }

            // Scores
            if (!context.Scores.Any())
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

                var scores = new Score[]
                {
                    new Score {Point=1.0, FinishDate=DateTime.Now, Game=game1, Player=player1 },
                    new Score {Point=2.0, FinishDate=DateTime.Now, Game=game1, Player=player2 },
                    new Score {Point=0, FinishDate=DateTime.Now, Game=game2, Player=player1 },
                    new Score {Point=1.0, FinishDate=DateTime.Now, Game=game2, Player=player3 },
                    new Score {Point=1.5, FinishDate=DateTime.Now, Game=game3, Player=player5 },
                    new Score {Point=1.0, FinishDate=DateTime.Now, Game=game3, Player=player4 },
                    new Score {Point=2.0, FinishDate=DateTime.Now, Game=game4, Player=player3 },
                    new Score {Point=1.5, FinishDate=DateTime.Now, Game=game4, Player=player4 }
                };

                foreach (Score score in scores)
                {
                    context.Scores.Add(score);
                }

                context.SaveChanges();
            }
        }
    }
}
