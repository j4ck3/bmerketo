using bmerketo_webapp.Models.DTOS;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Repos;

namespace bmerketo_webapp.Services;

public class TagService
{
    private readonly TagRepo _tagRepo;
    public TagService(TagRepo tagRepo)
    {
        _tagRepo = tagRepo;
    }

    public async Task<Tag> CreateAsync(TagSchema schema)
    {
        return await _tagRepo.AddAsync(schema);
    }

    public async Task<Tag> GetAsync(string tagName)
    {
        try
        {
            return await _tagRepo.GetAsync(x => x.Name == tagName);
        }
        catch { return null!; }
    }

    public async Task<IEnumerable<Tag>> GetAllAsync()
    {
        try
        {
            var result =  await _tagRepo.GetAllAsync();
            var tags = new List<Tag>();

            foreach(var item in result)
                tags.Add(item);

            return tags;
         }
        catch { return null!; }
    }

} 