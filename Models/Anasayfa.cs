using System.Collections.Generic;

public class Anasayfa
{
    public int ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public List<DataItem> Data { get; set; }
}

public class DataItem
{
    public string SectionType { get; set; }
    public string RepeatType { get; set; }
    public int ItemCountInRow { get; set; }
    public bool LazyLoadingEnabled { get; set; }
    public bool TitleVisible { get; set; }
    public string Title { get; set; }
    public string TitleColor { get; set; }
    public string TitleBgColor { get; set; }
    public string SectionBgColor { get; set; }
    public string ImageUrl { get; set; }

    public List<Item> ItemList { get; set; }
}

public class Item
{
    public bool HasPhotoGallery { get; set; }
    public bool HasVideo { get; set; }
    public bool TitleVisible { get; set; }
    public string ShortText { get; set; }
    public string FullPath { get; set; }
    public Category Category { get; set; }
    public string ImageUrl { get; set; }
    public string ItemId { get; set; }
    public string Title { get; set; }
}


public class Category
{
    public string CategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
}
