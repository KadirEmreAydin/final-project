using System.ComponentModel.DataAnnotations;
namespace final_project.ViewModels
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryModel Category { get; set; }
    }
}
