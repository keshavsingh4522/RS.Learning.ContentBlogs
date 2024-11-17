using Markdig.Renderers;
using Markdig.Syntax.Inlines;
using Microsoft.AspNetCore.Components;

namespace RS.WebApp.ContentBlog.Core;

// Custom renderer for links
public class CustomLinkRenderer(NavigationManager navigationManager) : Markdig.Renderers.Html.HtmlObjectRenderer<LinkInline> // Update the type reference
{
    private readonly NavigationManager _navigationManager = navigationManager;

    protected override void Write(HtmlRenderer renderer, LinkInline obj) // Update the type reference
    {
        // Example: Customizing link URLs
        var customUrl = obj.Url?.StartsWith("http") == true
            ? obj.Url // Keep external links as is
            : $"{_navigationManager.BaseUri}files/{obj.Url}"; // Modify internal links

        // You can also customize link attributes, e.g., add a class
        renderer.Write("<a href=\"")
                .Write(customUrl)
                .Write("\" class=\"custom-link\">")
                .Write(obj.Title ?? obj.Url)
                .Write("</a>");
    }
}
