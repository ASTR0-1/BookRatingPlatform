namespace BookRatingPlatform.BLL.DTO;

public class BookDetailsDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Cover { get; set; }

    public string Content { get; set; }

    public string Genre { get; set; }

    public decimal Rating { get; set; }

    public IEnumerable<ReviewForAddingDto> Reviews { get; set; }
}
