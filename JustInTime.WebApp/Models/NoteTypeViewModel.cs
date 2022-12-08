using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JustInTime.WebApp.Models
{
    public class NoteTypeViewModel
    {
        public List<Note>? Notes { get; set; }
        public SelectList? Types { get; set; }
        public string? NoteType { get; set; }
        public string? SearchString { get; set; }
    }
}
