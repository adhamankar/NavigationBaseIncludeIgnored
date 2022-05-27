namespace NavigationBaseIncludeIgnored;

public class LookupValue
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int LookupGroupId { get; set; }
    public virtual LookupGroup LookupGroup { get; set; }
    public virtual List<LookupValueAttribute>? Attributes { get; set; }
}
public class LookupGroup
{
    public int Id { get; set; }
    public string Title { get; set; }
}

public class LookupValueAttribute
{
    public int LookupValueId { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
    public int? MeasurementUnitId { get; set; }
    public virtual LookupValue? MeasurementUnit { get; set; }
}
