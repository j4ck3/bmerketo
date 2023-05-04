using bmerketo_webapp.Models.DTOS;

namespace bmerketo_webapp.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public ICollection<TagEntity> Tags { get; set; } = new HashSet<TagEntity>();

    public static implicit operator Tag(TagEntity entity)
    {

        if(entity != null)
        {
            return new Tag
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
        return null!;

    }
}
