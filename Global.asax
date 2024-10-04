<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    {
        Exception ex = Server.GetLastError();
        string str = "";
        str = ex.Message;
        string path = "~/web/Products/ErrorLog.txt";
        path = HttpContext.Current.Server.MapPath(path);
        System.IO.File.WriteAllText(path, str);
        Server.Transfer("~/ErrorPage.html");

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
    //public void Page_PreInit(object sender, EventArgs e)
    //{
    //    string strUA = Request.UserAgent.Trim().ToLower();
    //    bool isMobile = false;
    //    if (strUA.Contains("ipod") || strUA.Contains("iphone"))
    //        isMobile = true;

    //    if (strUA.Contains("android"))
    //        isMobile = true;

    //    if (strUA.Contains("opera mobi"))
    //        isMobile = true;

    //    if (strUA.Contains("windows phone os") && strUA.Contains("iemobile"))
    //        isMobile = true;

    //    if (strUA.Contains("palm"))
    //        isMobile = true;

    //    bool MobileDevice = Request.Browser.IsMobileDevice;
    //    if (isMobile == true && MobileDevice == true)
    //    {
    //        Server.Transfer("http://m.easybuybye.com");
    //    }
    //}
   
       
</script>
