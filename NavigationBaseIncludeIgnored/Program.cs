// See https://aka.ms/new-console-template for more information
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NavigationBaseIncludeIgnored;

SQLitePCL.Batteries.Init();
var _connection = new SqliteConnection("Filename=:memory:");
_connection.Open();

// These options will be used by the context instances in this test suite, including the connection opened above.
var _contextOptions = new DbContextOptionsBuilder<AppDbContext>()
    .UseSqlite(_connection)
    .Options;

// Create the schema and seed some data
using var context = new AppDbContext(_contextOptions);

if (context.Database.EnsureCreated())
{

}
var lgEquipments = new LookupGroup { Title = "Equipment" };
var lgMeasurementUnits = new LookupGroup { Title = "Measurement units" };
context.LookupGroups.AddRange(lgEquipments, lgMeasurementUnits);
context.SaveChanges();

var muPascal = new LookupValue { Title = "Pascal", LookupGroupId = lgMeasurementUnits.Id };
var muFeet = new LookupValue { Title = "Feet", LookupGroupId = lgMeasurementUnits.Id };
context.LookupValues.AddRange(muPascal, muFeet);
context.SaveChanges();

context.LookupValues.Add(
    new LookupValue
    {
        Title = "Pump",
        LookupGroupId = lgEquipments.Id,
        Attributes = new List<LookupValueAttribute>
                        {
                            new LookupValueAttribute {Title = "Pressure", MeasurementUnitId = muPascal.Id},
                            new LookupValueAttribute {Title = "Height", MeasurementUnitId = muFeet.Id}
                        }
    });
context.SaveChanges();

var pump = context.LookupValues.Where(p => p.Title == "Pump")
                                    .Include(p => p.Attributes)
                                    .Single();

pump.Attributes.ForEach(attr =>
{
    Console.WriteLine(attr.MeasurementUnit.Title);  //this prints "Pump" where as it should print "Pascal" and "Feet"
});
Console.ReadLine();

