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
        public void BlogPostController_UpdateBlogPost_ValidUser()
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
        public void BlogPostController_UpdateBlogPost_InvalidUser()
        {
            //Arrange 
            var values = new BlogPostUpdateDto
            {
                Content = "test",
                Title = "Title",
                UserId = 3
            }; 

            var postToUpdateId = 2;

            //Act 
            var createdResponse = _blogPostController.UpdateBlogPost(postToUpdateId, values);

            //Assert 
            Assert.IsType<BadRequestObjectResult>(createdResponse as BadRequestObjectResult);
        }

        [Fact]
        public void BlogPostController_UpdateBlogPost_UserNotExist()
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
        public void BlogPostController_UpdateBlogPost_PostNotExist() 
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
        public void BlogPostController_RemoveBlogPost_ValidUser()
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
        public void BlogPostController_RemoveBlogPost_InvalidUser()
        {
            //Arrange 
            var postToDelete = 1;
            var user = 2;

            //Act 
            var createdResponse = _blogPostController.DeleteBlogPost(postToDelete, user);

            //Assert 
            Assert.IsType<BadRequestObjectResult>(createdResponse as BadRequestObjectResult);
        }

        [Fact]
        public void BlogPostController_RemoveBlogPost_UserNotExist()
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
        public void PostController_RemoveBlogPost_PostNotExist() 
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