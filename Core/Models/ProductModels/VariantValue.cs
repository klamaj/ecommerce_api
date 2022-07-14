namespace Core.Models.ProductModels;

public class VariantValue : Base
{
    public string VariantValueName { get; set; }
    public string VariantValueDescription { get; set; }
    public string VariantValueCode { get; set; }
    public string Slug { get; set; }
    public Variant Variant { get; set; }
    public int VariantId { get; set; }
}

/*
    INSERT INTO VariantValues
        (VariantValueName, VariantValueDescription, VariantId)
    VALUES
        ('Red', 'blablabla', 1),
        ('Black', 'blablas', 1),
        ('Silver925', 'asdasdasd', 2),
        ('Gold', 'asdasdasd', 2);
*/