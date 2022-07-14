namespace Core.Models.ProductModels;

public class Variant : Base
{
    public string VariantName { get; set; }
    public string VariantDescription { get; set; }
}

/*
    INSERT INTO Variants
        (VariantName, VariantDescription)
    VALUES
        ('Color', 'blablabla'),
        ('Material', 'blablabla')
*/