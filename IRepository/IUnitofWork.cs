﻿using Backend_Controller_Burhan.Models;
using Cooking_School_ASP.NET.Models;
using Cooking_School_ASP.NET_.Models;

namespace Cooking_School_ASP.NET.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Trainee> Trainees { get; }
        IGenericRepository<Chef> Chefs { get; }
        IGenericRepository<Admin> Admins { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Course> Courses { get; }
        IGenericRepository<Trainee_Course> Trainee_Courses { get; }
        IGenericRepository<CookClass> CookClasses { get; }
        IGenericRepository<ClassDays> ClassDays { get; }
        IGenericRepository<Project> Projects { get; }   
        IGenericRepository<ProjectFile> ProjectFiles { get; }
        IGenericRepository<SubmitedFile> SubmitedFiles { get; }
        IGenericRepository<RefreshToken> RefreshTokens { get; }
        IGenericRepository<BlackList> BlackLists { get; }
        IGenericRepository<ApplicationT> Applications { get; }
        IGenericRepository<FavoriteMeal_chef> FavoriteMeal_Chefs { get; }
        IGenericRepository<FavoriteMeal_Trainee> FavoriteMeal_Trainees { get; }  
        IGenericRepository<Favorite_Chef> Favorite_Chefs { get; }
        IGenericRepository<Favorite_Course> Favorite_Courses { get; }

        Task Save();

    }
}
