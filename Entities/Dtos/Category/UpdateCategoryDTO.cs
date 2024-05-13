namespace Entities.Dtos.Category;

public class UpdateCategoryDTO : BaseEntity
{
    public string CategoryName { get; set; }

    public string? CategoryDescription { get; set; }
}
