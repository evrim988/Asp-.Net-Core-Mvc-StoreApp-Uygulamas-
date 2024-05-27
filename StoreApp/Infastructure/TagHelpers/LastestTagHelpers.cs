using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Services.Abstract;

namespace StoreApp.Infastructure.TagHelpers;

[HtmlTargetElement("div", Attributes = "products")]
public class LastestTagHelpers : TagHelper
{
    private readonly IServiceManager _manager;

    [HtmlAttributeName("number")]
    public int Number {  get; set; }

    public LastestTagHelpers(IServiceManager manager)
    {
        _manager = manager;
    }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        TagBuilder div = new TagBuilder("div");
        div.Attributes.Add("class", "my-3");  //<div class="my-3"> tanımlamış olduk.

        TagBuilder h6 = new TagBuilder("h6");
        h6.Attributes.Add("class", "lead");  // <h6 class="lead"> tanımlaış olduk.

        TagBuilder i = new TagBuilder("i");
        i.Attributes.Add("class", "fa fa-box text-secondary");  //<i class="fa fa-box text-secondary"></i> tanımlamış olduk.

        h6.InnerHtml.AppendHtml(i);  //h6 nın içindeki i ifadesini entegre etmiş olduk.
        h6.InnerHtml.AppendHtml("En Son Eklenen Ürünler");

        TagBuilder ul = new TagBuilder("ul");
        var products = _manager.ProductService.GetLastestProducts(Number, false);
        foreach (var item in products)
        {
            TagBuilder li = new TagBuilder("li");
            TagBuilder a = new TagBuilder("a");
            a.Attributes.Add("href", $"/product/getproducts/{item.Id}");
            a.InnerHtml.AppendHtml(item.ProductDescription);

            li.InnerHtml.AppendHtml(a);
            ul.InnerHtml.AppendHtml(li);
        }

        div.InnerHtml.AppendHtml(h6);
        div.InnerHtml.AppendHtml(ul);
        output.Content.AppendHtml(div);
    }
}
