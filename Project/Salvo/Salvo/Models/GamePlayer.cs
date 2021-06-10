﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Salvo.Models
{
    public class GamePlayer
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DateTime? JoinDate { get; set; }
        public long GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public long PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public ICollection<Ship> Ships { get; set; }
        public ICollection<Salvo> Salvos { get; set; }


        public Score GetScore()
        {
            return Player.GetScore(Game);
        }

        public GamePlayer GetOpponent()
        {
            return this.Game.GamePlayers.FirstOrDefault(gp => gp.Id != Id);
        }

        //public GamePlayer GetHits()
        //{

        //}

        //public GamePlayer GetStunks()
        //{

        //}
    }
}
