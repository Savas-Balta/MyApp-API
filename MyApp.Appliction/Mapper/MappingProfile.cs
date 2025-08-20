namespace MyApp.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, GetCategoryQueryResult>();
            CreateMap<Category, GetCategoryByIdQueryResult>();

            CreateMap<Content, ContentDto>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.User.UserName));

            CreateMap<CreateContentCommand, Content>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.Ignore()) 
                .ForMember(d => d.IsDeleted, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.UpdatedAt, o => o.Ignore());

            CreateMap<UpdateContentCommand, Content>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.Ignore())
                .ForMember(d => d.IsDeleted, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore());

            CreateMap<CreateCommentCommand, Comment>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.UserId, o => o.Ignore())   
                .ForMember(d => d.IsDeleted, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.UpdatedAt, o => o.Ignore());

        }
    }
}
