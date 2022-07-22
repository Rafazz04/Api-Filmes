namespace ApiFilmes.Data.Dtos
{
    public class CreateFilmeDto
    {
        public int Id { get; set; }
        public int IdImdb { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RealeaseDate { get; set; }
        public string Genre { get; set; }
        public bool Watched { get; set; }
        public string UserScore { get; set; }
    }
}
