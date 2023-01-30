namespace MindGeek.Dtos
{
    public record ViewingWindowDTO
    {
        public DateTime StartDate { get; init; } = default!;
        public string WayToWatch { get; init; } = default!;
        public DateTime EndDate { get; init; } = default!;
    }
}