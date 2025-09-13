using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentCourse.models
{
    public enum ResourceTypes
    {
        Video,
        Presentation,
        Document
    }
    //[PrimaryKey(nameof(ResourceId),nameof(CourseId))]
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public ResourceTypes ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
