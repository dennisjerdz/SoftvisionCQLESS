using CognizantQLESS.Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CognizantQLESS.Core.Models
{
    public class LoadHistory
    {
        public LoadHistory() { }

        public LoadHistory(LoadViewModel loadViewModel, TransportCard transportCard)
        {
            Type = 1;
            Note = Constants.Constants.NOTE_TOPUP;
            TransportCardId = transportCard.TransportCardId;
            Amount = loadViewModel.Amount;
            RunningBalance = loadViewModel.Amount + transportCard.Load;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoadHistoryId { get; set; }
        
        public int TransportCardId { get; set; }
        [ForeignKey("TransportCardId")]
        public TransportCard TransportCard { get; set; }

        public short Type { get; set; } // 0 Deduct, 1 Topup
        public float Amount { get; set; }
        public float RunningBalance { get; set; } // Balance post transaction
        public string Note { get; set; }
    }
}
