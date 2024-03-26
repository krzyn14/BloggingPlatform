using BloggingPlatform.Interfaces;
using BloggingPlatform.Controllers;
using AutoMapper;
using BloggingPlatform.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BloggingPlatform.Tests
{
    public class BlogPostControllerTest
    {
        private readonly BlogPostController _blogPostController; 
        private readonly IMapper _mapper;   
        private readonly IBlogPostRepository _blogPostRepository; 
        private readonly IUserRepository _userRepository;  

        public BlogPostControllerTest()
        {
            _blogPostRepository = new BloggingPlatformUserRepoFake();
            _userRepository = new BloggingPlatformUserRepoFake();  
            _blogPostController = new BlogPostController(_blogPostRepository, _mapper, _userRepository); 
        }

        [Fact]
        public void BlogPostController_UpdatePost_ValidUser()
        {
            //Arange 
            var values = new BlogPostUpdateDto
            {
                Content = "test",
                Title = "Title",
                UserId = 1
            };

            var postToUpdateId = 1;

            //Act 
            var createdResponse = _blogPostController.UpdateBlogPost(postToUpdateId, values);

            //Assert
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }

        [Fact] 
        public void BlogPostController_UpdatePost_InvalidUser()
        {
            //Arrange 
            var values = new BlogPostUpdateDto
            {
                Content = "test",
                Title = "Title",
                UserId = 1
            }; 

            var postToUpdateId = 2;

            //Act 
            var createdResponse = _blogPostController.UpdateBlogPost(postToUpdateId, values);

            //Assert 
            Assert.IsType<ForbidResult>(createdResponse as ForbidResult);
        }

        [Fact]
        public void BlogPostController_UpdatePost_UserNotExist()
        {
            //Arrange 
            var values = new BlogPostUpdateDto
            {
                Content = "test",
                Title = "Title",
                UserId = 4
            };

            var postToUpdateId = 1; 

            //Act
            var createdResponse = _blogPostController.UpdateBlogPost(postToUpdateId, values);

            //Assert 
            Assert.IsType<NotFoundObjectResult>(createdResponse as NotFoundObjectResult);
        }

        [Fact] 
        public void BlogPostController_UpdatePost_PostNotExist() 
        {
            //Arrange
            var values = new BlogPostUpdateDto
            {
                Content = "test",
                Title = "Title",
                UserId = 1
            }; 

            var postToUpdateId = 100;

            //Act 
            var createdResponse = _blogPostController.UpdateBlogPost(postToUpdateId, values);

            //Assert 
            Assert.IsType<NotFoundObjectResult>(createdResponse as NotFoundObjectResult);
        }

        [Fact] 
        public void BlogPostController_RemovePost_ValidUser()
        {
            //Arrange 
            var postToDelete = 1;
            var user = 1;

            //Act 
            var createdResponse = _blogPostController.DeleteBlogPost(postToDelete, user);

            //Assert 
            Assert.IsType<OkObjectResult>(createdResponse as OkObjectResult);
        }

        [Fact] 
        public void BlogPostController_RemovePost_InvalidUser()
        {
            //Arrange 
            var postToDelete = 1;
            var user = 2;

            //Act 
            var createdResponse = _blogPostController.DeleteBlogPost(postToDelete, user);

            //Assert 
            Assert.IsType<ForbidResult>(createdResponse as ForbidResult);
        }

        [Fact]
        public void BlogPostController_RemovePost_UserNotExist()
        {
            //Arrange 
            var postToDelete = 1;
            var user = 100;

            //Act 
            var createdResponse = _blogPostController.DeleteBlogPost(postToDelete, user);

            //Assert 
            Assert.IsType<NotFoundObjectResult>(createdResponse as NotFoundObjectResult);
        }

        [Fact] 
        public void PostController_RemovePost_PostNotExist() 
        {
            //Arrange 
            var postToDelete = 100;
            var user = 1;

            //Act 
            var createdResponse = _blogPostController.DeleteBlogPost(postToDelete, user);

            //Assert 
            Assert.IsType<NotFoundObjectResult>(createdResponse as NotFoundObjectResult);
        }
    }
}