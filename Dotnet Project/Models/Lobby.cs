﻿using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Media;

namespace Dotnet_Project.Models
{
    public class Lobby
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string? adminId { get; set; }
        public ApplicationUser? admin { get; set; }

        public int TimeSlotId { get; set; }
        public Time_Slot TimeSlot { get; set; }

        public List<ApplicationUser> Players { get; set; } // Consolidated list for all players in the lobby

        public List<ApplicationUser> Team1 => Players.Where(p => p.TeamNumber == 1).ToList();

        public List<ApplicationUser> Team2 => Players.Where(p => p.TeamNumber == 2).ToList();

        public List<string>? playerids { get; set; }

        public int? team1_score { get; set; }
        public int? team2_score { get; set; }


        public string Type { get; set; }
        public bool IsFull { get; set; }
        public bool IsFinished { get; set; }

     
        public Lobby()
        {
            this.Players = new List<ApplicationUser>();
            this.playerids = new List<string>();
        }

        public Lobby(string name, Time_Slot t, string type)
        {
            this.Name = name;
            this.TimeSlot = t;
            this.Type = type;
            this.IsFull = false;
            this.IsFinished = false;
            this.Players = new List<ApplicationUser>();
            this.playerids = new List<string>();
        }

        public void finishLobby()
        {
           
                this.IsFinished = true;
                this.playerids = new List<string>();

                foreach (ApplicationUser user in this.Players)
                {
                    this.playerids.Add(user.Id);
                    user.LinkedLobby = null;
                }
                
            
        }

        
 
    }
}   