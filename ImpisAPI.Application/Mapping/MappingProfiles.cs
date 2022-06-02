using System.Linq;
using ImpisAPI.Application.DTOs;
using ImpisAPI.Domain.Entities;
using Profile = AutoMapper.Profile;

namespace ImpisAPI.Application.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserPhoto, PhotoDto>().ReverseMap();
            CreateMap<ReservoirPhoto, PhotoDto>().ReverseMap();
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.Author.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.Author.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => 
                    s.Author.Photos.FirstOrDefault(p => p.IsMain).Url));

            CreateMap<Topic, TopicDto>();
            CreateMap<TopicDto, Topic>();

            CreateMap<Topic, UserTopicDto>()
                .ForMember(d => d.CreatorUsername, o => o.MapFrom(t => t.Creator.UserName))
                .ForMember(d => d.TopicId, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreatedAt))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Title));

            CreateMap<AppUser, ImpisAPI.Application.DTOs.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault().Url))
                .ForMember(d => d.TopicsCount, o => o.MapFrom(u => u.Topics.Count));

            CreateMap<WaterParameters, WaterParametersDto>()
                .ForMember(w => w.ReservoirId, 
                    expression => expression.MapFrom(w => w.Reservoir.Id));
            CreateMap<WaterParametersDto, WaterParameters>();
                
            
            CreateMap<Suggestion, SuggestionDto>().ReverseMap();
            CreateMap<Sales, SalesDto>().ReverseMap();
            CreateMap<ReservoirType, ReservoirTypeDto>().ReverseMap();
            CreateMap<Reservoir, ReservoirDto>().ReverseMap();
            CreateMap<Period, PeriodDto>().ReverseMap();
            CreateMap<IdealWaterParameters, IdealWaterParametersDto>().ReverseMap();
            CreateMap<IdealResult, IdealResultDto>().ReverseMap();


        }
    }
}