﻿using BroadageEntity.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
namespace BroadageEntity.Entities
{
    public class Match:BaseEntity
    {
        public int MatchId { get; set; }
        public DateTime Date { get; set; }
        public HomeTeam HomeTeam { get; set; }
        public AwayTeam AwayTeam { get; set; }
        public Status Status { get; set; }
        public Tournament Tournament { get; set; }
        public Stage Stage { get; set; }
        public Round Round { get; set; }
    }
}