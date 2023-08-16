using AutoMapper;
using BlogPost_Application.DTOs;
using BlogPost_Application.DTOs.Post;
using BlogPost_Architecture.Domain;

namespace BlogPost_Application.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<PostEntity, PostEntityDTO>().ReverseMap();
            CreateMap<CommentEntity, CommentEntityDTO>().ReverseMap();
            CreateMap<PostEntity, PostListEntityDTO>().ReverseMap();

        }

    }
}
