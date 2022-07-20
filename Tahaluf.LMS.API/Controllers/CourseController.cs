using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tahaluf.LMS.Core.Data;
using Tahaluf.LMS.Core.DTO;
using Tahaluf.LMS.Core.Service;

namespace Tahaluf.LMS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        // [Route("GetAll")]
        public List<Course> GetAllCourse()
        {
            return _courseService.ReadAll();
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(List<CourseDto>), StatusCodes.Status200OK)]
        // [Route("GetAll")]
        public List<CourseDto> GetSimpleCourses()
        {
            return _courseService.GetSimpleCourses();
        }





        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        //[Route("GetCoursesByPrice/{price}")]
        [Route("{price}")]
        public List<Course> GetCoursesByPrice(double price)
        {
            return _courseService.GetCoursesByPrice(price);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Course), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool CreateCourse([FromBody] Course course)
        {
            return _courseService.Create(course);
        }


        [HttpDelete]
        //   [Route("delete/{courseId}")]
        [Route("{courseId}")]
        public bool DeleteCourse([FromBody] int courseId)
        {
            return _courseService.Delete(courseId);
        }


        [HttpPost]
       // [Route("uploadImage")]
        public Course UploadImage()
        {
            try
            {
                var file = Request.Form.Files[0];
                byte[] fileContent;
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    fileContent = stream.ToArray();
                }
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var attachmentFileName = $"{fileName}{Path.GetExtension(file.Name)}";
                var fullPath = Path.Combine("resc", attachmentFileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                Course Item = new Course();
                Item.ImagePath = fileName;
                return Item;
            }
            catch (Exception)
            {
                return null;
            }

        }




        [HttpPost]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{courseName}")]
        public List<Course> GetCoursesByName([FromBody] string courseName)
        {
            return _courseService.GetCoursesByName(courseName);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{dateFrom}")]
        public List<Course> GetByDateFrom([FromBody] DateTime dateFrom)
        {
            return _courseService.GetByDateFrom(dateFrom);
        }

        [HttpPost]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("{dateTo}")]
        public List<Course> GetByDateTo([FromBody] DateTime dateTo)
        {
            return _courseService.GetByDateTo(dateTo);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Course>), StatusCodes.Status200OK)]
        public List<Course> GetCheapestCourse()
        {
            return _courseService.GetCheapestCourse();
        }


    }
}
