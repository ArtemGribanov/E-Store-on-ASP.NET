namespace DAL.Entities;
public class Category
{
	public int Id { get; set; }
	public string Name { get; set; }
	public ICollection<Category> Categories { get; set; }
}
