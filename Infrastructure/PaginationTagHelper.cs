using Bookstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-info")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;

        public PaginationTagHelper(IUrlHelperFactory t) => uhf = t;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public IndexPageInfo PageInfo { get; set; }
        public string PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper iuh = uhf.GetUrlHelper(vc);
            TagBuilder paginationDiv = new TagBuilder("div");

            for (int i = 1; i <= PageInfo.TotalPages; i++)
            {
                TagBuilder link = new TagBuilder("a");
                link.Attributes["href"] = iuh.Action(PageAction, new { pageNum = i });
                link.InnerHtml.Append("Page " + i.ToString());

                paginationDiv.InnerHtml.AppendHtml(link);

                if (i != PageInfo.TotalPages)
                {
                    paginationDiv.InnerHtml.Append(" | ");
                }
            }

            output.Content.AppendHtml(paginationDiv.InnerHtml);
            base.Process(context, output);
        }


    }
}
