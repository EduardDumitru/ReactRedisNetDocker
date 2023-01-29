using System.ComponentModel.DataAnnotations;

namespace MindGeek.Models
{
    public class ViewingWindow
    {
        public DateTime StartDate { get; init; } = default!;
        public string WayToWatch { get; init; } = default!;
        public DateTime EndDate { get; init; } = default!;
    }
}
