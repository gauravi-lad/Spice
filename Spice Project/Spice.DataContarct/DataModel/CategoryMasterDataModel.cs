namespace Spice.DataContarct.DataModel
{
    public class CategoryMasterDataModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryShortDescription { get; set; }
        public string CategoryLongDescription { get; set; }
        public bool IsActive { get; set; }
        public string SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryImage { get; set; }
        public string CategoryCode { get; set; }

    }
}
