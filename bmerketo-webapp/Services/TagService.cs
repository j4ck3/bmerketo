using bmerketo_webapp.Models.DTOS;
using bmerketo_webapp.Models.Entities;
using bmerketo_webapp.Models.Schemas;
using bmerketo_webapp.Repos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bmerketo_webapp.Services;

public class TagService
{
    private readonly TagRepo _tagRepo;
    private readonly ProductTagRepo _productTagRepo;
    public TagService(TagRepo tagRepo, ProductTagRepo productTagRepo)
    {
        _tagRepo = tagRepo;
        _productTagRepo = productTagRepo;
    }

    public async Task<Tag> CreateAsync(TagSchema schema)
    {
        try
        {
            return await _tagRepo.AddAsync(schema);
        }
        catch { return null!; }
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

    public async Task<IEnumerable<SelectListItem>> GetTagsToFormAsync()
    {
        try
        {
            var tags = new List<SelectListItem>();

            foreach (var item in await _tagRepo.GetAllAsync())
                tags.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                });

            return tags;
        }
        catch { return null!; }
    }

    public async Task<IEnumerable<SelectListItem>> GetTagsToFormAsync(string[]? selectedTags = null)
    {
        try
        {
            var tags = new List<SelectListItem>();

            foreach (var item in await _tagRepo.GetAllAsync())
                tags.Add(new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Selected = selectedTags!.Contains(item.Id.ToString())
                });

            return tags;
        }
        catch { return null!; }
    }

    public async Task<bool> CreateProductTagsAsync(ProductEntity productEntity, string[] tags)
    {
        try
        {
            foreach (var tag in tags)
            {
                await _productTagRepo.AddAsync(new ProductTagEntity
                {
                    ProductId = productEntity.Id,
                    TagId = int.Parse(tag)
                });
            }
            return true;
        }catch { return false; }
    }
} 