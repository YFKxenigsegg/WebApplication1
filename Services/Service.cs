using MongoDB.Driver;
using System.Xml.Linq;
using WebApplication1.Models;

namespace WebApplication1.Services;
public interface IService
{
    public Task<Form> Get();
    public Task Update(Form form);
    public Task Create();
}

public class Service(IMongoCollection<Form> _collection) : IService
{
    private readonly IMongoCollection<Form> _collection = _collection;

    public async Task<Form> Get() => await _collection.Find(_ => true).FirstAsync();

    public async Task Update(Form form)
    {
        var prev = await Get();
        await _collection.ReplaceOneAsync(x => x.Id == prev.Id, form);
    }

    // test
    public async Task Create() => await _collection.InsertOneAsync(
        new Form
        {
            Fields = [
                new () {Name = "First Name", Type = "",   IsRequired = true },
                new (){Name = "First Name", Type = "",   IsRequired = true },
                new (){Name = "First Name", Type = "",   IsRequired = true }
            ]
        });
}
