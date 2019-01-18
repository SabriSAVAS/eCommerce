using System.Web.Mvc;

public static class HtmlHelpers
{
    public static string GetStatus(this HtmlHelper a, bool statu)
    {
        if (statu == true)
        {
            return "<span class=\"label label-success\">True</span>";
        }
        else
        {
            return "<span class=\"label label-danger\">False</span>";
        }
    }


}
