namespace final_project.ViewModels
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NewsModel> News { get; set; }
    }
}
