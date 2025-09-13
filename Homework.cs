using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.models
{
    public enum ContentTypes
    {
        Application,
        Pdf,
        Zip
    }
    //[PrimaryKey(nameof(Id), nameof(StudentId), nameof(CourseId))]   
    public class Homework
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public ContentTypes ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
