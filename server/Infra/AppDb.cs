using LinqToDB;
using LinqToDB.Data;
using LinqToDB.Mapping;

public class AppDb(DataOptions options) : DataConnection(options)
{
    public ITable<CategoryRow> Categories => this.GetTable<CategoryRow>();
    // add one per table as you build each feature
}

[Table("categories")]
public class CategoryRow
{
    [PrimaryKey, Identity]  public int Id { get; set; }
    [Column("name")]        public string Name { get; set; } = "";
    [Column("slug")]        public string Slug { get; set; } = "";
    [Column("description")] public string? Description { get; set; }
    [Column("created_at")]  public DateTimeOffset CreatedAt { get; set; }
}