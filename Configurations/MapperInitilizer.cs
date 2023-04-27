﻿using AutoMapper;
using Backend_Controller_Burhan.Models;
using Cooking_School_ASP.NET.Dtos;
using Cooking_School_ASP.NET.Dtos.AdminDto;
using Cooking_School_ASP.NET.Dtos.ApplicationDto;
using Cooking_School_ASP.NET.Dtos.ChefDto;
using Cooking_School_ASP.NET.Dtos.CookClassDto;
using Cooking_School_ASP.NET.Dtos.CourseDto;
using Cooking_School_ASP.NET.Dtos.ProjectFileDto;
using Cooking_School_ASP.NET.Dtos.TraineeDto;
using Cooking_School_ASP.NET.Dtos.UserDto;
using Cooking_School_ASP.NET.Models;
using Cooking_School_ASP.NET_.Models;
using System.Runtime;

namespace Cooking_School_ASP.NET.Configurations
{
    public class MapperInitilizer : Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ChefDTO, Chef>()
                .ForMember(c => c.CvPath, option => option.Ignore());
            CreateMap<Chef, ChefDTO>();
            CreateMap<Chef, UpdateChefDto>()
                .ForMember(c => c.Cv, option => option.Ignore())
                .ForMember(c => c.Password, option => option.Ignore());
            CreateMap<CreateChefDto, Chef>()
                .ForMember(c => c.PasswordHashed, option => option.Ignore())
                .ForMember(c => c.PasswordSlot, option => option.Ignore())
                .ForMember(c => c.Created, option => option.Ignore())
                .ForMember(c => c.CvPath, option => option.Ignore());

            CreateMap<TraineeDTO, Trainee>().ReverseMap();
            CreateMap<Trainee, UpdateTraineeDto>()
                .ForMember(c => c.image, option => option.Ignore())
                .ForMember(c => c.Password, option => option.Ignore());
            CreateMap<CreateTraineeDto, Trainee>()
                .ForMember(t => t.Created, option => option.Ignore())
                .ForMember(t => t.ImagePath, option => option.Ignore())
                .ForMember(t => t.PasswordHashed, option => option.Ignore())
                .ForMember(t => t.PasswordSlot, option => option.Ignore());

            CreateMap<CourseDTO, Course>().ReverseMap();
            CreateMap<CreateCourseDto, Course>()
                .ForMember(t => t.Created, option => option.Ignore());
            CreateMap<UpdateCourseDto, CourseDTO>().ReverseMap();
            CreateMap<UpdateCourseDto, Course>().ReverseMap();

            CreateMap<CookClassDTO, CookClass>();
            CreateMap<CookClass, CookClassDTO>()
                .ForMember(t => t.ClassDays, option => option.Ignore());
            CreateMap<CreateCookClassDto, CookClass>()
                .ForMember(t => t.Created, option => option.Ignore())
                .ForMember(t => t.ClassDays, option => option.Ignore());



            CreateMap<ApplicationDTO, ApplicationT>().ReverseMap();
            CreateMap<CreateApplicationDto, ApplicationT>()
                .ForMember(t => t.Created, option => option.Ignore())
                .ForMember(a => a.DateOfApplay, option => option.Ignore());

            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<CreateProjectDto, Project>()
                .ForMember(t => t.Created, option => option.Ignore());

            CreateMap<ProjectFileDTO, ProjectFile>().ReverseMap();

            CreateMap<SubmitedFileDto, SubmitedFile>().ReverseMap();
            CreateMap<CreateSubmitedFileDto, SubmitedFile>()
                .ForMember(t => t.Created, option => option.Ignore());

            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<CreateUserDto, User>()
                .ForMember(t => t.Created, option => option.Ignore());
            CreateMap<FavoriteChefDto, User>().ReverseMap();


            //CreateMap<ClassDays, ClassDaysDTO>()
            //    .ForMember(t => t.Days, option => option.Ignore());
            //CreateMap<CreateClassDaysDto, ClassDays>()
            //    .ForMember(t => t.Created, option => option.Ignore());

            CreateMap<CreateAdminDto, Admin>()
            .ForMember(t => t.Created, option => option.Ignore());
            CreateMap<Admin, AdminDTO>().ReverseMap();
            CreateMap<Admin, UpdateAdminDto>();
        }
    }
}
